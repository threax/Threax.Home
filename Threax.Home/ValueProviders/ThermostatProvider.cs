using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.Home.ValueProviders
{
    public class ThermostatProvider : LabelValuePairProvider
    {
        private Repository.IThermostatRepository repo;

        public ThermostatProvider(Repository.IThermostatRepository repo)
        {
            this.repo = repo;
        }

        protected override Task<IEnumerable<ILabelValuePair>> GetSources()
        {
            return repo.GetLabels();
        }
    }
}
