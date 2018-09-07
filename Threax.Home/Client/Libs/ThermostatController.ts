import * as controller from 'hr.controller';
import * as client from 'clientlibs.ServiceClient';
import * as lcycle from 'hr.widgets.MainLoadErrorLifecycle';

export class ThermostatController {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, controller.InjectControllerData];
    }

    private currentTempView: controller.IView<client.ThermostatResult>;
    private currentTempToggle: controller.OnOffToggle;

    private tempForm: controller.IForm<client.ThermostatTempInput>;
    private lifecycle: lcycle.MainLoadErrorLifecycle;

    constructor(bindings: controller.BindingCollection, private data: client.ThermostatResult) {
        this.currentTempView = bindings.getView("currentTemp");
        this.currentTempToggle = bindings.getToggle("currentTemp");

        this.tempForm = bindings.getForm("tempForm");
        this.lifecycle = new lcycle.MainLoadErrorLifecycle(bindings.getToggle("main"), bindings.getToggle("load"), bindings.getToggle("error"), true);
        this.setup();
    }

    private async setup(): Promise<void> {
        try {
            var tempSchema = await this.data.getSetTempDocs();
            this.tempForm.setSchema(tempSchema.requestSchema);

            this.data = await this.data.refresh();
            this.syncData();
            this.lifecycle.showMain();
        }
        catch (err) {
            this.lifecycle.showError(err);
        }
    }

    public async changeTemp(evt: Event): Promise<void> {
        try {
            evt.preventDefault();
            this.lifecycle.showLoad();
            var newTemps = this.tempForm.getData();
            this.data = await this.data.setTemp(newTemps);
            this.syncData();
            this.lifecycle.showMain();
        }
        catch (err) {
            this.lifecycle.showError(err);
        }
    }

    private syncData() {
        var currentData = Object.create(this.data.data);
        currentData.isOff = currentData.mode === "Off";
        this.tempForm.setData(currentData);
        this.currentTempView.setData(currentData);
        this.currentTempToggle.on();
    }
}

export class ThermostatGroupController {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, client.EntryPointInjector, controller.InjectedControllerBuilder];
    }

    constructor(bindings: controller.BindingCollection, private entryPointInjector: client.EntryPointInjector, private builder: controller.InjectedControllerBuilder) {
        var thermostats = bindings.getView<client.ThermostatResult>("main");
        this.setup(thermostats);
    }

    private async setup(thermostats: controller.IView<client.ThermostatResult>): Promise<void> {
        var entry = await this.entryPointInjector.load();
        var thermos = await entry.listThermostats({
            limit: 10000,
        });

        thermostats.setData(thermos.items, this.builder.createOnCallback(ThermostatController));
    }
}

export function addServices(builder: controller.InjectedControllerBuilder) {
    builder.Services.addTransient(ThermostatController, ThermostatController);
    builder.Services.addShared(ThermostatGroupController, ThermostatGroupController);
}

export interface IControllerOptions {
    name?: string;
}

export function createControllers(builder: controller.InjectedControllerBuilder, options?: IControllerOptions) {
    if (options === undefined) {
        options = {};
    }
    if (options.name === undefined) {
        options.name = "thermostats";
    }
    builder.create(options.name, ThermostatGroupController);
}