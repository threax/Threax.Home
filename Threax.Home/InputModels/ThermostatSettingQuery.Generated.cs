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

namespace Threax.Home.InputModels
{
    [HalModel]
    public partial class ThermostatSettingQuery : PagedCollectionQuery, IThermostatSettingQuery
    {
        /// <summary>
        /// Lookup a thermostatSetting by id.
        /// </summary>
        public Guid? ThermostatSettingId { get; set; }


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
                return true;
            }
        }
    }
}