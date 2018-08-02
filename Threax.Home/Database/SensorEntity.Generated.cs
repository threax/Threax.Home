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
using Threax.Home.Core;

namespace Threax.Home.Database 
{
    public partial class SensorEntity : ISensor, ISensorId, ICreatedModified
    {
        [Key]
        public Guid SensorId { get; set; }

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

        public double? TempValue { get; set; }

        public Units? TempUnits { get; set; }

        public double? LightValue { get; set; }

        public Units? LightUnits { get; set; }

        public double? HumidityValue { get; set; }

        public Units? HumidityUnits { get; set; }

        public double? UvValue { get; set; }

        public Units? UvUnits { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
