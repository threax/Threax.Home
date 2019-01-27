using Threax.AspNetCore.Halcyon.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace Threax.Home.Client {

public class RoleAssignmentsResult 
{
    private HalEndpointClient client;

    public RoleAssignmentsResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private RoleAssignments strongData = default(RoleAssignments);
    public RoleAssignments Data 
    {
        get
        {
            if(this.strongData == default(RoleAssignments))
            {
                this.strongData = this.client.GetData<RoleAssignments>();  
            }
            return this.strongData;
        }
    }

    public async Task<RoleAssignmentsResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new RoleAssignmentsResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<RoleAssignmentsResult> SetUser(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("SetUser", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanSetUser 
    {
        get 
        {
            return this.client.HasLink("SetUser");
        }
    }

    public HalLink LinkForSetUser 
    {
        get 
        {
            return this.client.GetLink("SetUser");
        }
    }

    public async Task<HalEndpointDoc> GetSetUserDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("SetUser", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasSetUserDocs() {
        return this.client.HasLinkDoc("SetUser");
    }

    public async Task<RoleAssignmentsResult> Update(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task Delete() 
    {
        var result = await this.client.LoadLink("Delete");
    }

    public bool CanDelete 
    {
        get 
        {
            return this.client.HasLink("Delete");
        }
    }

    public HalLink LinkForDelete 
    {
        get 
        {
            return this.client.GetLink("Delete");
        }
    }
}

public class ButtonResult 
{
    private HalEndpointClient client;

    public ButtonResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private Button strongData = default(Button);
    public Button Data 
    {
        get
        {
            if(this.strongData == default(Button))
            {
                this.strongData = this.client.GetData<Button>();  
            }
            return this.strongData;
        }
    }

    public async Task<ButtonResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new ButtonResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<ButtonResult> Update(ButtonInput data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new ButtonResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task Delete() 
    {
        var result = await this.client.LoadLink("Delete");
    }

    public bool CanDelete 
    {
        get 
        {
            return this.client.HasLink("Delete");
        }
    }

    public HalLink LinkForDelete 
    {
        get 
        {
            return this.client.GetLink("Delete");
        }
    }

    public async Task<ButtonResult> Apply(ApplyButtonInput data) 
    {
        var result = await this.client.LoadLinkWithData("Apply", data);
        return new ButtonResult(result);

    }

    public bool CanApply 
    {
        get 
        {
            return this.client.HasLink("Apply");
        }
    }

    public HalLink LinkForApply 
    {
        get 
        {
            return this.client.GetLink("Apply");
        }
    }

    public async Task<HalEndpointDoc> GetApplyDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Apply", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasApplyDocs() {
        return this.client.HasLinkDoc("Apply");
    }

    public async Task<SwitchResult> GetSwitch() 
    {
        var result = await this.client.LoadLink("GetSwitch");
        return new SwitchResult(result);

    }

    public bool CanGetSwitch 
    {
        get 
        {
            return this.client.HasLink("GetSwitch");
        }
    }

    public HalLink LinkForGetSwitch 
    {
        get 
        {
            return this.client.GetLink("GetSwitch");
        }
    }

    public async Task<HalEndpointDoc> GetGetSwitchDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("GetSwitch", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetSwitchDocs() {
        return this.client.HasLinkDoc("GetSwitch");
    }
}

public class ButtonCollectionResult 
{
    private HalEndpointClient client;

    public ButtonCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private ButtonCollection strongData = default(ButtonCollection);
    public ButtonCollection Data 
    {
        get
        {
            if(this.strongData == default(ButtonCollection))
            {
                this.strongData = this.client.GetData<ButtonCollection>();  
            }
            return this.strongData;
        }
    }

    private List<ButtonResult> itemsStrong = null;
    public List<ButtonResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<ButtonResult>(clients.Select(i => new ButtonResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<ButtonCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new ButtonCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<ButtonResult> Add(ButtonInput data) 
    {
        var result = await this.client.LoadLinkWithData("Add", data);
        return new ButtonResult(result);

    }

    public bool CanAdd 
    {
        get 
        {
            return this.client.HasLink("Add");
        }
    }

    public HalLink LinkForAdd 
    {
        get 
        {
            return this.client.GetLink("Add");
        }
    }

    public async Task<HalEndpointDoc> GetAddDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Add", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddDocs() {
        return this.client.HasLinkDoc("Add");
    }

    public async Task<ButtonCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new ButtonCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<ButtonCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new ButtonCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<ButtonCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new ButtonCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<ButtonCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new ButtonCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class ButtonStateResult 
{
    private HalEndpointClient client;

    public ButtonStateResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private ButtonState strongData = default(ButtonState);
    public ButtonState Data 
    {
        get
        {
            if(this.strongData == default(ButtonState))
            {
                this.strongData = this.client.GetData<ButtonState>();  
            }
            return this.strongData;
        }
    }

    public async Task<ButtonResult> Apply() 
    {
        var result = await this.client.LoadLink("Apply");
        return new ButtonResult(result);

    }

    public bool CanApply 
    {
        get 
        {
            return this.client.HasLink("Apply");
        }
    }

    public HalLink LinkForApply 
    {
        get 
        {
            return this.client.GetLink("Apply");
        }
    }

    public async Task<HalEndpointDoc> GetApplyDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Apply", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasApplyDocs() {
        return this.client.HasLinkDoc("Apply");
    }
}

public class EntryPointInjector 
{
    private string url;
    private IHttpClientFactory fetcher;
    private Task<EntryPointResult> instanceTask = default(Task<EntryPointResult>);

    public EntryPointInjector(string url, IHttpClientFactory fetcher)
    {
        this.url = url;
        this.fetcher = fetcher;
    }

    public Task<EntryPointResult> Load()
    {
        if (this.instanceTask == default(Task<EntryPointResult>))
        {
            this.instanceTask = EntryPointResult.Load(this.url, this.fetcher);
        }
        return this.instanceTask;
    }
}

public class EntryPointResult 
{
    private HalEndpointClient client;

    public static async Task<EntryPointResult> Load(string url, IHttpClientFactory fetcher)
    {
        var result = await HalEndpointClient.Load(new HalLink(url, "GET"), fetcher);
        return new EntryPointResult(result);
    }

    public EntryPointResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private EntryPoint strongData = default(EntryPoint);
    public EntryPoint Data 
    {
        get
        {
            if(this.strongData == default(EntryPoint))
            {
                this.strongData = this.client.GetData<EntryPoint>();  
            }
            return this.strongData;
        }
    }

    public async Task<ButtonCollectionResult> ListButtons(ButtonQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListButtons", data);
        return new ButtonCollectionResult(result);

    }

    public bool CanListButtons 
    {
        get 
        {
            return this.client.HasLink("ListButtons");
        }
    }

    public HalLink LinkForListButtons 
    {
        get 
        {
            return this.client.GetLink("ListButtons");
        }
    }

    public async Task<HalEndpointDoc> GetListButtonsDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListButtons", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListButtonsDocs() {
        return this.client.HasLinkDoc("ListButtons");
    }

    public async Task<ButtonResult> AddButton(ButtonInput data) 
    {
        var result = await this.client.LoadLinkWithData("AddButton", data);
        return new ButtonResult(result);

    }

    public bool CanAddButton 
    {
        get 
        {
            return this.client.HasLink("AddButton");
        }
    }

    public HalLink LinkForAddButton 
    {
        get 
        {
            return this.client.GetLink("AddButton");
        }
    }

    public async Task<HalEndpointDoc> GetAddButtonDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("AddButton", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddButtonDocs() {
        return this.client.HasLinkDoc("AddButton");
    }

    public async Task<EntryPointResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new EntryPointResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<RoleAssignmentsResult> GetUser() 
    {
        var result = await this.client.LoadLink("GetUser");
        return new RoleAssignmentsResult(result);

    }

    public bool CanGetUser 
    {
        get 
        {
            return this.client.HasLink("GetUser");
        }
    }

    public HalLink LinkForGetUser 
    {
        get 
        {
            return this.client.GetLink("GetUser");
        }
    }

    public async Task<HalEndpointDoc> GetGetUserDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("GetUser", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetUserDocs() {
        return this.client.HasLinkDoc("GetUser");
    }

    public async Task<UserCollectionResult> ListUsers(RolesQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListUsers", data);
        return new UserCollectionResult(result);

    }

    public bool CanListUsers 
    {
        get 
        {
            return this.client.HasLink("ListUsers");
        }
    }

    public HalLink LinkForListUsers 
    {
        get 
        {
            return this.client.GetLink("ListUsers");
        }
    }

    public async Task<HalEndpointDoc> GetListUsersDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListUsers", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListUsersDocs() {
        return this.client.HasLinkDoc("ListUsers");
    }

    public async Task<RoleAssignmentsResult> SetUser(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("SetUser", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanSetUser 
    {
        get 
        {
            return this.client.HasLink("SetUser");
        }
    }

    public HalLink LinkForSetUser 
    {
        get 
        {
            return this.client.GetLink("SetUser");
        }
    }

    public async Task<HalEndpointDoc> GetSetUserDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("SetUser", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasSetUserDocs() {
        return this.client.HasLinkDoc("SetUser");
    }

    public async Task AddNewSwitches() 
    {
        var result = await this.client.LoadLink("AddNewSwitches");
    }

    public bool CanAddNewSwitches 
    {
        get 
        {
            return this.client.HasLink("AddNewSwitches");
        }
    }

    public HalLink LinkForAddNewSwitches 
    {
        get 
        {
            return this.client.GetLink("AddNewSwitches");
        }
    }

    public async Task AddNewSensors() 
    {
        var result = await this.client.LoadLink("AddNewSensors");
    }

    public bool CanAddNewSensors 
    {
        get 
        {
            return this.client.HasLink("AddNewSensors");
        }
    }

    public HalLink LinkForAddNewSensors 
    {
        get 
        {
            return this.client.GetLink("AddNewSensors");
        }
    }

    public async Task AddNewThermostats() 
    {
        var result = await this.client.LoadLink("AddNewThermostats");
    }

    public bool CanAddNewThermostats 
    {
        get 
        {
            return this.client.HasLink("AddNewThermostats");
        }
    }

    public HalLink LinkForAddNewThermostats 
    {
        get 
        {
            return this.client.GetLink("AddNewThermostats");
        }
    }

    public async Task<UserSearchCollectionResult> ListAppUsers(UserSearchQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListAppUsers", data);
        return new UserSearchCollectionResult(result);

    }

    public bool CanListAppUsers 
    {
        get 
        {
            return this.client.HasLink("ListAppUsers");
        }
    }

    public HalLink LinkForListAppUsers 
    {
        get 
        {
            return this.client.GetLink("ListAppUsers");
        }
    }

    public async Task<HalEndpointDoc> GetListAppUsersDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListAppUsers", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListAppUsersDocs() {
        return this.client.HasLinkDoc("ListAppUsers");
    }

    public async Task<SensorCollectionResult> ListSensors(SensorQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListSensors", data);
        return new SensorCollectionResult(result);

    }

    public bool CanListSensors 
    {
        get 
        {
            return this.client.HasLink("ListSensors");
        }
    }

    public HalLink LinkForListSensors 
    {
        get 
        {
            return this.client.GetLink("ListSensors");
        }
    }

    public async Task<HalEndpointDoc> GetListSensorsDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListSensors", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListSensorsDocs() {
        return this.client.HasLinkDoc("ListSensors");
    }

    public async Task<SwitchCollectionResult> ListSwitches(SwitchQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListSwitches", data);
        return new SwitchCollectionResult(result);

    }

    public bool CanListSwitches 
    {
        get 
        {
            return this.client.HasLink("ListSwitches");
        }
    }

    public HalLink LinkForListSwitches 
    {
        get 
        {
            return this.client.GetLink("ListSwitches");
        }
    }

    public async Task<HalEndpointDoc> GetListSwitchesDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListSwitches", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListSwitchesDocs() {
        return this.client.HasLinkDoc("ListSwitches");
    }

    public async Task<ThermostatCollectionResult> ListThermostats(ThermostatQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListThermostats", data);
        return new ThermostatCollectionResult(result);

    }

    public bool CanListThermostats 
    {
        get 
        {
            return this.client.HasLink("ListThermostats");
        }
    }

    public HalLink LinkForListThermostats 
    {
        get 
        {
            return this.client.GetLink("ListThermostats");
        }
    }

    public async Task<HalEndpointDoc> GetListThermostatsDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListThermostats", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListThermostatsDocs() {
        return this.client.HasLinkDoc("ListThermostats");
    }

    public async Task<ThermostatSettingCollectionResult> ListThermostatSettings(ThermostatSettingQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListThermostatSettings", data);
        return new ThermostatSettingCollectionResult(result);

    }

    public bool CanListThermostatSettings 
    {
        get 
        {
            return this.client.HasLink("ListThermostatSettings");
        }
    }

    public HalLink LinkForListThermostatSettings 
    {
        get 
        {
            return this.client.GetLink("ListThermostatSettings");
        }
    }

    public async Task<HalEndpointDoc> GetListThermostatSettingsDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListThermostatSettings", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListThermostatSettingsDocs() {
        return this.client.HasLinkDoc("ListThermostatSettings");
    }

    public async Task<ThermostatSettingResult> AddThermostatSetting(ThermostatSettingInput data) 
    {
        var result = await this.client.LoadLinkWithData("AddThermostatSetting", data);
        return new ThermostatSettingResult(result);

    }

    public bool CanAddThermostatSetting 
    {
        get 
        {
            return this.client.HasLink("AddThermostatSetting");
        }
    }

    public HalLink LinkForAddThermostatSetting 
    {
        get 
        {
            return this.client.GetLink("AddThermostatSetting");
        }
    }

    public async Task<HalEndpointDoc> GetAddThermostatSettingDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("AddThermostatSetting", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddThermostatSettingDocs() {
        return this.client.HasLinkDoc("AddThermostatSetting");
    }
}

public class SensorResult 
{
    private HalEndpointClient client;

    public SensorResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private Sensor strongData = default(Sensor);
    public Sensor Data 
    {
        get
        {
            if(this.strongData == default(Sensor))
            {
                this.strongData = this.client.GetData<Sensor>();  
            }
            return this.strongData;
        }
    }

    public async Task<SensorResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new SensorResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<SensorResult> Update(SensorInput data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new SensorResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }
}

public class SensorCollectionResult 
{
    private HalEndpointClient client;

    public SensorCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private SensorCollection strongData = default(SensorCollection);
    public SensorCollection Data 
    {
        get
        {
            if(this.strongData == default(SensorCollection))
            {
                this.strongData = this.client.GetData<SensorCollection>();  
            }
            return this.strongData;
        }
    }

    private List<SensorResult> itemsStrong = null;
    public List<SensorResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<SensorResult>(clients.Select(i => new SensorResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<SensorCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new SensorCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<SensorCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new SensorCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<SensorCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new SensorCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<SensorCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new SensorCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<SensorCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new SensorCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class SwitchResult 
{
    private HalEndpointClient client;

    public SwitchResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private Switch strongData = default(Switch);
    public Switch Data 
    {
        get
        {
            if(this.strongData == default(Switch))
            {
                this.strongData = this.client.GetData<Switch>();  
            }
            return this.strongData;
        }
    }

    public async Task<SwitchResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new SwitchResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<SwitchResult> Update(SwitchInput data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new SwitchResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<SwitchResult> Set(SetSwitchInput data) 
    {
        var result = await this.client.LoadLinkWithData("Set", data);
        return new SwitchResult(result);

    }

    public bool CanSet 
    {
        get 
        {
            return this.client.HasLink("Set");
        }
    }

    public HalLink LinkForSet 
    {
        get 
        {
            return this.client.GetLink("Set");
        }
    }

    public async Task<HalEndpointDoc> GetSetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Set", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasSetDocs() {
        return this.client.HasLinkDoc("Set");
    }

    public async Task Delete() 
    {
        var result = await this.client.LoadLink("Delete");
    }

    public bool CanDelete 
    {
        get 
        {
            return this.client.HasLink("Delete");
        }
    }

    public HalLink LinkForDelete 
    {
        get 
        {
            return this.client.GetLink("Delete");
        }
    }
}

public class SwitchCollectionResult 
{
    private HalEndpointClient client;

    public SwitchCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private SwitchCollection strongData = default(SwitchCollection);
    public SwitchCollection Data 
    {
        get
        {
            if(this.strongData == default(SwitchCollection))
            {
                this.strongData = this.client.GetData<SwitchCollection>();  
            }
            return this.strongData;
        }
    }

    private List<SwitchResult> itemsStrong = null;
    public List<SwitchResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<SwitchResult>(clients.Select(i => new SwitchResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<SwitchCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new SwitchCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<SwitchCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new SwitchCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<SwitchCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new SwitchCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<SwitchCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new SwitchCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<SwitchCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new SwitchCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class ThermostatResult 
{
    private HalEndpointClient client;

    public ThermostatResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private Thermostat strongData = default(Thermostat);
    public Thermostat Data 
    {
        get
        {
            if(this.strongData == default(Thermostat))
            {
                this.strongData = this.client.GetData<Thermostat>();  
            }
            return this.strongData;
        }
    }

    public async Task<ThermostatResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new ThermostatResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<ThermostatResult> Update(ThermostatInput data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new ThermostatResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<ThermostatResult> SetTemp(ThermostatTempInput data) 
    {
        var result = await this.client.LoadLinkWithData("SetTemp", data);
        return new ThermostatResult(result);

    }

    public bool CanSetTemp 
    {
        get 
        {
            return this.client.HasLink("SetTemp");
        }
    }

    public HalLink LinkForSetTemp 
    {
        get 
        {
            return this.client.GetLink("SetTemp");
        }
    }

    public async Task<HalEndpointDoc> GetSetTempDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("SetTemp", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasSetTempDocs() {
        return this.client.HasLinkDoc("SetTemp");
    }

    public async Task<ThermostatSettingCollectionResult> GetSettings() 
    {
        var result = await this.client.LoadLink("GetSettings");
        return new ThermostatSettingCollectionResult(result);

    }

    public bool CanGetSettings 
    {
        get 
        {
            return this.client.HasLink("GetSettings");
        }
    }

    public HalLink LinkForGetSettings 
    {
        get 
        {
            return this.client.GetLink("GetSettings");
        }
    }

    public async Task<HalEndpointDoc> GetGetSettingsDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("GetSettings", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetSettingsDocs() {
        return this.client.HasLinkDoc("GetSettings");
    }
}

public class ThermostatCollectionResult 
{
    private HalEndpointClient client;

    public ThermostatCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private ThermostatCollection strongData = default(ThermostatCollection);
    public ThermostatCollection Data 
    {
        get
        {
            if(this.strongData == default(ThermostatCollection))
            {
                this.strongData = this.client.GetData<ThermostatCollection>();  
            }
            return this.strongData;
        }
    }

    private List<ThermostatResult> itemsStrong = null;
    public List<ThermostatResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<ThermostatResult>(clients.Select(i => new ThermostatResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<ThermostatCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new ThermostatCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<ThermostatCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new ThermostatCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<ThermostatCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new ThermostatCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<ThermostatCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new ThermostatCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<ThermostatCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new ThermostatCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class ThermostatSettingResult 
{
    private HalEndpointClient client;

    public ThermostatSettingResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private ThermostatSetting strongData = default(ThermostatSetting);
    public ThermostatSetting Data 
    {
        get
        {
            if(this.strongData == default(ThermostatSetting))
            {
                this.strongData = this.client.GetData<ThermostatSetting>();  
            }
            return this.strongData;
        }
    }

    public async Task<ThermostatSettingResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new ThermostatSettingResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<ThermostatSettingResult> Update(ThermostatSettingInput data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new ThermostatSettingResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task Delete() 
    {
        var result = await this.client.LoadLink("Delete");
    }

    public bool CanDelete 
    {
        get 
        {
            return this.client.HasLink("Delete");
        }
    }

    public HalLink LinkForDelete 
    {
        get 
        {
            return this.client.GetLink("Delete");
        }
    }

    public async Task<ThermostatResult> ApplySetting() 
    {
        var result = await this.client.LoadLink("ApplySetting");
        return new ThermostatResult(result);

    }

    public bool CanApplySetting 
    {
        get 
        {
            return this.client.HasLink("ApplySetting");
        }
    }

    public HalLink LinkForApplySetting 
    {
        get 
        {
            return this.client.GetLink("ApplySetting");
        }
    }

    public async Task<HalEndpointDoc> GetApplySettingDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ApplySetting", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasApplySettingDocs() {
        return this.client.HasLinkDoc("ApplySetting");
    }
}

public class ThermostatSettingCollectionResult 
{
    private HalEndpointClient client;

    public ThermostatSettingCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private ThermostatSettingCollection strongData = default(ThermostatSettingCollection);
    public ThermostatSettingCollection Data 
    {
        get
        {
            if(this.strongData == default(ThermostatSettingCollection))
            {
                this.strongData = this.client.GetData<ThermostatSettingCollection>();  
            }
            return this.strongData;
        }
    }

    private List<ThermostatSettingResult> itemsStrong = null;
    public List<ThermostatSettingResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<ThermostatSettingResult>(clients.Select(i => new ThermostatSettingResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<ThermostatSettingCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new ThermostatSettingCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<ThermostatSettingResult> Add(ThermostatSettingInput data) 
    {
        var result = await this.client.LoadLinkWithData("Add", data);
        return new ThermostatSettingResult(result);

    }

    public bool CanAdd 
    {
        get 
        {
            return this.client.HasLink("Add");
        }
    }

    public HalLink LinkForAdd 
    {
        get 
        {
            return this.client.GetLink("Add");
        }
    }

    public async Task<HalEndpointDoc> GetAddDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Add", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddDocs() {
        return this.client.HasLinkDoc("Add");
    }

    public async Task<ThermostatSettingCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new ThermostatSettingCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<ThermostatSettingCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new ThermostatSettingCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<ThermostatSettingCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new ThermostatSettingCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<ThermostatSettingCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new ThermostatSettingCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class UserCollectionResult 
{
    private HalEndpointClient client;

    public UserCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private UserCollection strongData = default(UserCollection);
    public UserCollection Data 
    {
        get
        {
            if(this.strongData == default(UserCollection))
            {
                this.strongData = this.client.GetData<UserCollection>();  
            }
            return this.strongData;
        }
    }

    private List<RoleAssignmentsResult> itemsStrong = null;
    public List<RoleAssignmentsResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<RoleAssignmentsResult>(clients.Select(i => new RoleAssignmentsResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<UserCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new UserCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<RoleAssignmentsResult> Add(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("Add", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanAdd 
    {
        get 
        {
            return this.client.HasLink("Add");
        }
    }

    public HalLink LinkForAdd 
    {
        get 
        {
            return this.client.GetLink("Add");
        }
    }

    public async Task<HalEndpointDoc> GetAddDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Add", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddDocs() {
        return this.client.HasLinkDoc("Add");
    }

    public async Task<UserCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new UserCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<UserCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new UserCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<UserCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new UserCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<UserCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new UserCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class UserSearchResult 
{
    private HalEndpointClient client;

    public UserSearchResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private UserSearch strongData = default(UserSearch);
    public UserSearch Data 
    {
        get
        {
            if(this.strongData == default(UserSearch))
            {
                this.strongData = this.client.GetData<UserSearch>();  
            }
            return this.strongData;
        }
    }

    public async Task<UserSearchResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new UserSearchResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }
}

public class UserSearchCollectionResult 
{
    private HalEndpointClient client;

    public UserSearchCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private UserSearchCollection strongData = default(UserSearchCollection);
    public UserSearchCollection Data 
    {
        get
        {
            if(this.strongData == default(UserSearchCollection))
            {
                this.strongData = this.client.GetData<UserSearchCollection>();  
            }
            return this.strongData;
        }
    }

    private List<UserSearchResult> itemsStrong = null;
    public List<UserSearchResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<UserSearchResult>(clients.Select(i => new UserSearchResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<UserSearchCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new UserSearchCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<UserSearchCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new UserSearchCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<UserSearchCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new UserSearchCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<UserSearchCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new UserSearchCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<UserSearchCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new UserSearchCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}
}
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v9.10.49.0 (Newtonsoft.Json v11.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------

namespace Threax.Home.Client
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class RoleAssignments 
    {
        [Newtonsoft.Json.JsonProperty("editButtons", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditButtons { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editSensors", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditSensors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editSwitches", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditSwitches { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editThermostats", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditThermostats { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editThermostatSettings", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditThermostatSettings { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editRoles", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditRoles { get; set; }
    
        [Newtonsoft.Json.JsonProperty("superAdmin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool SuperAdmin { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static RoleAssignments FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RoleAssignments>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ButtonType
    {
        [System.Runtime.Serialization.EnumMember(Value = "Light")]
        Light = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fan")]
        Fan = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ButtonState 
    {
        [Newtonsoft.Json.JsonProperty("buttonStateId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid ButtonStateId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Label { get; set; }
    
        [Newtonsoft.Json.JsonProperty("order", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Order { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        [Newtonsoft.Json.JsonProperty("switchSettings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<SwitchSetting> SwitchSettings { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ButtonState FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ButtonState>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SwitchSetting 
    {
        [Newtonsoft.Json.JsonProperty("switchSettingId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid SwitchSettingId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("switchId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid SwitchId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }
    
        [Newtonsoft.Json.JsonProperty("brightness", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Brightness { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hexColor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HexColor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        [Newtonsoft.Json.JsonProperty("switch", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Switch Switch { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static SwitchSetting FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SwitchSetting>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Switch 
    {
        [Newtonsoft.Json.JsonProperty("switchId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid SwitchId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hexColor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HexColor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        [Newtonsoft.Json.JsonProperty("brightness", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public byte? Brightness { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static Switch FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Switch>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Button 
    {
        [Newtonsoft.Json.JsonProperty("buttonId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid ButtonId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Label { get; set; }
    
        [Newtonsoft.Json.JsonProperty("order", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Order { get; set; }
    
        [Newtonsoft.Json.JsonProperty("buttonType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ButtonType ButtonType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        [Newtonsoft.Json.JsonProperty("buttonStates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<ButtonState> ButtonStates { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static Button FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Button>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ButtonStateInput 
    {
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Label { get; set; }
    
        [Newtonsoft.Json.JsonProperty("order", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Order { get; set; }
    
        [Newtonsoft.Json.JsonProperty("switchSettings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<SwitchSettingInput> SwitchSettings { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ButtonStateInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ButtonStateInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SwitchSettingInput 
    {
        [Newtonsoft.Json.JsonProperty("switchId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid SwitchId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }
    
        [Newtonsoft.Json.JsonProperty("brightness", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Brightness { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hexColor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HexColor { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static SwitchSettingInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SwitchSettingInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ButtonInput 
    {
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Label { get; set; }
    
        [Newtonsoft.Json.JsonProperty("order", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Order { get; set; }
    
        [Newtonsoft.Json.JsonProperty("buttonType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ButtonType ButtonType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("buttonStates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<ButtonStateInput> ButtonStates { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ButtonInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ButtonInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ApplyButtonInput 
    {
        [Newtonsoft.Json.JsonProperty("buttonStateId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid ButtonStateId { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ApplyButtonInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ApplyButtonInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ButtonCollection 
    {
        [Newtonsoft.Json.JsonProperty("includeButler", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeButler { get; set; }
    
        /// <summary>Lookup a button by id.</summary>
        [Newtonsoft.Json.JsonProperty("buttonId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? ButtonId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ButtonCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ButtonCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ButtonQuery 
    {
        /// <summary>Lookup a button by id.</summary>
        [Newtonsoft.Json.JsonProperty("buttonId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? ButtonId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeButler", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeButler { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ButtonQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ButtonQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class EntryPoint 
    {
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static EntryPoint FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<EntryPoint>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class RolesQuery 
    {
        /// <summary>The guid for the user, this is used to look up the user.</summary>
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<System.Guid> UserId { get; set; }
    
        /// <summary>A name for the user. Used only as a reference, will be added to the result if the user is not found.</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static RolesQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RolesQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserCollection 
    {
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserSearchQuery 
    {
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserSearchQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserSearchQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserSearchCollection 
    {
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserSearchCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserSearchCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SensorQuery 
    {
        /// <summary>Lookup a sensor by id.</summary>
        [Newtonsoft.Json.JsonProperty("sensorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? SensorId { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static SensorQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SensorQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SensorCollection 
    {
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>Lookup a sensor by id.</summary>
        [Newtonsoft.Json.JsonProperty("sensorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? SensorId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static SensorCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SensorCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SwitchQuery 
    {
        [Newtonsoft.Json.JsonProperty("switchIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<System.Guid> SwitchIds { get; set; }
    
        /// <summary>Get the current status of the switches in the query results. 
        /// Will take longer while the switch info is loaded.</summary>
        [Newtonsoft.Json.JsonProperty("getStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool GetStatus { get; set; }
    
        /// <summary>Lookup a @switch by id.</summary>
        [Newtonsoft.Json.JsonProperty("switchId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? SwitchId { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static SwitchQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SwitchQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SwitchCollection 
    {
        /// <summary>Get the current status of the switches in the query results. 
        /// Will take longer while the switch info is loaded.</summary>
        [Newtonsoft.Json.JsonProperty("getStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool GetStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("switchIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<System.Guid> SwitchIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        /// <summary>Lookup a @switch by id.</summary>
        [Newtonsoft.Json.JsonProperty("switchId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? SwitchId { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static SwitchCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SwitchCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ThermostatQuery 
    {
        /// <summary>Lookup a thermostat by id.</summary>
        [Newtonsoft.Json.JsonProperty("thermostatId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? ThermostatId { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ThermostatQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ThermostatQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ThermostatCollection 
    {
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>Lookup a thermostat by id.</summary>
        [Newtonsoft.Json.JsonProperty("thermostatId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? ThermostatId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ThermostatCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ThermostatCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ThermostatSettingQuery 
    {
        /// <summary>Lookup a thermostatSetting by id.</summary>
        [Newtonsoft.Json.JsonProperty("thermostatSettingId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? ThermostatSettingId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("thermostatId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? ThermostatId { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ThermostatSettingQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ThermostatSettingQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ThermostatSettingCollection 
    {
        [Newtonsoft.Json.JsonProperty("thermostatId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? ThermostatId { get; set; }
    
        /// <summary>Lookup a thermostatSetting by id.</summary>
        [Newtonsoft.Json.JsonProperty("thermostatSettingId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? ThermostatSettingId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ThermostatSettingCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ThermostatSettingCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ThermostatSettingInput 
    {
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Label { get; set; }
    
        [Newtonsoft.Json.JsonProperty("order", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Order { get; set; }
    
        [Newtonsoft.Json.JsonProperty("coolTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CoolTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heatTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HeatTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("on", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool On { get; set; }
    
        [Newtonsoft.Json.JsonProperty("thermostatId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid ThermostatId { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ThermostatSettingInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ThermostatSettingInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ThermostatSetting 
    {
        [Newtonsoft.Json.JsonProperty("thermostatSettingId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid ThermostatSettingId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Label { get; set; }
    
        [Newtonsoft.Json.JsonProperty("order", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Order { get; set; }
    
        [Newtonsoft.Json.JsonProperty("coolTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CoolTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heatTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HeatTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("on", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool On { get; set; }
    
        [Newtonsoft.Json.JsonProperty("thermostatId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid ThermostatId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ThermostatSetting FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ThermostatSetting>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Units
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fahrenheit")]
        Fahrenheit = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lux")]
        Lux = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Percent")]
        Percent = 4,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Sensor 
    {
        [Newtonsoft.Json.JsonProperty("sensorId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid SensorId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsystem", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Subsystem { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bridge", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Bridge { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tempValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? TempValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tempUnits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SensorTempUnits? TempUnits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lightValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? LightValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lightUnits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SensorLightUnits? LightUnits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("humidityValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? HumidityValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("humidityUnits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SensorHumidityUnits? HumidityUnits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("uvValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? UvValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("uvUnits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SensorUvUnits? UvUnits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static Sensor FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Sensor>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SensorTempUnits
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fahrenheit")]
        Fahrenheit = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lux")]
        Lux = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = "Percent")]
        Percent = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SensorLightUnits
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fahrenheit")]
        Fahrenheit = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lux")]
        Lux = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = "Percent")]
        Percent = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SensorHumidityUnits
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fahrenheit")]
        Fahrenheit = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lux")]
        Lux = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = "Percent")]
        Percent = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SensorUvUnits
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fahrenheit")]
        Fahrenheit = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lux")]
        Lux = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = "Percent")]
        Percent = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SensorInput 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsystem", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Subsystem { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bridge", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Bridge { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tempValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? TempValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tempUnits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SensorInputTempUnits? TempUnits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lightValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? LightValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lightUnits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SensorInputLightUnits? LightUnits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("humidityValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? HumidityValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("humidityUnits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SensorInputHumidityUnits? HumidityUnits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("uvValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? UvValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("uvUnits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SensorInputUvUnits? UvUnits { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static SensorInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SensorInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SensorInputTempUnits
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fahrenheit")]
        Fahrenheit = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lux")]
        Lux = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = "Percent")]
        Percent = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SensorInputLightUnits
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fahrenheit")]
        Fahrenheit = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lux")]
        Lux = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = "Percent")]
        Percent = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SensorInputHumidityUnits
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fahrenheit")]
        Fahrenheit = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lux")]
        Lux = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = "Percent")]
        Percent = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SensorInputUvUnits
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Fahrenheit")]
        Fahrenheit = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lux")]
        Lux = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = "Percent")]
        Percent = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SwitchInput 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hexColor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HexColor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("brightness", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public byte? Brightness { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static SwitchInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SwitchInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SetSwitchInput 
    {
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }
    
        [Newtonsoft.Json.JsonProperty("brightness", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public byte? Brightness { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hexColor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HexColor { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static SetSwitchInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SetSwitchInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Mode
    {
        [System.Runtime.Serialization.EnumMember(Value = "Off")]
        Off = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "Heat")]
        Heat = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Cool")]
        Cool = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Auto")]
        Auto = 3,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum FanSetting
    {
        [System.Runtime.Serialization.EnumMember(Value = "Auto")]
        Auto = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "On")]
        On = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum State
    {
        [System.Runtime.Serialization.EnumMember(Value = "Idle")]
        Idle = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "Heating")]
        Heating = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Cooling")]
        Cooling = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Lockout")]
        Lockout = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Error")]
        Error = 4,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum FanState
    {
        [System.Runtime.Serialization.EnumMember(Value = "Off")]
        Off = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "On")]
        On = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum TempUnits
    {
        [System.Runtime.Serialization.EnumMember(Value = "Farenheit")]
        Farenheit = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "Celsius")]
        Celsius = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SchedulePart
    {
        [System.Runtime.Serialization.EnumMember(Value = "Morning")]
        Morning = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "Day")]
        Day = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Evening")]
        Evening = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "Night")]
        Night = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Inactive")]
        Inactive = 4,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Away
    {
        [System.Runtime.Serialization.EnumMember(Value = "Home")]
        Home = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "Away")]
        Away = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Holiday
    {
        [System.Runtime.Serialization.EnumMember(Value = "NotObservingHoliday")]
        NotObservingHoliday = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "ObservingHoliday")]
        ObservingHoliday = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Override
    {
        [System.Runtime.Serialization.EnumMember(Value = "Off")]
        Off = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "On")]
        On = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ForceUnocc
    {
        [System.Runtime.Serialization.EnumMember(Value = "Off")]
        Off = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "On")]
        On = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum AvailableModes
    {
        [System.Runtime.Serialization.EnumMember(Value = "AllModes")]
        AllModes = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "HeatCoolOnly")]
        HeatCoolOnly = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "HeatOnly")]
        HeatOnly = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "CoolOnly")]
        CoolOnly = 3,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Thermostat 
    {
        [Newtonsoft.Json.JsonProperty("thermostatId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid ThermostatId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsystem", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Subsystem { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bridge", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Bridge { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Mode Mode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fan", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public FanSetting Fan { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heatTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HeatTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("coolTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CoolTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public State State { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fanState", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public FanState FanState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tempUnits", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TempUnits TempUnits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("schedule", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SchedulePart Schedule { get; set; }
    
        [Newtonsoft.Json.JsonProperty("schedulePart", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SchedulePart SchedulePart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("away", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Away Away { get; set; }
    
        [Newtonsoft.Json.JsonProperty("holidy", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Holiday Holidy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("override", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Override Override { get; set; }
    
        [Newtonsoft.Json.JsonProperty("overrideTime", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int OverrideTime { get; set; }
    
        [Newtonsoft.Json.JsonProperty("forceUnocc", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ForceUnocc ForceUnocc { get; set; }
    
        [Newtonsoft.Json.JsonProperty("spaceTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SpaceTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("coolTempMin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CoolTempMin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("coolTempMax", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CoolTempMax { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heatTempMin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HeatTempMin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heatTempMax", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HeatTempMax { get; set; }
    
        [Newtonsoft.Json.JsonProperty("setPointDelta", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SetPointDelta { get; set; }
    
        [Newtonsoft.Json.JsonProperty("humidity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Humidity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("availableModes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public AvailableModes AvailableModes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static Thermostat FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Thermostat>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ThermostatInput 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsystem", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Subsystem { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bridge", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Bridge { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Mode Mode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fan", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public FanSetting Fan { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heatTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HeatTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("coolTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CoolTemp { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ThermostatInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ThermostatInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ThermostatTempInput 
    {
        [Newtonsoft.Json.JsonProperty("coolTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CoolTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heatTemp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HeatTemp { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ThermostatTempInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ThermostatTempInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserSearch 
    {
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserSearch FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserSearch>(data);
        }
    
    }
}
