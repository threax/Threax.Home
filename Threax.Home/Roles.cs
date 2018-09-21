using Halcyon.HAL.Attributes;
using Threax.Home.Controllers.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.UserBuilder.Entities.Mvc;
using Threax.AspNetCore.Models;

namespace Threax.Home
{
    /// <summary>
    /// This class makes it easy to keep track of role constants throught the system.
    /// </summary>
    public static class Roles
    {
        public const String EditButtons = nameof(EditButtons);

        public const String EditSensors = nameof(EditSensors);

        public const String EditSwitches = nameof(EditSwitches);

        public const String EditThermostats = nameof(EditThermostats);

        public const String EditThermostatSettings = nameof(EditThermostatSettings);

        /// <summary>
        /// All roles, any roles added above that you want to add to the database should be defined here.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<String> DatabaseRoles()
        {
            yield return EditButtons;
            yield return EditSensors;
            yield return EditSwitches;
            yield return EditThermostats;
            yield return EditThermostatSettings;
        }
    }

    [HalModel]
    [HalSelfActionLink(RolesControllerRels.GetUser, typeof(RolesController))]
    [HalActionLink(RolesControllerRels.SetUser, typeof(RolesController))]
    [HalActionLink(RolesControllerRels.DeleteUser, typeof(RolesController))]
    public class RoleAssignments : ReflectedRoleAssignments
    {
        [UiOrder]
        public bool EditButtons { get; set; }

        [UiOrder]
        public bool EditSensors { get; set; }

        [UiOrder]
        public bool EditSwitches { get; set; }

        [UiOrder]
        public bool EditThermostats { get; set; }

        [UiOrder]
        public bool EditThermostatSettings { get; set; }
    }
}
