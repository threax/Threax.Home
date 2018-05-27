using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Threax.Home.ModelSchemas
{
    //[RequireAuthorization(typeof(Roles), nameof(Roles.EditValues))]
    [PluralName("Switches")]
    public abstract class Switch
    {
        [Required]
        [MaxLength(450)]
        public String Subsystem { get; set; }

        [Required]
        [MaxLength(450)]
        public String Bridge { get; set; }

        /// <summary>
        /// The id of the switch.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public String Id { get; set; }

        /// <summary>
        /// The value of the switch.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public String Value { get; set; }

        /// <summary>
        /// The brightness to set.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public byte? Brightness { get; set; }

        /// <summary>
        /// The color to set.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string HexColor { get; set; }

        /// <summary>
        /// The name of the light.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public String Name { get; set; }
    }
}
