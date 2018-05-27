using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Threax.Home.InputModels
{
    public partial class SwitchInput
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See SwitchInput.Generated for the generated code

        public byte? Brightness { get; set; }
    }
}