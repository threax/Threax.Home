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
    public partial class SwitchInput : ISwitch
    {
        [Required(ErrorMessage = "Name must have a value.")]
        [MaxLength(450, ErrorMessage = "Name must be less than 450 characters.")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Subsystem must have a value.")]
        [MaxLength(450, ErrorMessage = "Subsystem must be less than 450 characters.")]
        public String Subsystem { get; set; }

        [Required(ErrorMessage = "Bridge must have a value.")]
        [MaxLength(450, ErrorMessage = "Bridge must be less than 450 characters.")]
        public String Bridge { get; set; }

        [Required(ErrorMessage = "Id must have a value.")]
        [MaxLength(450, ErrorMessage = "Id must be less than 450 characters.")]
        public String Id { get; set; }

        [MaxLength(450, ErrorMessage = "Value must be less than 450 characters.")]
        public String Value { get; set; }

        [MaxLength(450, ErrorMessage = "Hex Color must be less than 450 characters.")]
        public String HexColor { get; set; }

    }
}
