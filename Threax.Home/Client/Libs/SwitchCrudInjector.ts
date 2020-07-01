import * as client from 'clientlibs.ServiceClient';
import * as hyperCrud from 'hr.widgets.HypermediaCrudService';
import * as di from 'hr.di';

export class SwitchCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listSwitches(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListSwitches();
    }

    public getDeletePrompt(item: client.SwitchResult): string {
        return "Are you sure you want to delete the @switch?";
    }

    public getItemId(item: client.SwitchResult): string | null {
        return String(item.data.switchId);
    }

    public createIdQuery(id: string): client.SwitchQuery | null {
        return {
            switchId: id
        };
    }
}