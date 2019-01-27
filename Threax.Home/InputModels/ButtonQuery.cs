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
    public partial class ButtonQuery : PagedCollectionQuery, IButtonQuery
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See ButtonQuery.Generated for the generated code

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<ButtonEntity>> Create(IQueryable<ButtonEntity> query)
        {
            if(CreateGenerated(ref query))
            {
                if (!IncludeButler)
                {
                    //TODO: Improve this once localdb can handle adding
                    //foreign keys. Can add categories then.
                    //This requires no db changes, just adds a special name
                    query = query.Where(i => i.Label != "_Butler");
                }

                //Customize query further
                query = query.OrderBy(i => i.Order);
            }

            return Task.FromResult(query);
        }

        /// <summary>
        /// Lookup a button by id.
        /// </summary>
        public Guid? ButtonId { get; set; }

        public bool IncludeButler { get; set; } = false;


        /// <summary>
        /// Populate an IQueryable for buttons. Does not apply the skip or limit. Will return
        /// true if the query should be modified or false if the entire query was built and should
        /// be left alone.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>True if the query should continue to be built, false if it should be left alone.</returns>
        protected bool CreateGenerated(ref IQueryable<ButtonEntity> query)
        {
            if (ButtonId != null)
            {
                query = query.Where(i => i.ButtonId == ButtonId);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}