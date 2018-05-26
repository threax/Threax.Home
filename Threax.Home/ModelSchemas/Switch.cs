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
        public String Name { get; set; }
    }
}
