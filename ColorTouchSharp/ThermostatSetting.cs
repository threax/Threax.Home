using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace ColorTouchSharp
{
    public class ThermostatSetting
    {
        public ThermostatSetting()
        {
            Mode = Mode.Auto;
            Fan = FanSetting.Auto;
            HeatTemp = 68;
            CoolTemp = 80;
        }

        public Mode Mode { get; set; }

        public FanSetting Fan { get; set; }

        public int HeatTemp { get; set; }

        public int CoolTemp { get; set; }

        internal IEnumerable<KeyValuePair<String, String>> getValues()
        {
            yield return new KeyValuePair<string, string>("mode", ((int)Mode).ToString());
            yield return new KeyValuePair<string, string>("fan", ((int)Fan).ToString());
            yield return new KeyValuePair<string, string>("heattemp", HeatTemp.ToString());
            yield return new KeyValuePair<string, string>("cooltemp", CoolTemp.ToString());
        }
    }
}
