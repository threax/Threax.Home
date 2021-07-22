import * as client from 'Client/Libs/ServiceClient';
import * as hyperCrud from 'htmlrapier.widgets/src/HypermediaCrudService';
import * as di from 'htmlrapier/src/di';

export class SensorCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listSensors(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListSensors();
    }

    public getDeletePrompt(item: client.SensorResult): string {
        return "Are you sure you want to delete the sensor?";
    }

    public getItemId(item: client.SensorResult): string | null {
        return String(item.data.sensorId);
    }

    public createIdQuery(id: string): client.SensorQuery | null {
        return {
            sensorId: id
        };
    }
}