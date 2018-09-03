using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Threax.Home.Database
{
    public partial class SwitchSettingEntity
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See SwitchSettingEntity.Generated for the generated code

        public SwitchEntity Switch { get; set; }
    }
}