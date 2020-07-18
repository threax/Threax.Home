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
    public partial class SensorQuery : PagedCollectionQuery, ISensorQuery
    {
        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<SensorEntity>> Create(IQueryable<SensorEntity> query)
        {
            if(CreateGenerated(ref query))
            {
                //Customize query further
            }

            return Task.FromResult(query);
        }

        /// <summary>
        /// Lookup a sensor by id.
        /// </summary>
        public Guid? SensorId { get; set; }


        /// <summary>
        /// Populate an IQueryable for sensors. Does not apply the skip or limit. Will return
        /// true if the query should be modified or false if the entire query was built and should
        /// be left alone.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>True if the query should continue to be built, false if it should be left alone.</returns>
        protected bool CreateGenerated(ref IQueryable<SensorEntity> query)
        {
            if (SensorId != null)
            {
                query = query.Where(i => i.SensorId == SensorId);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}