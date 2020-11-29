import * as controller from 'hr.controller';
import * as client from 'clientlibs.ServiceClient';
import * as lcycle from 'hr.widgets.MainLoadErrorLifecycle';
import * as event from 'hr.eventdispatcher';

abstract class ButtonIcon {
    public abstract setupIcon(sw: client.Switch): void;
}

class IconToggle extends controller.TypedToggle {
    public getPossibleStates(): string[] {
        return ["FanOff", "FanLow", "FanMedium", "FanHigh", "BulbOff", "BulbOn"];
    }
}

class DefaultButtonIcon implements ButtonIcon {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection];
    }

    private iconToggle: IconToggle;

    constructor(bindings: controller.BindingCollection) {
        this.iconToggle = new IconToggle();
        bindings.getCustomToggle("icon", this.iconToggle);
    }

    public setupIcon(sw: client.Button): void {
        if (!sw) { return; }
        this.iconToggle.applyState(String(sw.currentIcon));
    }
}

export class ButtonGroup {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [
            controller.BindingCollection,
            controller.InjectControllerData,
            ButtonGroupController,
            ButtonIcon
        ];
    }

    private load: controller.OnOffToggle;
    private main: controller.OnOffToggle;
    private error: controller.OnOffToggle;
    private lifecycle: lcycle.MainLoadErrorLifecycle;

    constructor(
        bindings: controller.BindingCollection,
        private data: client.ButtonResult,
        private buttonGroupController: ButtonGroupController,
        private icon: ButtonIcon
    ) {
        this.load = bindings.getToggle("load");
        this.main = bindings.getToggle("main");
        this.error = bindings.getToggle("error");
        this.lifecycle = new lcycle.MainLoadErrorLifecycle(this.main, this.load, this.error, true);
        this.lifecycle.showMain();
        this.icon.setupIcon(this.switch);
        this.refresh();
        this.buttonGroupController.onRefresh.add(() => this.refresh());
    }

    public async refresh(): Promise<void> {
        try {
            this.load.on();
            const sw = await this.data.getSwitch();
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
                buttonStateId: (evt.srcElement as any).value
            });
            this.lifecycle.showMain();
            this.icon.setupIcon(this.data.data);
        }
        catch (err) {
            this.lifecycle.showError(err);
            console.log(JSON.stringify(err));
        }
    }

    private get switch(): client.Switch {
        //Order is important, must set this after the toggle or its overwritten
        const buttonStates = this.data.data.buttonStates;
        if (buttonStates.length > 0) {
            const switchSettings = buttonStates[0].switchSettings;
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

    private onRefreshEvt: event.PromiseEventDispatcher<void, ButtonGroupController> = new event.PromiseEventDispatcher<void, ButtonGroupController>();

    constructor(bindings: controller.BindingCollection, private entryPointInjector: client.EntryPointInjector, private builder: controller.InjectedControllerBuilder) {
        const mainButtons = bindings.getView<client.ButtonResult>("mainButtons");
        this.setup(mainButtons);
    }

    private async setup(mainButtons: controller.IView<client.ButtonResult>): Promise<void> {
        const entry = await this.entryPointInjector.load();
        const buttons = await entry.listButtons({
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
    builder.Services.addTransient(ButtonIcon, DefaultButtonIcon);
}

export interface ControllerOptions {
    name?: string;
}

export function createControllers(builder: controller.InjectedControllerBuilder, options?: ControllerOptions) {
    if (options === undefined) {
        options = {};
    }
    if (options.name === undefined) {
        options.name = "buttons";
    }
    builder.create(options.name, ButtonGroupController);
}