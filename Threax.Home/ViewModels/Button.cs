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
    [HalSelfActionLink(typeof(ButtonsController), nameof(ButtonsController.Get))]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Update))]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Delete))]
    public partial class Button
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See Button.Generated for the generated code
        public List<ButtonSetting> ButtonSettings { get; set; }
    }
}