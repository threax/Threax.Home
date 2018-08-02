using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Core;

namespace Threax.Home.Models 
{
    public partial interface ISensor 
    {
        String Name { get; set; }

        String Subsystem { get; set; }

        String Bridge { get; set; }

        String Id { get; set; }

        double? TempValue { get; set; }

        Units? TempUnits { get; set; }

        double? LightValue { get; set; }

        Units? LightUnits { get; set; }

        double? HumidityValue { get; set; }

        Units? HumidityUnits { get; set; }

        double? UvValue { get; set; }

        Units? UvUnits { get; set; }

    }

    public partial interface ISensorId
    {
        Guid SensorId { get; set; }
    }    

    public partial interface ISensorQuery
    {
        Guid? SensorId { get; set; }

    }
}