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
    public partial interface ISensor : ICoreSensor
    {


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