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
        //Customize main interface here, see Sensor.Generated for generated code
    }  

    public partial interface ISensorId
    {
        //Customize id interface here, see Sensor.Generated for generated code
    }    

    public partial interface ISensorQuery
    {
        //Customize query interface here, see Sensor.Generated for generated code
    }
}