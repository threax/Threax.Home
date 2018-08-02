using Halcyon.HAL.Attributes;
using Threax.Home.Controllers;
using Threax.Home.Models;
using Threax.Home.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.AspNetCore.Models;
using System.ComponentModel.DataAnnotations;
using Threax.Home.Core;

namespace Threax.Home.InputModels
{
    [HalModel]
    public partial class ThermostatQuery : PagedCollectionQuery, IThermostatQuery
    {
        /// <summary>
        /// Lookup a thermostat by id.
        /// </summary>
        public Guid? ThermostatId { get; set; }


        /// <summary>
        /// Populate an IQueryable for thermostats. Does not apply the skip or limit. Will return
        /// true if the query should be modified or false if the entire query was built and should
        /// be left alone.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>True if the query should continue to be built, false if it should be left alone.</returns>
        protected bool CreateGenerated(ref IQueryable<ThermostatEntity> query)
        {
            if (ThermostatId != null)
            {
                query = query.Where(i => i.ThermostatId == ThermostatId);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}