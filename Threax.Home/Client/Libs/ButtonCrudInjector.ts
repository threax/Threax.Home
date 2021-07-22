import * as client from 'Client/Libs/ServiceClient';
import * as hyperCrud from 'htmlrapier.widgets/src/HypermediaCrudService';
import * as di from 'htmlrapier/src/di';

export class ButtonCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: client.ButtonQuery): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        if (query.includeButler === undefined) {
            query.includeButler = true;
        }
        return entry.listButtons(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListButtons();
    }

    public getDeletePrompt(item: client.ButtonResult): string {
        return "Are you sure you want to delete the button?";
    }

    public getItemId(item: client.ButtonResult): string | null {
        return String(item.data.buttonId);
    }

    public createIdQuery(id: string): client.ButtonQuery | null {
        return {
            buttonId: id
        };
    }
}