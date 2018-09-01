using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Models;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.Home.InputModels 
{
    [HalModel]
    public partial class ButtonSettingInput : IButtonSetting
    {
        [ValueProvider(typeof(Threax.Home.ValueProviders.SwitchValueProvider))]
        public Guid SwitchId { get; set; }

        public String Value { get; set; }

        public int? Brightness { get; set; }

        [MaxLength(450, ErrorMessage = "Hex Color must be less than 450 characters.")]
        public String HexColor { get; set; }

    }
}
