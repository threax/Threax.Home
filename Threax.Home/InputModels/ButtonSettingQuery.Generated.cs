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
    public partial class ButtonSettingQuery : PagedCollectionQuery, IButtonSettingQuery
    {
        /// <summary>
        /// Lookup a buttonSetting by id.
        /// </summary>
        public Guid? ButtonSettingId { get; set; }


        /// <summary>
        /// Populate an IQueryable for buttonSettings. Does not apply the skip or limit. Will return
        /// true if the query should be modified or false if the entire query was built and should
        /// be left alone.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>True if the query should continue to be built, false if it should be left alone.</returns>
        protected bool CreateGenerated(ref IQueryable<ButtonSettingEntity> query)
        {
            if (ButtonSettingId != null)
            {
                query = query.Where(i => i.ButtonSettingId == ButtonSettingId);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}