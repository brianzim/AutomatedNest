using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomatedNest.NestDataObjects
{
    public class NestForecast
    {
        dynamic jsonForecastResponse;

        public NestForecast(string jsonForecastResponse)
        {
            this.jsonForecastResponse = JObject.Parse(jsonForecastResponse);

            /* this.jsonForecastResponse.forecast.daily[0].low_temperature */
        }

        public string todayLowTemp
        {
            get
            {
                return this.jsonForecastResponse.forecast.daily[0].low_temperature.ToString();
            }

        }
    }
}
