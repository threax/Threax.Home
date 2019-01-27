using System;
using Threax.Home.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Models;

namespace Threax.Home.InputModels
{
    [HalModel]
    public partial class SwitchQuery : PagedCollectionQuery, ISwitchQuery
    {
        public List<Guid> SwitchIds { get; set; }

        /// <summary>
        /// Get the current status of the switches in the query results. 
        /// Will take longer while the switch info is loaded.
        /// </summary>
        public bool GetStatus { get; set; } = false;

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<SwitchEntity>> Create(IQueryable<SwitchEntity> query)
        {
            if(CreateGenerated(ref query))
            {
                //Customize query further
                if(SwitchIds != null)
                {
                    query = query.Where(i => SwitchIds.Contains(i.SwitchId));
                }

                query = query.OrderBy(i => i.Name);
            }

            return Task.FromResult(query);
        }

        /// <summary>
        /// Lookup a @switch by id.
        /// </summary>
        public Guid? SwitchId { get; set; }


        /// <summary>
        /// Populate an IQueryable for switches. Does not apply the skip or limit. Will return
        /// true if the query should be modified or false if the entire query was built and should
        /// be left alone.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>True if the query should continue to be built, false if it should be left alone.</returns>
        protected bool CreateGenerated(ref IQueryable<SwitchEntity> query)
        {
            if (SwitchId != null)
            {
                query = query.Where(i => i.SwitchId == SwitchId);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}