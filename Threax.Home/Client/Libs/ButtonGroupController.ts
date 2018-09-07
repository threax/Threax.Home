import * as controller from 'hr.controller';
import * as client from 'clientlibs.ServiceClient';
import * as lcycle from 'hr.widgets.MainLoadErrorLifecycle';

export class ButtonGroup {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, controller.InjectControllerData];
    }

    private load: controller.OnOffToggle;
    private main: controller.OnOffToggle;
    private error: controller.OnOffToggle;
    private lifecycle: lcycle.MainLoadErrorLifecycle;
    private bulbcolor: HTMLElement;

    constructor(bindings: controller.BindingCollection, private data: client.ButtonResult) {
        this.load = bindings.getToggle("load");
        this.main = bindings.getToggle("main");
        this.error = bindings.getToggle("error");
        this.lifecycle = new lcycle.MainLoadErrorLifecycle(this.main, this.load, this.error, true);
        this.bulbcolor = bindings.getHandle("bulbcolor");
        this.lifecycle.showMain();
        this.setIconState();
    }

    public async pressButton(evt: Event): Promise<void> {
        evt.preventDefault();
        try {
            this.lifecycle.showLoad();
            this.data = await this.data.apply({
                buttonStateId: (<any>evt.srcElement).value
            });
            this.lifecycle.showMain();
            this.setIconState();
        }
        catch (err) {
            this.lifecycle.showError(err);
            console.log(JSON.stringify(err));
        }
    }

    private setIconState() {
        //Order is important, must set this after the toggle or its overwritten
        var buttonStates = this.data.data.buttonStates;
        if (buttonStates) {
            var switchSettings = buttonStates[0].switchSettings;
            if (switchSettings) {
                var sw = switchSettings[0].switch;
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
    }
}

export class ButtonGroupController {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, client.EntryPointInjector, controller.InjectedControllerBuilder];
    }

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
}

export function addServices(builder: controller.InjectedControllerBuilder) {
    builder.Services.addTransient(ButtonGroup, ButtonGroup);
    builder.Services.addShared(ButtonGroupController, ButtonGroupController);
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