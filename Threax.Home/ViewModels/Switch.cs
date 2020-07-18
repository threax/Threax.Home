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
using Threax.AspNetCore.Tracking;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [CacheEndpointDoc]
    [HalSelfActionLink(typeof(SwitchesController), nameof(SwitchesController.Get))]
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Update))]
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Set))]
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Delete))]
    public partial class Switch : ISwitch, ISwitchId, ICreatedModified
    {
        public Guid SwitchId { get; set; }

        public String Name { get; set; }

        public String Value { get; set; }

        public String HexColor { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

        public byte? Brightness { get; set; }
    }
}