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
using Threax.Home.Controllers.Api;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.Home.Core;

namespace Threax.Home.ViewModels 
{
       public partial class Sensor : ISensor, ISensorId, ICreatedModified
       {
        public Guid SensorId { get; set; }

        [UiOrder(0, 20)]
        public String Name { get; set; }

        [UiOrder(0, 28)]
        public String Subsystem { get; set; }

        [UiOrder(0, 36)]
        public String Bridge { get; set; }

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

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
