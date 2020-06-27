using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.Home.ValueProviders
{
    public class SwitchValueProvider : LabelValuePairProvider
    {
        private Repository.ISwitchRepository repo;

        public SwitchValueProvider(Repository.ISwitchRepository repo)
        {
            this.repo = repo;
        }

        protected override Task<IEnumerable<ILabelValuePair>> GetSources()
        {
            return repo.GetSwitchLabels();
        }
    }
}
