using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using AutomatedNest.UnofficialNestAPI;
using AutomatedNest.ThermostatEngines;

namespace AutomatedNest.ThermostatManager
{
    public static class ForecastManager
    {
        public static NestAPIForecastResponse getForecast(NestAPICredentialsResponse credentials, string zip)
        {
            UnofficialNestAPI.UnofficialNestAPI unapi = new UnofficialNestAPI.UnofficialNestAPI();
            return unapi.getForecast(credentials, zip);
        }

        public static int calculateTargetHumidity(NestAPIForecastResponse forecast, HumidityMode mode)
        {
            return ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, mode);
        }
        
    }
}
