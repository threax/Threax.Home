using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.Home.ValueProviders
{
    public class TemperatureProvider : LabelValuePairProvider
    {
        private int start = 65;
        private int end = 85;

        public TemperatureProvider()
        {
            
        }

        protected override async Task<IEnumerable<ILabelValuePair>> GetSources()
        {
            var labels = new List<ILabelValuePair>();
            for(var i = start; i < end; ++i)
            {
                labels.Add(new LabelValuePair<int>(i.ToString(), i));
            }
            return await Task.FromResult(labels);
        }
    }
}
