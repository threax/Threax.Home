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
    public partial class ButtonStateQuery : PagedCollectionQuery, IButtonStateQuery
    {
        /// <summary>
        /// Lookup a buttonState by id.
        /// </summary>
        public Guid? ButtonStateId { get; set; }


        /// <summary>
        /// Populate an IQueryable for buttonStates. Does not apply the skip or limit. Will return
        /// true if the query should be modified or false if the entire query was built and should
        /// be left alone.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>True if the query should continue to be built, false if it should be left alone.</returns>
        protected bool CreateGenerated(ref IQueryable<ButtonStateEntity> query)
        {
            if (ButtonStateId != null)
            {
                query = query.Where(i => i.ButtonStateId == ButtonStateId);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}