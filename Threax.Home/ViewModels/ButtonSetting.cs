using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Models;
using Threax.Home.Controllers.Api;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.Get))]
    [HalActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.Update))]
    [HalActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.Delete))]
    public partial class ButtonSetting
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See ButtonSetting.Generated for the generated code
    }
}