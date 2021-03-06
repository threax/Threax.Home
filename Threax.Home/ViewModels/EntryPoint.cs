﻿using Halcyon.HAL.Attributes;
using Threax.Home.Controllers.Api;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.UserBuilder.Entities.Mvc;
using Threax.AspNetCore.UserLookup.Mvc.Controllers;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalEntryPoint]
    [HalSelfActionLink(typeof(EntryPointController), nameof(EntryPointController.Get))]
    //This first set of links is for role editing, you can erase them if you don't have users or roles.
    [HalActionLink(RolesControllerRels.GetUser, typeof(RolesController))]
    [HalActionLink(RolesControllerRels.ListUsers, typeof(RolesController))]
    [HalActionLink(RolesControllerRels.SetUser, typeof(RolesController))]
    //The additional entry point links are in the other entry point partial classes, expand this node to see them
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.AddNewSwitches))]
    [HalActionLink(typeof(SensorsController), nameof(SensorsController.AddNewSensors))]
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.AddNewThermostats))]
    [HalActionLink(typeof(UserSearchController), nameof(UserSearchController.List), "ListAppUsers")]
    [HalActionLink(typeof(ButtonStatesController), nameof(ButtonStatesController.List), "ListButtonStates")]
    [HalActionLink(typeof(AppCommandsController), nameof(AppCommandsController.List), "ListAppCommands")]
    public partial class EntryPoint
    {
    }
}
