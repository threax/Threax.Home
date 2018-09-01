using System;
using Threax.Home.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Threax.Home.InputModels
{
    public partial class ButtonQuery
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
                //Customize query further
            }

            return Task.FromResult(query);
        }
    }
}