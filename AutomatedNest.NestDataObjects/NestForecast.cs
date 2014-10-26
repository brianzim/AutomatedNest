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
        JObject jsonForecastResponse;

        public NestForecast(string jsonForecastResponse)
        {
            this.jsonForecastResponse = JObject.Parse(jsonForecastResponse);
        }

        public int LowestForecastTemp
        {
            get
            {
                int returnValue = 200;
                
                for(int i = 0; i <= 5; i++)
                {
                    int tempValue;
                    int.TryParse(this.jsonForecastResponse["forecast"]["daily"][i]["low_temperature"].ToString(), out tempValue);
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
