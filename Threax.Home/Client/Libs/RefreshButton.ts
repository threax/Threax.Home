import * as controller from "hr.controller";
import * as buttonGroupController from 'clientlibs.ButtonGroupController';
import * as ThermostatController from 'clientlibs.ThermostatController';


export class RefreshButton {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, buttonGroupController.ButtonGroupController, ThermostatController.ThermostatGroupController];
    }

    public constructor(bindings: controller.BindingCollection, private buttonGroup: buttonGroupController.ButtonGroupController, private tstatGroup: ThermostatController.ThermostatGroupController) {
        
    }

    public async refresh(evt: Event): Promise<void> {
        evt.preventDefault();
        var buttonRefresh = this.buttonGroup.refresh();
        var tstatRefresh = this.tstatGroup.refresh();
        await buttonRefresh;
        await tstatRefresh;
    }
}

export function addServices(builder: controller.InjectedControllerBuilder) {
    builder.Services.addTransient(RefreshButton, RefreshButton);
}

export interface IControllerOptions {
    name?: string;
}

export function createControllers(builder: controller.InjectedControllerBuilder, options?: IControllerOptions) {
    if (options === undefined) {
        options = {};
    }
    if (options.name === undefined) {
        options.name = "refresh";
    }
    builder.create(options.name, RefreshButton);
}