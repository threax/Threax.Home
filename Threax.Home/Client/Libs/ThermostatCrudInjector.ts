import * as client from 'clientlibs.ServiceClient';
import * as hyperCrud from 'hr.widgets.HypermediaCrudService';
import * as di from 'hr.di';

export class ThermostatCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listThermostats(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListThermostats();
    }

    public getDeletePrompt(item: client.ThermostatResult): string {
        return "Are you sure you want to delete the thermostat?";
    }

    public getItemId(item: client.ThermostatResult): string | null {
        return String(item.data.thermostatId);
    }

    public createIdQuery(id: string): client.ThermostatQuery | null {
        return {
            thermostatId: id
        };
    }
}