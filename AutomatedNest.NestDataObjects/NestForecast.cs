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

        public int lowestForecastTemp
        {
            get
            {
                int returnValue = 200;
                
                for(int i = 0; i <= 5; i++)
                {
                    int tempValue;
                    int.TryParse(this.jsonForecastResponse.forecast.daily[i].low_temperature.ToString(), out tempValue);
                    if (tempValue < returnValue)
                    {
                        returnValue = tempValue;
                    }             
                }

                return returnValue;
            }

        }
    }
}
