using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ColorTouchSharp
{
    public class ColorTouchClient
    {
        public ColorTouchClient(String host)
        {
            this.Host = host;
        }

        public String Host { get; set; }

        public int MinDelta { get; set; } = 5;

        public async Task<ApiInfo> GetApiInfoAsync()
        {
            HttpClient client = new HttpClient();
            string stringResult = await client.GetStringAsync(new Uri(Host)).ConfigureAwait(false);

            JToken token = JToken.Parse(stringResult);

            return token.ToObject<ApiInfo>();
        }

        public async Task<ThermostatStatus> GetStatusAsync()
        {
            HttpClient client = new HttpClient();
            string stringResult = await client.GetStringAsync(new Uri(String.Format("{0}/query/info", Host))).ConfigureAwait(false);

            JToken token = JToken.Parse(stringResult);

            return token.ToObject<ThermostatStatus>();
        }

        public async Task<bool> ChangeSettingsAsync(ThermostatSetting setting)
        {
            if (setting.CoolTemp - setting.HeatTemp < MinDelta)
            {
                setting.HeatTemp = setting.CoolTemp - MinDelta;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Host);
            var request = new HttpRequestMessage(HttpMethod.Post, "/control");

            request.Content = new FormUrlEncodedContent(setting.getValues());
            var response = await client.SendAsync(request);
            var responseString = response.Content.ReadAsStringAsync();
            return responseString.Result == "{\"success\":true}";
        }
    }
}
