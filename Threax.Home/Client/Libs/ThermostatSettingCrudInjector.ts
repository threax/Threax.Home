import * as client from 'Client/Libs/ServiceClient';
import * as hyperCrud from 'htmlrapier.widgets/src/HypermediaCrudService';
import * as di from 'htmlrapier/src/di';

export class ThermostatSettingCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listThermostatSettings(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListThermostatSettings();
    }

    public getDeletePrompt(item: client.ThermostatSettingResult): string {
        return "Are you sure you want to delete the thermostatSetting?";
    }

    public getItemId(item: client.ThermostatSettingResult): string | null {
        return String(item.data.thermostatSettingId);
    }

    public createIdQuery(id: string): client.ThermostatSettingQuery | null {
        return {
            thermostatSettingId: id
        };
    }
}