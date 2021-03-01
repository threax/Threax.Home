using System;
using Threax.Home.Database;
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
    public partial class ThermostatQuery : PagedCollectionQuery, IThermostatQuery
    {
        /// <summary>
        /// Lookup a thermostat by id.
        /// </summary>
        public Guid? ThermostatId { get; set; }

        /// <summary>
        /// Update the status of the requested thermostat. Only works if ThermostatId is set.
        /// </summary>
        public bool UpdateStatus { get; set; }


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

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<ThermostatEntity>> Create(IQueryable<ThermostatEntity> query)
        {
            if(CreateGenerated(ref query))
            {
                //Customize query further
            }

            return Task.FromResult(query);
        }
    }
}