using System;
using Threax.Home.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.Home.Models;

namespace Threax.Home.InputModels
{
    [HalModel]
    public partial class ThermostatSettingQuery : PagedCollectionQuery, IThermostatSettingQuery
    {
        /// <summary>
        /// Lookup a thermostatSetting by id.
        /// </summary>
        public Guid? ThermostatSettingId { get; set; }

        [UiOrder]
        [Display(Name = "Thermostat")]
        [UiSearch]
        [ValueProvider(typeof(Threax.Home.ValueProviders.ThermostatProvider))]
        public Guid? ThermostatId { get; set; }


        /// <summary>
        /// Populate an IQueryable for thermostatSettings. Does not apply the skip or limit. Will return
        /// true if the query should be modified or false if the entire query was built and should
        /// be left alone.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>True if the query should continue to be built, false if it should be left alone.</returns>
        protected bool CreateGenerated(ref IQueryable<ThermostatSettingEntity> query)
        {
            if (ThermostatSettingId != null)
            {
                query = query.Where(i => i.ThermostatSettingId == ThermostatSettingId);
                return false;
            }
            else
            {
                if (ThermostatId != null)
                {
                    query = query.Where(i => i.ThermostatId == ThermostatId);
                }

                return true;
            }
        }

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<ThermostatSettingEntity>> Create(IQueryable<ThermostatSettingEntity> query)
        {
            if(CreateGenerated(ref query))
            {
                //Customize query further
            }

            return Task.FromResult(query);
        }
    }
}