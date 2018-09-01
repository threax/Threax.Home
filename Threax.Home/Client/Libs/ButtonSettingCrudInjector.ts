import * as client from 'clientlibs.ServiceClient';
import * as hyperCrud from 'hr.widgets.HypermediaCrudService';
import * as di from 'hr.di';

export class ButtonSettingCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listButtonSettings(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListButtonSettings();
    }

    public getDeletePrompt(item: client.ButtonSettingResult): string {
        return "Are you sure you want to delete the buttonSetting?";
    }

    public getItemId(item: client.ButtonSettingResult): string | null {
        return String(item.data.buttonSettingId);
    }

    public createIdQuery(id: string): client.ButtonSettingQuery | null {
        return {
            buttonSettingId: id
        };
    }
}