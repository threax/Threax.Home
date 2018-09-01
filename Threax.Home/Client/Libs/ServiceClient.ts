import * as hal from 'hr.halcyon.EndpointClient';

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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
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

    public getSetUserDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("SetUser")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasSetUserDocs(): boolean {
        return this.client.HasLinkDoc("SetUser");
    }

    public deleteUser(): Promise<void> {
        return this.client.LoadLink("DeleteUser").then(hal.makeVoid);
    }

    public canDeleteUser(): boolean {
        return this.client.HasLink("DeleteUser");
    }

    public linkForDeleteUser(): hal.HalLink {
        return this.client.GetLink("DeleteUser");
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
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

    public getUpdateDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update")
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

    private strongItems: ButtonResult[];
    public get items(): ButtonResult[] {
        if (this.strongItems === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.strongItems = [];
            for (var i = 0; i < clients.length; ++i) {
                this.strongItems.push(new ButtonResult(clients[i]));
            }
        }
        return this.strongItems;
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update")
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

    public getAddDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Add")
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

    public getNextDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next")
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

    public getPreviousDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous")
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

    public getFirstDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first")
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

    public getLastDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasLastDocs(): boolean {
        return this.client.HasLinkDoc("last");
    }
}

export class EntryPointInjector {
    private url: string;
    private fetcher: hal.Fetcher;
    private instance: EntryPointResult;

    constructor(url: string, fetcher: hal.Fetcher) {
        this.url = url;
        this.fetcher = fetcher;
    }

    public load(): Promise<EntryPointResult> {
        if (!this.instance) {
            return EntryPointResult.Load(this.url, this.fetcher).then((r) => {
                this.instance = r;
                return r;
            });
        }

        return Promise.resolve(this.instance);
    }
}

export class EntryPointResult {
    private client: hal.HalEndpointClient;

    public static Load(url: string, fetcher: hal.Fetcher): Promise<EntryPointResult> {
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

    public getListButtonsDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListButtons")
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

    public getAddButtonDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("AddButton")
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
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

    public getGetUserDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("GetUser")
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

    public getListUsersDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListUsers")
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

    public getSetUserDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("SetUser")
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

    public getListSensorsDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListSensors")
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

    public getListSwitchesDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListSwitches")
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

    public getListThermostatsDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("ListThermostats")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListThermostatsDocs(): boolean {
        return this.client.HasLinkDoc("ListThermostats");
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
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

    public getUpdateDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update")
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

    private strongItems: SensorResult[];
    public get items(): SensorResult[] {
        if (this.strongItems === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.strongItems = [];
            for (var i = 0; i < clients.length; ++i) {
                this.strongItems.push(new SensorResult(clients[i]));
            }
        }
        return this.strongItems;
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update")
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

    public getNextDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next")
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

    public getPreviousDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous")
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

    public getFirstDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first")
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

    public getLastDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last")
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
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

    public getUpdateDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
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

    private strongItems: SwitchResult[];
    public get items(): SwitchResult[] {
        if (this.strongItems === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.strongItems = [];
            for (var i = 0; i < clients.length; ++i) {
                this.strongItems.push(new SwitchResult(clients[i]));
            }
        }
        return this.strongItems;
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update")
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

    public getNextDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next")
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

    public getPreviousDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous")
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

    public getFirstDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first")
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

    public getLastDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last")
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
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

    public getUpdateDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasUpdateDocs(): boolean {
        return this.client.HasLinkDoc("Update");
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

    private strongItems: ThermostatResult[];
    public get items(): ThermostatResult[] {
        if (this.strongItems === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.strongItems = [];
            for (var i = 0; i < clients.length; ++i) {
                this.strongItems.push(new ThermostatResult(clients[i]));
            }
        }
        return this.strongItems;
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
    }

    public getGetDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Get")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasGetDocs(): boolean {
        return this.client.HasLinkDoc("Get");
    }

    public getListDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("List")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasListDocs(): boolean {
        return this.client.HasLinkDoc("List");
    }

    public getUpdateDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("Update")
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

    public getNextDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next")
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

    public getPreviousDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous")
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

    public getFirstDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first")
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

    public getLastDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last")
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

    private strongItems: RoleAssignmentsResult[];
    public get items(): RoleAssignmentsResult[] {
        if (this.strongItems === undefined) {
            var embeds = this.client.GetEmbed("values");
            var clients = embeds.GetAllClients();
            this.strongItems = [];
            for (var i = 0; i < clients.length; ++i) {
                this.strongItems.push(new RoleAssignmentsResult(clients[i]));
            }
        }
        return this.strongItems;
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

    public getRefreshDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("self")
            .then(r => {
                return r.GetData<hal.HalEndpointDoc>();
            });
    }

    public hasRefreshDocs(): boolean {
        return this.client.HasLinkDoc("self");
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

    public getNextDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("next")
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

    public getPreviousDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("previous")
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

    public getFirstDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("first")
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

    public getLastDocs(): Promise<hal.HalEndpointDoc> {
        return this.client.LoadLinkDoc("last")
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
//     Generated using the NSwag toolchain v9.10.49.0 (Newtonsoft.Json v11.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------





export interface RoleAssignments {
    editValues?: boolean;
    userId?: string;
    name?: string;
    editRoles?: boolean;
    superAdmin?: boolean;
}

export interface ButtonState {
    switchSettings?: SwitchSetting[];
    buttonStateId?: string;
    label?: string;
    order?: number;
    created?: string;
    modified?: string;
}

export interface SwitchSetting {
    switchSettingId?: string;
    switchId?: string;
    value?: string;
    brightness?: number;
    hexColor?: string;
    created?: string;
    modified?: string;
}

export interface Button {
    buttonStates?: ButtonState[];
    buttonId?: string;
    label?: string;
    created?: string;
    modified?: string;
}

export interface ButtonStateInput {
    switchSettings?: SwitchSettingInput[];
    label?: string;
    order?: number;
}

export interface SwitchSettingInput {
    switchId?: string;
    value?: string;
    brightness?: number;
    hexColor?: string;
}

export interface ButtonInput {
    buttonStates?: ButtonStateInput[];
    label?: string;
}

export interface ButtonCollection {
    /** The number of pages (item number = Offset * Limit) into the collection to query. */
    offset?: number;
    buttonId?: string;
    total?: number;
    /** The limit of the number of items to return. */
    limit?: number;
}

export interface ButtonQuery {
    buttonId?: string;
    /** The number of pages (item number = Offset * Limit) into the collection to query. */
    offset?: number;
    /** The limit of the number of items to return. */
    limit?: number;
}

export interface EntryPoint {
}

export interface RolesQuery {
    /** The guid for the user, this is used to look up the user. */
    userId?: string[];
    /** A name for the user. Used only as a reference, will be added to the result if the user is not found. */
    name?: string;
    /** The number of pages (item number = Offset * Limit) into the collection to query. */
    offset?: number;
    /** The limit of the number of items to return. */
    limit?: number;
}

export interface UserCollection {
    offset?: number;
    limit?: number;
    total?: number;
}

export interface SensorQuery {
    sensorId?: string;
    /** The number of pages (item number = Offset * Limit) into the collection to query. */
    offset?: number;
    /** The limit of the number of items to return. */
    limit?: number;
}

export interface SensorCollection {
    /** The number of pages (item number = Offset * Limit) into the collection to query. */
    offset?: number;
    sensorId?: string;
    total?: number;
    /** The limit of the number of items to return. */
    limit?: number;
}

export interface SwitchQuery {
    switchId?: string;
    /** The number of pages (item number = Offset * Limit) into the collection to query. */
    offset?: number;
    /** The limit of the number of items to return. */
    limit?: number;
}

export interface SwitchCollection {
    /** The number of pages (item number = Offset * Limit) into the collection to query. */
    offset?: number;
    switchId?: string;
    total?: number;
    /** The limit of the number of items to return. */
    limit?: number;
}

export interface ThermostatQuery {
    thermostatId?: string;
    /** The number of pages (item number = Offset * Limit) into the collection to query. */
    offset?: number;
    /** The limit of the number of items to return. */
    limit?: number;
}

export interface ThermostatCollection {
    /** The number of pages (item number = Offset * Limit) into the collection to query. */
    offset?: number;
    thermostatId?: string;
    total?: number;
    /** The limit of the number of items to return. */
    limit?: number;
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
    name: string;
    subsystem: string;
    bridge: string;
    id: string;
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

export interface Switch {
    brightness?: number;
    switchId?: string;
    name?: string;
    subsystem?: string;
    bridge?: string;
    id?: string;
    value?: string;
    hexColor?: string;
    created?: string;
    modified?: string;
}

export interface SwitchInput {
    brightness?: number;
    name: string;
    subsystem: string;
    bridge: string;
    id: string;
    value?: string;
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
