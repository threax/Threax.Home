import * as controller from 'hr.controller';
import * as client from 'clientlibs.ServiceClient';
import * as lcycle from 'hr.widgets.MainLoadErrorLifecycle';
import * as toggles from 'hr.toggles';

export class PresetButton {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, controller.InjectControllerData, ThermostatController];
    }

    constructor(bindings: controller.BindingCollection, private data: client.ThermostatSettingResult, private thermoController: ThermostatController) {

    }

    public async apply(evt: Event): Promise<void> {
        try {
            evt.preventDefault();
            this.thermoController.showLoading();
            await this.data.applySetting();
            await this.thermoController.refresh();
        }
        catch (err) {
            this.thermoController.showError(err);
        }
    }
}

export class ThermostatController {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, controller.InjectControllerData, controller.InjectedControllerBuilder];
    }

    private currentTempView: controller.IView<client.ThermostatResult>;
    private currentTempToggle: controller.OnOffToggle;

    private tempForm: controller.IForm<client.ThermostatTempInput>;
    private lifecycle: lcycle.MainLoadErrorLifecycle;

    private status: toggles.Group;
    private heating: controller.OnOffToggle;
    private cooling: controller.OnOffToggle;
    private off: controller.OnOffToggle;

    private fanStatus: toggles.Group;
    private fanon: controller.OnOffToggle;
    private fanoff: controller.OnOffToggle;

    private presets: controller.IView<client.ThermostatSettingResult>;
    private builder: controller.InjectedControllerBuilder;

    constructor(bindings: controller.BindingCollection, private data: client.ThermostatResult, builder: controller.InjectedControllerBuilder) {
        this.currentTempView = bindings.getView("currentTemp");
        this.currentTempToggle = bindings.getToggle("currentTemp");

        this.tempForm = bindings.getForm("tempForm");
        this.lifecycle = new lcycle.MainLoadErrorLifecycle(bindings.getToggle("main"), bindings.getToggle("load"), bindings.getToggle("error"), true);


        this.heating = bindings.getToggle("heating");
        this.cooling = bindings.getToggle("cooling");
        this.off = bindings.getToggle("off");
        this.status = new toggles.Group(this.heating, this.cooling, this.off);
        
        this.fanon = bindings.getToggle("fanon");
        this.fanoff = bindings.getToggle("fanoff");
        this.fanStatus = new toggles.Group(this.fanon, this.fanoff);

        this.presets = bindings.getView("presets");

        this.builder = builder.createChildBuilder();
        this.builder.Services.addShared(ThermostatController, s => this);

        this.setup();
    }

    private async setup(): Promise<void> {
        try {
            var tempSchema = await this.data.getSetTempDocs();
            this.tempForm.setSchema(tempSchema.requestSchema);

            var settings = await this.data.getSettings();
            this.presets.setData(settings.items, this.builder.createOnCallback(PresetButton));

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

    public showLoading(): void {
        this.lifecycle.showLoad();
    }

    public showError(err: any): void {
        this.lifecycle.showError(err);
    }

    public async refresh(): Promise<void> {
        try {
            this.lifecycle.showLoad();
            this.data = await this.data.refresh();
            this.syncData();
            this.lifecycle.showMain();
        }
        catch (err) {
            this.lifecycle.showError(err);
        }
    }

    private syncData() {
        var currentData = Object.create(this.data.data);
        currentData.isOff = this.data.data.mode === client.Mode.Off;
        this.tempForm.setData(currentData);
        this.currentTempView.setData(currentData);

        switch (this.data.data.state) {
            case client.State.Heating:
                this.status.activate(this.heating);
                break;
            case client.State.Cooling:
                this.status.activate(this.cooling);
                break;
            default:
                this.status.activate(this.off);
                break;
        }

        switch (this.data.data.fanState) {
            case client.FanState.On:
                this.fanStatus.activate(this.fanon);
                break;
            default:
                this.fanStatus.activate(this.fanoff);
                break;
        }
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
    builder.Services.addTransient(PresetButton, PresetButton);
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