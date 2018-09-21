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
    [HalModel]
    public class SetSwitchInput
    {
        [MaxLength(450, ErrorMessage = "Value must be less than 450 characters.")]
        public String Value { get; set; }

        public byte? Brightness { get; set; }

        [MaxLength(450, ErrorMessage = "Hex Color must be less than 450 characters.")]
        public String HexColor { get; set; }
    }
}