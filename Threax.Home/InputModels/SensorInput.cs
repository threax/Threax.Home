using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Core;
using Threax.Home.Models;

namespace Threax.Home.InputModels
{
    [HalModel]
    [CacheEndpointDoc]
    public partial class SensorInput : ISensor
    {
        [Required(ErrorMessage = "Name must have a value.")]
        [MaxLength(450, ErrorMessage = "Name must be less than 450 characters.")]
        [UiOrder(0, 20)]
        public String Name { get; set; }

        [Required(ErrorMessage = "Subsystem must have a value.")]
        [MaxLength(450, ErrorMessage = "Subsystem must be less than 450 characters.")]
        [UiOrder(0, 28)]
        public String Subsystem { get; set; }

        [Required(ErrorMessage = "Bridge must have a value.")]
        [MaxLength(450, ErrorMessage = "Bridge must be less than 450 characters.")]
        [UiOrder(0, 36)]
        public String Bridge { get; set; }

        [Required(ErrorMessage = "Id must have a value.")]
        [MaxLength(450, ErrorMessage = "Id must be less than 450 characters.")]
        [UiOrder(0, 44)]
        public String Id { get; set; }

        [UiOrder(0, 47)]
        public double? TempValue { get; set; }

        [UiOrder(0, 50)]
        public Units? TempUnits { get; set; }

        [UiOrder(0, 53)]
        public double? LightValue { get; set; }

        [UiOrder(0, 56)]
        public Units? LightUnits { get; set; }

        [UiOrder(0, 59)]
        public double? HumidityValue { get; set; }

        [UiOrder(0, 62)]
        public Units? HumidityUnits { get; set; }

        [UiOrder(0, 65)]
        public double? UvValue { get; set; }

        [UiOrder(0, 68)]
        public Units? UvUnits { get; set; }
    }
}