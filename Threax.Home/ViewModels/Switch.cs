using Halcyon.HAL.Attributes;
using System;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Controllers.Api;
using Threax.Home.Models;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [CacheEndpointDoc]
    [HalSelfActionLink(typeof(SwitchesController), nameof(SwitchesController.Get))]
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Update))]
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Set))]
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Delete))]
    public partial class Switch : ISwitch, ISwitchId
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