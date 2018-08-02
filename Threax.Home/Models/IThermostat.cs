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
    public partial interface IThermostat
    {
        //Customize main interface here, see Thermostat.Generated for generated code
    }  

    public partial interface IThermostatId
    {
        //Customize id interface here, see Thermostat.Generated for generated code
    }    

    public partial interface IThermostatQuery
    {
        //Customize query interface here, see Thermostat.Generated for generated code
    }
}