using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.Home.Models;

namespace Threax.Home.Database 
{
    public partial class SwitchEntity : ISwitch, ISwitchId, ICreatedModified
    {
        [Key]
        public Guid SwitchId { get; set; }

        [Required(ErrorMessage = "Subsystem must have a value.")]
        [MaxLength(450, ErrorMessage = "Subsystem must be less than 450 characters.")]
        public String Subsystem { get; set; }

        [Required(ErrorMessage = "Bridge must have a value.")]
        [MaxLength(450, ErrorMessage = "Bridge must be less than 450 characters.")]
        public String Bridge { get; set; }

        [Required(ErrorMessage = "Id must have a value.")]
        [MaxLength(450, ErrorMessage = "Id must be less than 450 characters.")]
        public String Id { get; set; }

        [Required(ErrorMessage = "Value must have a value.")]
        [MaxLength(450, ErrorMessage = "Value must be less than 450 characters.")]
        public String Value { get; set; }

        [Required(ErrorMessage = "Brightness must have a value.")]
        public int Brightness { get; set; }

        [Required(ErrorMessage = "Hex Color must have a value.")]
        [MaxLength(450, ErrorMessage = "Hex Color must be less than 450 characters.")]
        public String HexColor { get; set; }

        [Required(ErrorMessage = "Name must have a value.")]
        [MaxLength(450, ErrorMessage = "Name must be less than 450 characters.")]
        public String Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
