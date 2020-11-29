import * as hal from 'hr.halcyon.EndpointClient';
import { Fetcher } from 'hr.fetcher';

export class RoleAssignmentsResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: RoleAssignments = undefined;
    public get data(): RoleAssignments {
        this.strongData = this.strongData || this.client.GetData<RoleAssignments>();
        return this.strongData;
    }

    public refresh(): Promise<RoleAssignmentsResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new RoleAssignmentsResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public setUser(data: RoleAssignments): Promise<RoleAssignmentsResult> {
        return this.client.LoadLinkWithData("SetUser", data)
               .then(r => {
                    return new RoleAssignmentsResult(r);
                });

    }

    public canSetUser(): boolean {
        return this.client.HasLink("SetUser");
    }

    public linkForSetUser(): hal.HalLink {
        return this.client.GetLink("SetUser");
    }

    public getSetUserDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("SetUser", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasSetUserDocs(): boolean {
        return this.client.HasLinkDoc("SetUser");
    }

    public update(data: RoleAssignments): Promise<RoleAssignmentsResult> {
        return this.client.LoadLinkWithData("Update", data)
               .then(r => {
                    return new RoleAssignmentsResult(r);
                });

    }

    public canUpdate(): boolean {
        return this.client.HasLink("Update");
    }

    public linkForUpdate(): hal.HalLink {
        return this.client.GetLink("Update");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public delete(): Promise<void> {
        return this.client.LoadLink("Delete").then(hal.makeVoid);
    }

    public canDelete(): boolean {
        return this.client.HasLink("Delete");
    }

    public linkForDelete(): hal.HalLink {
        return this.client.GetLink("Delete");
    }
}

export class AppCommandResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: AppCommand = undefined;
    public get data(): AppCommand {
        this.strongData = this.strongData || this.client.GetData<AppCommand>();
        return this.strongData;
    }

    public refresh(): Promise<void> {
        return this.client.LoadLink("self").then(hal.makeVoid);
    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public execute(): Promise<void> {
        return this.client.LoadLink("Execute").then(hal.makeVoid);
    }

    public canExecute(): boolean {
        return this.client.HasLink("Execute");
    }

    public linkForExecute(): hal.HalLink {
        return this.client.GetLink("Execute");
    }
}

export class AppCommandCollectionResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: AppCommandCollection = undefined;
    public get data(): AppCommandCollection {
        this.strongData = this.strongData || this.client.GetData<AppCommandCollection>();
        return this.strongData;
    }

    private itemsStrong: AppCommandResult[];
    public get items(): AppCommandResult[] {
        if (this.itemsStrong === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.itemsStrong = [];
            for (var i = 0; i < clients.length; ++i) {
                this.itemsStrong.push(new AppCommandResult(clients[i]));
            }
        }
        return this.itemsStrong;
    }

    public refresh(): Promise<AppCommandCollectionResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new AppCommandCollectionResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public next(): Promise<AppCommandCollectionResult> {
        return this.client.LoadLink("next")
               .then(r => {
                    return new AppCommandCollectionResult(r);
                });

    }

    public canNext(): boolean {
        return this.client.HasLink("next");
    }

    public linkForNext(): hal.HalLink {
        return this.client.GetLink("next");
    }

    public getNextDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasNextDocs(): boolean {
        return this.client.HasLinkDoc("next");
    }

    public previous(): Promise<AppCommandCollectionResult> {
        return this.client.LoadLink("previous")
               .then(r => {
                    return new AppCommandCollectionResult(r);
                });

    }

    public canPrevious(): boolean {
        return this.client.HasLink("previous");
    }

    public linkForPrevious(): hal.HalLink {
        return this.client.GetLink("previous");
    }

    public getPreviousDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasPreviousDocs(): boolean {
        return this.client.HasLinkDoc("previous");
    }

    public first(): Promise<AppCommandCollectionResult> {
        return this.client.LoadLink("first")
               .then(r => {
                    return new AppCommandCollectionResult(r);
                });

    }

    public canFirst(): boolean {
        return this.client.HasLink("first");
    }

    public linkForFirst(): hal.HalLink {
        return this.client.GetLink("first");
    }

    public getFirstDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasFirstDocs(): boolean {
        return this.client.HasLinkDoc("first");
    }

    public last(): Promise<AppCommandCollectionResult> {
        return this.client.LoadLink("last")
               .then(r => {
                    return new AppCommandCollectionResult(r);
                });

    }

    public canLast(): boolean {
        return this.client.HasLink("last");
    }

    public linkForLast(): hal.HalLink {
        return this.client.GetLink("last");
    }

    public getLastDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}

export class ButtonResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: Button = undefined;
    public get data(): Button {
        this.strongData = this.strongData || this.client.GetData<Button>();
        return this.strongData;
    }

    public refresh(): Promise<ButtonResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new ButtonResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public update(data: ButtonInput): Promise<ButtonResult> {
        return this.client.LoadLinkWithData("Update", data)
               .then(r => {
                    return new ButtonResult(r);
                });

    }

    public canUpdate(): boolean {
        return this.client.HasLink("Update");
    }

    public linkForUpdate(): hal.HalLink {
        return this.client.GetLink("Update");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public delete(): Promise<void> {
        return this.client.LoadLink("Delete").then(hal.makeVoid);
    }

    public canDelete(): boolean {
        return this.client.HasLink("Delete");
    }

    public linkForDelete(): hal.HalLink {
        return this.client.GetLink("Delete");
    }

    public apply(data: ApplyButtonInput): Promise<ButtonResult> {
        return this.client.LoadLinkWithData("Apply", data)
               .then(r => {
                    return new ButtonResult(r);
                });

    }

    public canApply(): boolean {
        return this.client.HasLink("Apply");
    }

    public linkForApply(): hal.HalLink {
        return this.client.GetLink("Apply");
    }

    public getApplyDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Apply", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasApplyDocs(): boolean {
        return this.client.HasLinkDoc("Apply");
    }

    public getSwitch(): Promise<SwitchResult> {
        return this.client.LoadLink("GetSwitch")
               .then(r => {
                    return new SwitchResult(r);
                });

    }

    public canGetSwitch(): boolean {
        return this.client.HasLink("GetSwitch");
    }

    public linkForGetSwitch(): hal.HalLink {
        return this.client.GetLink("GetSwitch");
    }

    public getGetSwitchDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("GetSwitch", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetSwitchDocs(): boolean {
        return this.client.HasLinkDoc("GetSwitch");
    }
}

export class ButtonCollectionResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: ButtonCollection = undefined;
    public get data(): ButtonCollection {
        this.strongData = this.strongData || this.client.GetData<ButtonCollection>();
        return this.strongData;
    }

    private itemsStrong: ButtonResult[];
    public get items(): ButtonResult[] {
        if (this.itemsStrong === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.itemsStrong = [];
            for (var i = 0; i < clients.length; ++i) {
                this.itemsStrong.push(new ButtonResult(clients[i]));
            }
        }
        return this.itemsStrong;
    }

    public refresh(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public add(data: ButtonInput): Promise<ButtonResult> {
        return this.client.LoadLinkWithData("Add", data)
               .then(r => {
                    return new ButtonResult(r);
                });

    }

    public canAdd(): boolean {
        return this.client.HasLink("Add");
    }

    public linkForAdd(): hal.HalLink {
        return this.client.GetLink("Add");
    }

    public getAddDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Add", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasAddDocs(): boolean {
        return this.client.HasLinkDoc("Add");
    }

    public next(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("next")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canNext(): boolean {
        return this.client.HasLink("next");
    }

    public linkForNext(): hal.HalLink {
        return this.client.GetLink("next");
    }

    public getNextDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasNextDocs(): boolean {
        return this.client.HasLinkDoc("next");
    }

    public previous(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("previous")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canPrevious(): boolean {
        return this.client.HasLink("previous");
    }

    public linkForPrevious(): hal.HalLink {
        return this.client.GetLink("previous");
    }

    public getPreviousDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasPreviousDocs(): boolean {
        return this.client.HasLinkDoc("previous");
    }

    public first(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("first")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canFirst(): boolean {
        return this.client.HasLink("first");
    }

    public linkForFirst(): hal.HalLink {
        return this.client.GetLink("first");
    }

    public getFirstDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasFirstDocs(): boolean {
        return this.client.HasLinkDoc("first");
    }

    public last(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("last")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canLast(): boolean {
        return this.client.HasLink("last");
    }

    public linkForLast(): hal.HalLink {
        return this.client.GetLink("last");
    }

    public getLastDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}

export class ButtonStateResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: ButtonState = undefined;
    public get data(): ButtonState {
        this.strongData = this.strongData || this.client.GetData<ButtonState>();
        return this.strongData;
    }

    public refresh(): Promise<ButtonStateResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new ButtonStateResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public apply(): Promise<ButtonResult> {
        return this.client.LoadLink("Apply")
               .then(r => {
                    return new ButtonResult(r);
                });

    }

    public canApply(): boolean {
        return this.client.HasLink("Apply");
    }

    public linkForApply(): hal.HalLink {
        return this.client.GetLink("Apply");
    }

    public getApplyDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Apply", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasApplyDocs(): boolean {
        return this.client.HasLinkDoc("Apply");
    }
}

export class ButtonStateCollectionResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: ButtonStateCollection = undefined;
    public get data(): ButtonStateCollection {
        this.strongData = this.strongData || this.client.GetData<ButtonStateCollection>();
        return this.strongData;
    }

    private itemsStrong: ButtonStateResult[];
    public get items(): ButtonStateResult[] {
        if (this.itemsStrong === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.itemsStrong = [];
            for (var i = 0; i < clients.length; ++i) {
                this.itemsStrong.push(new ButtonStateResult(clients[i]));
            }
        }
        return this.itemsStrong;
    }

    public refresh(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public next(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("next")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canNext(): boolean {
        return this.client.HasLink("next");
    }

    public linkForNext(): hal.HalLink {
        return this.client.GetLink("next");
    }

    public getNextDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasNextDocs(): boolean {
        return this.client.HasLinkDoc("next");
    }

    public previous(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("previous")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canPrevious(): boolean {
        return this.client.HasLink("previous");
    }

    public linkForPrevious(): hal.HalLink {
        return this.client.GetLink("previous");
    }

    public getPreviousDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasPreviousDocs(): boolean {
        return this.client.HasLinkDoc("previous");
    }

    public first(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("first")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canFirst(): boolean {
        return this.client.HasLink("first");
    }

    public linkForFirst(): hal.HalLink {
        return this.client.GetLink("first");
    }

    public getFirstDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasFirstDocs(): boolean {
        return this.client.HasLinkDoc("first");
    }

    public last(): Promise<ButtonCollectionResult> {
        return this.client.LoadLink("last")
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canLast(): boolean {
        return this.client.HasLink("last");
    }

    public linkForLast(): hal.HalLink {
        return this.client.GetLink("last");
    }

    public getLastDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}

export class EntryPointInjector {
    private instancePromise: Promise<EntryPointResult>;

    constructor(private url: string, private fetcher: Fetcher, private data?: any) {}

    public load(): Promise<EntryPointResult> {
        if (!this.instancePromise) {
            if (this.data) {
                this.instancePromise = Promise.resolve(new EntryPointResult(new hal.HalEndpointClient(this.data, this.fetcher)));
            }
            else {
                this.instancePromise = EntryPointResult.Load(this.url, this.fetcher);
            }
        }
        return this.instancePromise;
    }
}

export class EntryPointResult {
    private client: hal.HalEndpointClient;

    public static Load(url: string, fetcher: Fetcher): Promise<EntryPointResult> {
        return hal.HalEndpointClient.Load({
            href: url,
            method: "GET"
        }, fetcher)
            .then(c => {
                 return new EntryPointResult(c);
             });
            }

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: EntryPoint = undefined;
    public get data(): EntryPoint {
        this.strongData = this.strongData || this.client.GetData<EntryPoint>();
        return this.strongData;
    }

    public listButtons(data: ButtonQuery): Promise<ButtonCollectionResult> {
        return this.client.LoadLinkWithData("ListButtons", data)
               .then(r => {
                    return new ButtonCollectionResult(r);
                });

    }

    public canListButtons(): boolean {
        return this.client.HasLink("ListButtons");
    }

    public linkForListButtons(): hal.HalLink {
        return this.client.GetLink("ListButtons");
    }

    public getListButtonsDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListButtons", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListButtonsDocs(): boolean {
        return this.client.HasLinkDoc("ListButtons");
    }

    public addButton(data: ButtonInput): Promise<ButtonResult> {
        return this.client.LoadLinkWithData("AddButton", data)
               .then(r => {
                    return new ButtonResult(r);
                });

    }

    public canAddButton(): boolean {
        return this.client.HasLink("AddButton");
    }

    public linkForAddButton(): hal.HalLink {
        return this.client.GetLink("AddButton");
    }

    public getAddButtonDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("AddButton", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasAddButtonDocs(): boolean {
        return this.client.HasLinkDoc("AddButton");
    }

    public refresh(): Promise<EntryPointResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new EntryPointResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getUser(): Promise<RoleAssignmentsResult> {
        return this.client.LoadLink("GetUser")
               .then(r => {
                    return new RoleAssignmentsResult(r);
                });

    }

    public canGetUser(): boolean {
        return this.client.HasLink("GetUser");
    }

    public linkForGetUser(): hal.HalLink {
        return this.client.GetLink("GetUser");
    }

    public getGetUserDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("GetUser", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetUserDocs(): boolean {
        return this.client.HasLinkDoc("GetUser");
    }

    public listUsers(data: RolesQuery): Promise<UserCollectionResult> {
        return this.client.LoadLinkWithData("ListUsers", data)
               .then(r => {
                    return new UserCollectionResult(r);
                });

    }

    public canListUsers(): boolean {
        return this.client.HasLink("ListUsers");
    }

    public linkForListUsers(): hal.HalLink {
        return this.client.GetLink("ListUsers");
    }

    public getListUsersDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListUsers", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListUsersDocs(): boolean {
        return this.client.HasLinkDoc("ListUsers");
    }

    public setUser(data: RoleAssignments): Promise<RoleAssignmentsResult> {
        return this.client.LoadLinkWithData("SetUser", data)
               .then(r => {
                    return new RoleAssignmentsResult(r);
                });

    }

    public canSetUser(): boolean {
        return this.client.HasLink("SetUser");
    }

    public linkForSetUser(): hal.HalLink {
        return this.client.GetLink("SetUser");
    }

    public getSetUserDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("SetUser", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasSetUserDocs(): boolean {
        return this.client.HasLinkDoc("SetUser");
    }

    public addNewSwitches(): Promise<void> {
        return this.client.LoadLink("AddNewSwitches").then(hal.makeVoid);
    }

    public canAddNewSwitches(): boolean {
        return this.client.HasLink("AddNewSwitches");
    }

    public linkForAddNewSwitches(): hal.HalLink {
        return this.client.GetLink("AddNewSwitches");
    }

    public addNewSensors(): Promise<void> {
        return this.client.LoadLink("AddNewSensors").then(hal.makeVoid);
    }

    public canAddNewSensors(): boolean {
        return this.client.HasLink("AddNewSensors");
    }

    public linkForAddNewSensors(): hal.HalLink {
        return this.client.GetLink("AddNewSensors");
    }

    public addNewThermostats(): Promise<void> {
        return this.client.LoadLink("AddNewThermostats").then(hal.makeVoid);
    }

    public canAddNewThermostats(): boolean {
        return this.client.HasLink("AddNewThermostats");
    }

    public linkForAddNewThermostats(): hal.HalLink {
        return this.client.GetLink("AddNewThermostats");
    }

    public listAppUsers(data: UserSearchQuery): Promise<UserSearchCollectionResult> {
        return this.client.LoadLinkWithData("ListAppUsers", data)
               .then(r => {
                    return new UserSearchCollectionResult(r);
                });

    }

    public canListAppUsers(): boolean {
        return this.client.HasLink("ListAppUsers");
    }

    public linkForListAppUsers(): hal.HalLink {
        return this.client.GetLink("ListAppUsers");
    }

    public getListAppUsersDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListAppUsers", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListAppUsersDocs(): boolean {
        return this.client.HasLinkDoc("ListAppUsers");
    }

    public listButtonStates(data: ButtonStateQuery): Promise<ButtonStateCollectionResult> {
        return this.client.LoadLinkWithData("ListButtonStates", data)
               .then(r => {
                    return new ButtonStateCollectionResult(r);
                });

    }

    public canListButtonStates(): boolean {
        return this.client.HasLink("ListButtonStates");
    }

    public linkForListButtonStates(): hal.HalLink {
        return this.client.GetLink("ListButtonStates");
    }

    public getListButtonStatesDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListButtonStates", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListButtonStatesDocs(): boolean {
        return this.client.HasLinkDoc("ListButtonStates");
    }

    public listAppCommands(data: AppCommandQuery): Promise<AppCommandCollectionResult> {
        return this.client.LoadLinkWithData("ListAppCommands", data)
               .then(r => {
                    return new AppCommandCollectionResult(r);
                });

    }

    public canListAppCommands(): boolean {
        return this.client.HasLink("ListAppCommands");
    }

    public linkForListAppCommands(): hal.HalLink {
        return this.client.GetLink("ListAppCommands");
    }

    public getListAppCommandsDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListAppCommands", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListAppCommandsDocs(): boolean {
        return this.client.HasLinkDoc("ListAppCommands");
    }

    public listSensors(data: SensorQuery): Promise<SensorCollectionResult> {
        return this.client.LoadLinkWithData("ListSensors", data)
               .then(r => {
                    return new SensorCollectionResult(r);
                });

    }

    public canListSensors(): boolean {
        return this.client.HasLink("ListSensors");
    }

    public linkForListSensors(): hal.HalLink {
        return this.client.GetLink("ListSensors");
    }

    public getListSensorsDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListSensors", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListSensorsDocs(): boolean {
        return this.client.HasLinkDoc("ListSensors");
    }

    public listSwitches(data: SwitchQuery): Promise<SwitchCollectionResult> {
        return this.client.LoadLinkWithData("ListSwitches", data)
               .then(r => {
                    return new SwitchCollectionResult(r);
                });

    }

    public canListSwitches(): boolean {
        return this.client.HasLink("ListSwitches");
    }

    public linkForListSwitches(): hal.HalLink {
        return this.client.GetLink("ListSwitches");
    }

    public getListSwitchesDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListSwitches", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListSwitchesDocs(): boolean {
        return this.client.HasLinkDoc("ListSwitches");
    }

    public listThermostats(data: ThermostatQuery): Promise<ThermostatCollectionResult> {
        return this.client.LoadLinkWithData("ListThermostats", data)
               .then(r => {
                    return new ThermostatCollectionResult(r);
                });

    }

    public canListThermostats(): boolean {
        return this.client.HasLink("ListThermostats");
    }

    public linkForListThermostats(): hal.HalLink {
        return this.client.GetLink("ListThermostats");
    }

    public getListThermostatsDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListThermostats", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListThermostatsDocs(): boolean {
        return this.client.HasLinkDoc("ListThermostats");
    }

    public listThermostatSettings(data: ThermostatSettingQuery): Promise<ThermostatSettingCollectionResult> {
        return this.client.LoadLinkWithData("ListThermostatSettings", data)
               .then(r => {
                    return new ThermostatSettingCollectionResult(r);
                });

    }

    public canListThermostatSettings(): boolean {
        return this.client.HasLink("ListThermostatSettings");
    }

    public linkForListThermostatSettings(): hal.HalLink {
        return this.client.GetLink("ListThermostatSettings");
    }

    public getListThermostatSettingsDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListThermostatSettings", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListThermostatSettingsDocs(): boolean {
        return this.client.HasLinkDoc("ListThermostatSettings");
    }

    public addThermostatSetting(data: ThermostatSettingInput): Promise<ThermostatSettingResult> {
        return this.client.LoadLinkWithData("AddThermostatSetting", data)
               .then(r => {
                    return new ThermostatSettingResult(r);
                });

    }

    public canAddThermostatSetting(): boolean {
        return this.client.HasLink("AddThermostatSetting");
    }

    public linkForAddThermostatSetting(): hal.HalLink {
        return this.client.GetLink("AddThermostatSetting");
    }

    public getAddThermostatSettingDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("AddThermostatSetting", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasAddThermostatSettingDocs(): boolean {
        return this.client.HasLinkDoc("AddThermostatSetting");
    }
}

export class SensorResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: Sensor = undefined;
    public get data(): Sensor {
        this.strongData = this.strongData || this.client.GetData<Sensor>();
        return this.strongData;
    }

    public refresh(): Promise<SensorResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new SensorResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public update(data: SensorInput): Promise<SensorResult> {
        return this.client.LoadLinkWithData("Update", data)
               .then(r => {
                    return new SensorResult(r);
                });

    }

    public canUpdate(): boolean {
        return this.client.HasLink("Update");
    }

    public linkForUpdate(): hal.HalLink {
        return this.client.GetLink("Update");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }
}

export class SensorCollectionResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: SensorCollection = undefined;
    public get data(): SensorCollection {
        this.strongData = this.strongData || this.client.GetData<SensorCollection>();
        return this.strongData;
    }

    private itemsStrong: SensorResult[];
    public get items(): SensorResult[] {
        if (this.itemsStrong === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.itemsStrong = [];
            for (var i = 0; i < clients.length; ++i) {
                this.itemsStrong.push(new SensorResult(clients[i]));
            }
        }
        return this.itemsStrong;
    }

    public refresh(): Promise<SensorCollectionResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new SensorCollectionResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public next(): Promise<SensorCollectionResult> {
        return this.client.LoadLink("next")
               .then(r => {
                    return new SensorCollectionResult(r);
                });

    }

    public canNext(): boolean {
        return this.client.HasLink("next");
    }

    public linkForNext(): hal.HalLink {
        return this.client.GetLink("next");
    }

    public getNextDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasNextDocs(): boolean {
        return this.client.HasLinkDoc("next");
    }

    public previous(): Promise<SensorCollectionResult> {
        return this.client.LoadLink("previous")
               .then(r => {
                    return new SensorCollectionResult(r);
                });

    }

    public canPrevious(): boolean {
        return this.client.HasLink("previous");
    }

    public linkForPrevious(): hal.HalLink {
        return this.client.GetLink("previous");
    }

    public getPreviousDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasPreviousDocs(): boolean {
        return this.client.HasLinkDoc("previous");
    }

    public first(): Promise<SensorCollectionResult> {
        return this.client.LoadLink("first")
               .then(r => {
                    return new SensorCollectionResult(r);
                });

    }

    public canFirst(): boolean {
        return this.client.HasLink("first");
    }

    public linkForFirst(): hal.HalLink {
        return this.client.GetLink("first");
    }

    public getFirstDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasFirstDocs(): boolean {
        return this.client.HasLinkDoc("first");
    }

    public last(): Promise<SensorCollectionResult> {
        return this.client.LoadLink("last")
               .then(r => {
                    return new SensorCollectionResult(r);
                });

    }

    public canLast(): boolean {
        return this.client.HasLink("last");
    }

    public linkForLast(): hal.HalLink {
        return this.client.GetLink("last");
    }

    public getLastDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}

export class SwitchResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: Switch = undefined;
    public get data(): Switch {
        this.strongData = this.strongData || this.client.GetData<Switch>();
        return this.strongData;
    }

    public refresh(): Promise<SwitchResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new SwitchResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public update(data: SwitchInput): Promise<SwitchResult> {
        return this.client.LoadLinkWithData("Update", data)
               .then(r => {
                    return new SwitchResult(r);
                });

    }

    public canUpdate(): boolean {
        return this.client.HasLink("Update");
    }

    public linkForUpdate(): hal.HalLink {
        return this.client.GetLink("Update");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public set(data: SetSwitchInput): Promise<SwitchResult> {
        return this.client.LoadLinkWithData("Set", data)
               .then(r => {
                    return new SwitchResult(r);
                });

    }

    public canSet(): boolean {
        return this.client.HasLink("Set");
    }

    public linkForSet(): hal.HalLink {
        return this.client.GetLink("Set");
    }

    public getSetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Set", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasSetDocs(): boolean {
        return this.client.HasLinkDoc("Set");
    }

    public delete(): Promise<void> {
        return this.client.LoadLink("Delete").then(hal.makeVoid);
    }

    public canDelete(): boolean {
        return this.client.HasLink("Delete");
    }

    public linkForDelete(): hal.HalLink {
        return this.client.GetLink("Delete");
    }
}

export class SwitchCollectionResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: SwitchCollection = undefined;
    public get data(): SwitchCollection {
        this.strongData = this.strongData || this.client.GetData<SwitchCollection>();
        return this.strongData;
    }

    private itemsStrong: SwitchResult[];
    public get items(): SwitchResult[] {
        if (this.itemsStrong === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.itemsStrong = [];
            for (var i = 0; i < clients.length; ++i) {
                this.itemsStrong.push(new SwitchResult(clients[i]));
            }
        }
        return this.itemsStrong;
    }

    public refresh(): Promise<SwitchCollectionResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new SwitchCollectionResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public next(): Promise<SwitchCollectionResult> {
        return this.client.LoadLink("next")
               .then(r => {
                    return new SwitchCollectionResult(r);
                });

    }

    public canNext(): boolean {
        return this.client.HasLink("next");
    }

    public linkForNext(): hal.HalLink {
        return this.client.GetLink("next");
    }

    public getNextDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasNextDocs(): boolean {
        return this.client.HasLinkDoc("next");
    }

    public previous(): Promise<SwitchCollectionResult> {
        return this.client.LoadLink("previous")
               .then(r => {
                    return new SwitchCollectionResult(r);
                });

    }

    public canPrevious(): boolean {
        return this.client.HasLink("previous");
    }

    public linkForPrevious(): hal.HalLink {
        return this.client.GetLink("previous");
    }

    public getPreviousDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasPreviousDocs(): boolean {
        return this.client.HasLinkDoc("previous");
    }

    public first(): Promise<SwitchCollectionResult> {
        return this.client.LoadLink("first")
               .then(r => {
                    return new SwitchCollectionResult(r);
                });

    }

    public canFirst(): boolean {
        return this.client.HasLink("first");
    }

    public linkForFirst(): hal.HalLink {
        return this.client.GetLink("first");
    }

    public getFirstDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasFirstDocs(): boolean {
        return this.client.HasLinkDoc("first");
    }

    public last(): Promise<SwitchCollectionResult> {
        return this.client.LoadLink("last")
               .then(r => {
                    return new SwitchCollectionResult(r);
                });

    }

    public canLast(): boolean {
        return this.client.HasLink("last");
    }

    public linkForLast(): hal.HalLink {
        return this.client.GetLink("last");
    }

    public getLastDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}

export class ThermostatResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: Thermostat = undefined;
    public get data(): Thermostat {
        this.strongData = this.strongData || this.client.GetData<Thermostat>();
        return this.strongData;
    }

    public refresh(): Promise<ThermostatResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new ThermostatResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public update(data: ThermostatInput): Promise<ThermostatResult> {
        return this.client.LoadLinkWithData("Update", data)
               .then(r => {
                    return new ThermostatResult(r);
                });

    }

    public canUpdate(): boolean {
        return this.client.HasLink("Update");
    }

    public linkForUpdate(): hal.HalLink {
        return this.client.GetLink("Update");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public setTemp(data: ThermostatTempInput): Promise<ThermostatResult> {
        return this.client.LoadLinkWithData("SetTemp", data)
               .then(r => {
                    return new ThermostatResult(r);
                });

    }

    public canSetTemp(): boolean {
        return this.client.HasLink("SetTemp");
    }

    public linkForSetTemp(): hal.HalLink {
        return this.client.GetLink("SetTemp");
    }

    public getSetTempDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("SetTemp", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasSetTempDocs(): boolean {
        return this.client.HasLinkDoc("SetTemp");
    }

    public getSettings(): Promise<ThermostatSettingCollectionResult> {
        return this.client.LoadLink("GetSettings")
               .then(r => {
                    return new ThermostatSettingCollectionResult(r);
                });

    }

    public canGetSettings(): boolean {
        return this.client.HasLink("GetSettings");
    }

    public linkForGetSettings(): hal.HalLink {
        return this.client.GetLink("GetSettings");
    }

    public getGetSettingsDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("GetSettings", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetSettingsDocs(): boolean {
        return this.client.HasLinkDoc("GetSettings");
    }
}

export class ThermostatCollectionResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: ThermostatCollection = undefined;
    public get data(): ThermostatCollection {
        this.strongData = this.strongData || this.client.GetData<ThermostatCollection>();
        return this.strongData;
    }

    private itemsStrong: ThermostatResult[];
    public get items(): ThermostatResult[] {
        if (this.itemsStrong === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.itemsStrong = [];
            for (var i = 0; i < clients.length; ++i) {
                this.itemsStrong.push(new ThermostatResult(clients[i]));
            }
        }
        return this.itemsStrong;
    }

    public refresh(): Promise<ThermostatCollectionResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new ThermostatCollectionResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public next(): Promise<ThermostatCollectionResult> {
        return this.client.LoadLink("next")
               .then(r => {
                    return new ThermostatCollectionResult(r);
                });

    }

    public canNext(): boolean {
        return this.client.HasLink("next");
    }

    public linkForNext(): hal.HalLink {
        return this.client.GetLink("next");
    }

    public getNextDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasNextDocs(): boolean {
        return this.client.HasLinkDoc("next");
    }

    public previous(): Promise<ThermostatCollectionResult> {
        return this.client.LoadLink("previous")
               .then(r => {
                    return new ThermostatCollectionResult(r);
                });

    }

    public canPrevious(): boolean {
        return this.client.HasLink("previous");
    }

    public linkForPrevious(): hal.HalLink {
        return this.client.GetLink("previous");
    }

    public getPreviousDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasPreviousDocs(): boolean {
        return this.client.HasLinkDoc("previous");
    }

    public first(): Promise<ThermostatCollectionResult> {
        return this.client.LoadLink("first")
               .then(r => {
                    return new ThermostatCollectionResult(r);
                });

    }

    public canFirst(): boolean {
        return this.client.HasLink("first");
    }

    public linkForFirst(): hal.HalLink {
        return this.client.GetLink("first");
    }

    public getFirstDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasFirstDocs(): boolean {
        return this.client.HasLinkDoc("first");
    }

    public last(): Promise<ThermostatCollectionResult> {
        return this.client.LoadLink("last")
               .then(r => {
                    return new ThermostatCollectionResult(r);
                });

    }

    public canLast(): boolean {
        return this.client.HasLink("last");
    }

    public linkForLast(): hal.HalLink {
        return this.client.GetLink("last");
    }

    public getLastDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}

export class ThermostatSettingResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: ThermostatSetting = undefined;
    public get data(): ThermostatSetting {
        this.strongData = this.strongData || this.client.GetData<ThermostatSetting>();
        return this.strongData;
    }

    public refresh(): Promise<ThermostatSettingResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new ThermostatSettingResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public update(data: ThermostatSettingInput): Promise<ThermostatSettingResult> {
        return this.client.LoadLinkWithData("Update", data)
               .then(r => {
                    return new ThermostatSettingResult(r);
                });

    }

    public canUpdate(): boolean {
        return this.client.HasLink("Update");
    }

    public linkForUpdate(): hal.HalLink {
        return this.client.GetLink("Update");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public delete(): Promise<void> {
        return this.client.LoadLink("Delete").then(hal.makeVoid);
    }

    public canDelete(): boolean {
        return this.client.HasLink("Delete");
    }

    public linkForDelete(): hal.HalLink {
        return this.client.GetLink("Delete");
    }

    public applySetting(): Promise<ThermostatResult> {
        return this.client.LoadLink("ApplySetting")
               .then(r => {
                    return new ThermostatResult(r);
                });

    }

    public canApplySetting(): boolean {
        return this.client.HasLink("ApplySetting");
    }

    public linkForApplySetting(): hal.HalLink {
        return this.client.GetLink("ApplySetting");
    }

    public getApplySettingDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ApplySetting", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasApplySettingDocs(): boolean {
        return this.client.HasLinkDoc("ApplySetting");
    }
}

export class ThermostatSettingCollectionResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: ThermostatSettingCollection = undefined;
    public get data(): ThermostatSettingCollection {
        this.strongData = this.strongData || this.client.GetData<ThermostatSettingCollection>();
        return this.strongData;
    }

    private itemsStrong: ThermostatSettingResult[];
    public get items(): ThermostatSettingResult[] {
        if (this.itemsStrong === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.itemsStrong = [];
            for (var i = 0; i < clients.length; ++i) {
                this.itemsStrong.push(new ThermostatSettingResult(clients[i]));
            }
        }
        return this.itemsStrong;
    }

    public refresh(): Promise<ThermostatSettingCollectionResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new ThermostatSettingCollectionResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public add(data: ThermostatSettingInput): Promise<ThermostatSettingResult> {
        return this.client.LoadLinkWithData("Add", data)
               .then(r => {
                    return new ThermostatSettingResult(r);
                });

    }

    public canAdd(): boolean {
        return this.client.HasLink("Add");
    }

    public linkForAdd(): hal.HalLink {
        return this.client.GetLink("Add");
    }

    public getAddDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Add", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasAddDocs(): boolean {
        return this.client.HasLinkDoc("Add");
    }

    public next(): Promise<ThermostatSettingCollectionResult> {
        return this.client.LoadLink("next")
               .then(r => {
                    return new ThermostatSettingCollectionResult(r);
                });

    }

    public canNext(): boolean {
        return this.client.HasLink("next");
    }

    public linkForNext(): hal.HalLink {
        return this.client.GetLink("next");
    }

    public getNextDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasNextDocs(): boolean {
        return this.client.HasLinkDoc("next");
    }

    public previous(): Promise<ThermostatSettingCollectionResult> {
        return this.client.LoadLink("previous")
               .then(r => {
                    return new ThermostatSettingCollectionResult(r);
                });

    }

    public canPrevious(): boolean {
        return this.client.HasLink("previous");
    }

    public linkForPrevious(): hal.HalLink {
        return this.client.GetLink("previous");
    }

    public getPreviousDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasPreviousDocs(): boolean {
        return this.client.HasLinkDoc("previous");
    }

    public first(): Promise<ThermostatSettingCollectionResult> {
        return this.client.LoadLink("first")
               .then(r => {
                    return new ThermostatSettingCollectionResult(r);
                });

    }

    public canFirst(): boolean {
        return this.client.HasLink("first");
    }

    public linkForFirst(): hal.HalLink {
        return this.client.GetLink("first");
    }

    public getFirstDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasFirstDocs(): boolean {
        return this.client.HasLinkDoc("first");
    }

    public last(): Promise<ThermostatSettingCollectionResult> {
        return this.client.LoadLink("last")
               .then(r => {
                    return new ThermostatSettingCollectionResult(r);
                });

    }

    public canLast(): boolean {
        return this.client.HasLink("last");
    }

    public linkForLast(): hal.HalLink {
        return this.client.GetLink("last");
    }

    public getLastDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}

export class UserCollectionResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: UserCollection = undefined;
    public get data(): UserCollection {
        this.strongData = this.strongData || this.client.GetData<UserCollection>();
        return this.strongData;
    }

    private itemsStrong: RoleAssignmentsResult[];
    public get items(): RoleAssignmentsResult[] {
        if (this.itemsStrong === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.itemsStrong = [];
            for (var i = 0; i < clients.length; ++i) {
                this.itemsStrong.push(new RoleAssignmentsResult(clients[i]));
            }
        }
        return this.itemsStrong;
    }

    public refresh(): Promise<UserCollectionResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new UserCollectionResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
    }

    public add(data: RoleAssignments): Promise<RoleAssignmentsResult> {
        return this.client.LoadLinkWithData("Add", data)
               .then(r => {
                    return new RoleAssignmentsResult(r);
                });

    }

    public canAdd(): boolean {
        return this.client.HasLink("Add");
    }

    public linkForAdd(): hal.HalLink {
        return this.client.GetLink("Add");
    }

    public getAddDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Add", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasAddDocs(): boolean {
        return this.client.HasLinkDoc("Add");
    }

    public next(): Promise<UserCollectionResult> {
        return this.client.LoadLink("next")
               .then(r => {
                    return new UserCollectionResult(r);
                });

    }

    public canNext(): boolean {
        return this.client.HasLink("next");
    }

    public linkForNext(): hal.HalLink {
        return this.client.GetLink("next");
    }

    public getNextDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasNextDocs(): boolean {
        return this.client.HasLinkDoc("next");
    }

    public previous(): Promise<UserCollectionResult> {
        return this.client.LoadLink("previous")
               .then(r => {
                    return new UserCollectionResult(r);
                });

    }

    public canPrevious(): boolean {
        return this.client.HasLink("previous");
    }

    public linkForPrevious(): hal.HalLink {
        return this.client.GetLink("previous");
    }

    public getPreviousDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasPreviousDocs(): boolean {
        return this.client.HasLinkDoc("previous");
    }

    public first(): Promise<UserCollectionResult> {
        return this.client.LoadLink("first")
               .then(r => {
                    return new UserCollectionResult(r);
                });

    }

    public canFirst(): boolean {
        return this.client.HasLink("first");
    }

    public linkForFirst(): hal.HalLink {
        return this.client.GetLink("first");
    }

    public getFirstDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasFirstDocs(): boolean {
        return this.client.HasLinkDoc("first");
    }

    public last(): Promise<UserCollectionResult> {
        return this.client.LoadLink("last")
               .then(r => {
                    return new UserCollectionResult(r);
                });

    }

    public canLast(): boolean {
        return this.client.HasLink("last");
    }

    public linkForLast(): hal.HalLink {
        return this.client.GetLink("last");
    }

    public getLastDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}

export class UserSearchResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: UserSearch = undefined;
    public get data(): UserSearch {
        this.strongData = this.strongData || this.client.GetData<UserSearch>();
        return this.strongData;
    }

    public refresh(): Promise<UserSearchResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new UserSearchResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }
}

export class UserSearchCollectionResult {
    private client: hal.HalEndpointClient;

    constructor(client: hal.HalEndpointClient) {
        this.client = client;
    }

    private strongData: UserSearchCollection = undefined;
    public get data(): UserSearchCollection {
        this.strongData = this.strongData || this.client.GetData<UserSearchCollection>();
        return this.strongData;
    }

    private itemsStrong: UserSearchResult[];
    public get items(): UserSearchResult[] {
        if (this.itemsStrong === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.itemsStrong = [];
            for (var i = 0; i < clients.length; ++i) {
                this.itemsStrong.push(new UserSearchResult(clients[i]));
            }
        }
        return this.itemsStrong;
    }

    public refresh(): Promise<UserSearchCollectionResult> {
        return this.client.LoadLink("self")
               .then(r => {
                    return new UserSearchCollectionResult(r);
                });

    }

    public canRefresh(): boolean {
        return this.client.HasLink("self");
    }

    public linkForRefresh(): hal.HalLink {
        return this.client.GetLink("self");
    }

    public getRefreshDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public next(): Promise<UserSearchCollectionResult> {
        return this.client.LoadLink("next")
               .then(r => {
                    return new UserSearchCollectionResult(r);
                });

    }

    public canNext(): boolean {
        return this.client.HasLink("next");
    }

    public linkForNext(): hal.HalLink {
        return this.client.GetLink("next");
    }

    public getNextDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasNextDocs(): boolean {
        return this.client.HasLinkDoc("next");
    }

    public previous(): Promise<UserSearchCollectionResult> {
        return this.client.LoadLink("previous")
               .then(r => {
                    return new UserSearchCollectionResult(r);
                });

    }

    public canPrevious(): boolean {
        return this.client.HasLink("previous");
    }

    public linkForPrevious(): hal.HalLink {
        return this.client.GetLink("previous");
    }

    public getPreviousDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasPreviousDocs(): boolean {
        return this.client.HasLinkDoc("previous");
    }

    public first(): Promise<UserSearchCollectionResult> {
        return this.client.LoadLink("first")
               .then(r => {
                    return new UserSearchCollectionResult(r);
                });

    }

    public canFirst(): boolean {
        return this.client.HasLink("first");
    }

    public linkForFirst(): hal.HalLink {
        return this.client.GetLink("first");
    }

    public getFirstDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasFirstDocs(): boolean {
        return this.client.HasLinkDoc("first");
    }

    public last(): Promise<UserSearchCollectionResult> {
        return this.client.LoadLink("last")
               .then(r => {
                    return new UserSearchCollectionResult(r);
                });

    }

    public canLast(): boolean {
        return this.client.HasLink("last");
    }

    public linkForLast(): hal.HalLink {
        return this.client.GetLink("last");
    }

    public getLastDocs(query?: HalEndpointDocQuery): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last", query)
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v1.0.1.0 (Newtonsoft.Json v12.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------





export interface RoleAssignments {
    editButtons?: boolean;
    editSensors?: boolean;
    editSwitches?: boolean;
    editThermostats?: boolean;
    editThermostatSettings?: boolean;
    userId?: string;
    name?: string;
    editRoles?: boolean;
    superAdmin?: boolean;
}

export interface AppCommand {
    appCommandId?: string;
    name?: string;
}

export interface AppCommandCollection {
    offset?: number;
    /** Lookup a buttonState by id. */
    appCommandId?: string;
    total?: number;
    limit?: number;
}

export interface AppCommandQuery {
    /** Lookup a buttonState by id. */
    appCommandId?: string;
    offset?: number;
    limit?: number;
}

export enum ButtonStateIcon {
    Unknown = <any>"Unknown", 
    BulbOff = <any>"BulbOff", 
    BulbOn = <any>"BulbOn", 
    FanOff = <any>"FanOff", 
    FanLow = <any>"FanLow", 
    FanMedium = <any>"FanMedium", 
    FanHigh = <any>"FanHigh", 
}

export enum ButtonType {
    Light = <any>"Light", 
    Fan = <any>"Fan", 
}

export interface ButtonState {
    buttonStateId?: string;
    label?: string;
    icon?: ButtonStateIcon;
    order?: number;
    created?: string;
    modified?: string;
    switchSettings?: SwitchSetting[];
}

export interface SwitchSetting {
    switchSettingId?: string;
    switchId?: string;
    value?: string;
    brightness?: number;
    hexColor?: string;
    created?: string;
    modified?: string;
    switch?: Switch;
}

export interface Switch {
    switchId?: string;
    name?: string;
    value?: string;
    hexColor?: string;
    created?: string;
    modified?: string;
    brightness?: number;
}

export interface Button {
    buttonId?: string;
    label?: string;
    currentIcon?: ButtonStateIcon;
    order?: number;
    buttonType?: ButtonType;
    created?: string;
    modified?: string;
    buttonStates?: ButtonState[];
}

export interface ButtonStateInput {
    label?: string;
    icon?: ButtonStateIcon;
    order?: number;
    switchSettings?: SwitchSettingInput[];
}

export interface SwitchSettingInput {
    switchId?: string;
    value?: string;
    brightness?: number;
    hexColor?: string;
}

export interface ButtonInput {
    label?: string;
    order?: number;
    buttonType?: ButtonType;
    buttonStates?: ButtonStateInput[];
}

export interface ApplyButtonInput {
    buttonStateId?: string;
}

export interface ButtonCollection {
    includeButler?: boolean;
    /** Lookup a button by id. */
    buttonId?: string;
    total?: number;
    offset?: number;
    limit?: number;
}

export interface ButtonQuery {
    /** Lookup a button by id. */
    buttonId?: string;
    includeButler?: boolean;
    offset?: number;
    limit?: number;
}

export interface ButtonStateCollection {
    offset?: number;
    /** Lookup a buttonState by id. */
    buttonStateId?: string;
    total?: number;
    limit?: number;
}

export interface EntryPoint {
}

export interface RolesQuery {
    userId?: string[];
    name?: string;
    editRoles?: boolean;
    superAdmin?: boolean;
    offset?: number;
    limit?: number;
}

export interface UserCollection {
    name?: string;
    userId?: string[];
    total?: number;
    editRoles?: boolean;
    superAdmin?: boolean;
    offset?: number;
    limit?: number;
}

export interface UserSearchQuery {
    userId?: string;
    userName?: string;
    offset?: number;
    limit?: number;
}

export interface UserSearchCollection {
    userName?: string;
    userId?: string;
    total?: number;
    offset?: number;
    limit?: number;
}

export interface ButtonStateQuery {
    /** Lookup a buttonState by id. */
    buttonStateId?: string;
    offset?: number;
    limit?: number;
}

export interface SensorQuery {
    /** Lookup a sensor by id. */
    sensorId?: string;
    offset?: number;
    limit?: number;
}

export interface SensorCollection {
    offset?: number;
    /** Lookup a sensor by id. */
    sensorId?: string;
    total?: number;
    limit?: number;
}

export interface SwitchQuery {
    switchIds?: string[];
    /** Get the current status of the switches in the query results. 
Will take longer while the switch info is loaded. */
    getStatus?: boolean;
    /** Lookup a @switch by id. */
    switchId?: string;
    offset?: number;
    limit?: number;
}

export interface SwitchCollection {
    /** Get the current status of the switches in the query results. 
Will take longer while the switch info is loaded. */
    getStatus?: boolean;
    switchIds?: string[];
    total?: number;
    /** Lookup a @switch by id. */
    switchId?: string;
    offset?: number;
    limit?: number;
}

export interface ThermostatQuery {
    /** Lookup a thermostat by id. */
    thermostatId?: string;
    offset?: number;
    limit?: number;
}

export interface ThermostatCollection {
    offset?: number;
    /** Lookup a thermostat by id. */
    thermostatId?: string;
    total?: number;
    limit?: number;
}

export interface ThermostatSettingQuery {
    /** Lookup a thermostatSetting by id. */
    thermostatSettingId?: string;
    thermostatId?: string;
    offset?: number;
    limit?: number;
}

export interface ThermostatSettingCollection {
    thermostatId?: string;
    /** Lookup a thermostatSetting by id. */
    thermostatSettingId?: string;
    total?: number;
    offset?: number;
    limit?: number;
}

export interface ThermostatSettingInput {
    label?: string;
    order?: number;
    coolTemp?: number;
    heatTemp?: number;
    on?: boolean;
    thermostatId?: string;
}

export interface ThermostatSetting {
    thermostatSettingId?: string;
    label?: string;
    order?: number;
    coolTemp?: number;
    heatTemp?: number;
    on?: boolean;
    thermostatId?: string;
    created?: string;
    modified?: string;
}

export enum Units {
    None = <any>"None", 
    Fahrenheit = <any>"Fahrenheit", 
    Celsius = <any>"Celsius", 
    Lux = <any>"Lux", 
    Percent = <any>"Percent", 
}

export interface Sensor {
    sensorId?: string;
    name?: string;
    subsystem?: string;
    bridge?: string;
    id?: string;
    tempValue?: number;
    tempUnits?: SensorTempUnits;
    lightValue?: number;
    lightUnits?: SensorLightUnits;
    humidityValue?: number;
    humidityUnits?: SensorHumidityUnits;
    uvValue?: number;
    uvUnits?: SensorUvUnits;
    created?: string;
    modified?: string;
}

export enum SensorTempUnits {
    None = <any>"None", 
    Fahrenheit = <any>"Fahrenheit", 
    Celsius = <any>"Celsius", 
    Lux = <any>"Lux", 
    Percent = <any>"Percent", 
}

export enum SensorLightUnits {
    None = <any>"None", 
    Fahrenheit = <any>"Fahrenheit", 
    Celsius = <any>"Celsius", 
    Lux = <any>"Lux", 
    Percent = <any>"Percent", 
}

export enum SensorHumidityUnits {
    None = <any>"None", 
    Fahrenheit = <any>"Fahrenheit", 
    Celsius = <any>"Celsius", 
    Lux = <any>"Lux", 
    Percent = <any>"Percent", 
}

export enum SensorUvUnits {
    None = <any>"None", 
    Fahrenheit = <any>"Fahrenheit", 
    Celsius = <any>"Celsius", 
    Lux = <any>"Lux", 
    Percent = <any>"Percent", 
}

export interface SensorInput {
    name?: string;
    subsystem?: string;
    bridge?: string;
    id?: string;
    tempValue?: number;
    tempUnits?: SensorInputTempUnits;
    lightValue?: number;
    lightUnits?: SensorInputLightUnits;
    humidityValue?: number;
    humidityUnits?: SensorInputHumidityUnits;
    uvValue?: number;
    uvUnits?: SensorInputUvUnits;
}

export enum SensorInputTempUnits {
    None = <any>"None", 
    Fahrenheit = <any>"Fahrenheit", 
    Celsius = <any>"Celsius", 
    Lux = <any>"Lux", 
    Percent = <any>"Percent", 
}

export enum SensorInputLightUnits {
    None = <any>"None", 
    Fahrenheit = <any>"Fahrenheit", 
    Celsius = <any>"Celsius", 
    Lux = <any>"Lux", 
    Percent = <any>"Percent", 
}

export enum SensorInputHumidityUnits {
    None = <any>"None", 
    Fahrenheit = <any>"Fahrenheit", 
    Celsius = <any>"Celsius", 
    Lux = <any>"Lux", 
    Percent = <any>"Percent", 
}

export enum SensorInputUvUnits {
    None = <any>"None", 
    Fahrenheit = <any>"Fahrenheit", 
    Celsius = <any>"Celsius", 
    Lux = <any>"Lux", 
    Percent = <any>"Percent", 
}

export interface SwitchInput {
    name?: string;
    value?: string;
    hexColor?: string;
    brightness?: number;
}

export interface SetSwitchInput {
    value?: string;
    brightness?: number;
    hexColor?: string;
}

export enum Mode {
    Off = <any>"Off", 
    Heat = <any>"Heat", 
    Cool = <any>"Cool", 
    Auto = <any>"Auto", 
}

export enum FanSetting {
    Auto = <any>"Auto", 
    On = <any>"On", 
}

export enum State {
    Idle = <any>"Idle", 
    Heating = <any>"Heating", 
    Cooling = <any>"Cooling", 
    Lockout = <any>"Lockout", 
    Error = <any>"Error", 
}

export enum FanState {
    Off = <any>"Off", 
    On = <any>"On", 
}

export enum TempUnits {
    Farenheit = <any>"Farenheit", 
    Celsius = <any>"Celsius", 
}

export enum SchedulePart {
    Morning = <any>"Morning", 
    Day = <any>"Day", 
    Evening = <any>"Evening", 
    Night = <any>"Night", 
    Inactive = <any>"Inactive", 
}

export enum Away {
    Home = <any>"Home", 
    Away = <any>"Away", 
}

export enum Holiday {
    NotObservingHoliday = <any>"NotObservingHoliday", 
    ObservingHoliday = <any>"ObservingHoliday", 
}

export enum Override {
    Off = <any>"Off", 
    On = <any>"On", 
}

export enum ForceUnocc {
    Off = <any>"Off", 
    On = <any>"On", 
}

export enum AvailableModes {
    AllModes = <any>"AllModes", 
    HeatCoolOnly = <any>"HeatCoolOnly", 
    HeatOnly = <any>"HeatOnly", 
    CoolOnly = <any>"CoolOnly", 
}

export interface Thermostat {
    thermostatId?: string;
    name?: string;
    subsystem?: string;
    bridge?: string;
    id?: string;
    mode?: Mode;
    fan?: FanSetting;
    heatTemp?: number;
    coolTemp?: number;
    state?: State;
    fanState?: FanState;
    tempUnits?: TempUnits;
    schedule?: SchedulePart;
    schedulePart?: SchedulePart;
    away?: Away;
    holidy?: Holiday;
    override?: Override;
    overrideTime?: number;
    forceUnocc?: ForceUnocc;
    spaceTemp?: number;
    coolTempMin?: number;
    coolTempMax?: number;
    heatTempMin?: number;
    heatTempMax?: number;
    setPointDelta?: number;
    humidity?: number;
    availableModes?: AvailableModes;
    created?: string;
    modified?: string;
}

export interface ThermostatInput {
    name?: string;
    subsystem?: string;
    bridge?: string;
    id?: string;
    mode?: Mode;
    fan?: FanSetting;
    heatTemp?: number;
    coolTemp?: number;
}

export interface ThermostatTempInput {
    coolTemp?: number;
    heatTemp?: number;
}

export interface UserSearch {
    userId?: string;
    userName?: string;
}

export interface HalEndpointDocQuery {
    includeRequest?: boolean;
    includeResponse?: boolean;
}
