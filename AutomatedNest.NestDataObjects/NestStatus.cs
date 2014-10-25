using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomatedNest.NestDataObjects
{
    public class NestStatus
    {
        dynamic jsonForecastResponse;

        public NestStatus(string jsonForecastResponse)
        {
            this.jsonForecastResponse = JObject.Parse(jsonForecastResponse);
        }
    }
}
