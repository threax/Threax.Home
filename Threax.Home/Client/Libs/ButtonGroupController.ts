import * as controller from 'hr.controller';
import * as client from 'clientlibs.ServiceClient';
import * as lcycle from 'hr.widgets.MainLoadErrorLifecycle';
import { JsonStorage } from 'htmlrapier/src/storage';
import * as event from 'hr.eventdispatcher';

abstract class ButtonIcon {
    public abstract setupIcon(sw: client.Switch): void;
}

class LightIcon implements ButtonIcon{
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection];
    }

    private bulbcolor: HTMLElement;

    constructor(bindings: controller.BindingCollection) {
        this.bulbcolor = bindings.getHandle("bulbcolor");
    }

    public setupIcon(sw: client.Switch): void {
        if (!sw) { return; }
        switch (sw.value) {
            case "on":
                this.bulbcolor.style.setProperty("background-color", "#b9b9b9");
                break;
            case "off":
                this.bulbcolor.style.setProperty("background-color", "transparent");
                break;
        }
    }
}

class FanToggle extends controller.TypedToggle {
    public getPossibleStates(): string[] {
        return ["off", "low", "medium", "high"];
    }
}

class FanIcon implements ButtonIcon {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection];
    }

    private fanToggle: FanToggle;

    constructor(bindings: controller.BindingCollection) {
        this.fanToggle = new FanToggle();
        bindings.getCustomToggle("fan", this.fanToggle);
    }

    public setupIcon(sw: client.Switch): void {
        if (!sw) { return; }
        this.fanToggle.applyState(sw.value);
    }
}

export class ButtonGroup {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, controller.InjectControllerData, controller.InjectedControllerBuilder, ButtonGroupController];
    }

    private load: controller.OnOffToggle;
    private main: controller.OnOffToggle;
    private error: controller.OnOffToggle;
    private lifecycle: lcycle.MainLoadErrorLifecycle;
    private icon: ButtonIcon;

    constructor(bindings: controller.BindingCollection, private data: client.ButtonResult, builder: controller.InjectedControllerBuilder, private buttonGroupController: ButtonGroupController) {
        this.icon = builder.createUnboundId(data.data.buttonType, ButtonIcon);
        this.load = bindings.getToggle("load");
        this.main = bindings.getToggle("main");
        this.error = bindings.getToggle("error");
        this.lifecycle = new lcycle.MainLoadErrorLifecycle(this.main, this.load, this.error, true);
        this.lifecycle.showMain();
        this.icon.setupIcon(this.switch);
        this.refresh();
        this.buttonGroupController.onRefresh.add(c => this.refresh());
    }

    public async refresh(): Promise<void> {
        try {
            this.load.on();
            var sw = await this.data.getSwitch();
            this.lifecycle.showMain();
            this.icon.setupIcon(sw.data);
        }
        catch (err) {
            this.lifecycle.showError(err);
            console.log("Error refreshing switch: " + JSON.stringify(err));
        }
    }

    public async pressButton(evt: Event): Promise<void> {
        evt.preventDefault();
        try {
            this.lifecycle.showLoad();
            this.data = await this.data.apply({
                buttonStateId: (<any>evt.srcElement).value
            });
            this.lifecycle.showMain();
            this.icon.setupIcon(this.switch);
        }
        catch (err) {
            this.lifecycle.showError(err);
            console.log(JSON.stringify(err));
        }
    }

    private get switch(): client.Switch {
        //Order is important, must set this after the toggle or its overwritten
        var buttonStates = this.data.data.buttonStates;
        if (buttonStates.length > 0) {
            var switchSettings = buttonStates[0].switchSettings;
            if (switchSettings.length > 0) {
                return switchSettings[0].switch;
            }
        }
        return null;
    }
}

export class ButtonGroupController {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, client.EntryPointInjector, controller.InjectedControllerBuilder];
    }

    private buttons: ButtonGroup[];
    private onRefreshEvt: event.PromiseEventDispatcher<void, ButtonGroupController> = new event.PromiseEventDispatcher<void, ButtonGroupController>();

    constructor(bindings: controller.BindingCollection, private entryPointInjector: client.EntryPointInjector, private builder: controller.InjectedControllerBuilder) {
        var mainButtons = bindings.getView<client.ButtonResult>("mainButtons");
        this.setup(mainButtons);
    }

    private async setup(mainButtons: controller.IView<client.ButtonResult>): Promise<void> {
        var entry = await this.entryPointInjector.load();
        var buttons = await entry.listButtons({
            limit: 10000,
        });

        mainButtons.setData(buttons.items, this.builder.createOnCallback(ButtonGroup));
    }

    public async refresh(): Promise<void> {
        await this.onRefreshEvt.fire(this);
    }

    public get onRefresh() {
        return this.onRefreshEvt.modifier;
    }
}

export function addServices(builder: controller.InjectedControllerBuilder) {
    builder.Services.addTransient(ButtonGroup, ButtonGroup);
    builder.Services.addShared(ButtonGroupController, ButtonGroupController);
    builder.Services.addTransientId(client.ButtonType.Light, ButtonIcon, LightIcon);
    builder.Services.addTransientId(client.ButtonType.Fan, ButtonIcon, FanIcon);
}

export interface IControllerOptions {
    name?: string;
}

export function createControllers(builder: controller.InjectedControllerBuilder, options?: IControllerOptions) {
    if (options === undefined) {
        options = {};
    }
    if (options.name === undefined) {
        options.name = "buttons";
    }
    builder.create(options.name, ButtonGroupController);
}