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
    [HalSelfActionLink(typeof(SwitchesController), nameof(SwitchesController.Get))]
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Update))]
    //[HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Delete))]
    public partial class Switch
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See Switch.Generated for the generated code

        public byte? Brightness { get; set; }
    }
}