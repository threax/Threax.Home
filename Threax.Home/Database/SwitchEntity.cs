using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Core;

namespace Threax.Home.Database
{
    public partial class SwitchEntity : ICoreSwitch
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See SwitchEntity.Generated for the generated code

        public byte? Brightness { get; set; }

        public List<SwitchSettingEntity> SwitchSettings { get; set; }
    }
}