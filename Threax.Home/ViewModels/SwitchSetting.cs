using Halcyon.HAL.Attributes;
using System;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.AspNetCore.Models;
using Threax.Home.Models;

namespace Threax.Home.ViewModels
{
    [HalModel]
    public partial class SwitchSetting : ISwitchSetting, ISwitchSettingId
    {
        public Guid SwitchSettingId { get; set; }

        [ValueProvider(typeof(Threax.Home.ValueProviders.SwitchValueProvider))]
        public Guid SwitchId { get; set; }

        public String Value { get; set; }

        public int? Brightness { get; set; }

        public String HexColor { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

        public Switch Switch { get; set; }
    }
}