using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using AutomatedNest.UnofficialNestAPI;
using AutomatedNest.ThermostatEngines;

namespace AutomatedNest.ForecastManager
{
    public static class ForecastManager
    {
        public static NestForecast getForecast(NestCredentials credentials, string zip)
        {
            return UnofficialNestAPI.UnofficialNestAPI.getForecast(credentials, zip);
        }

        public static int calculateTargetHumidity(NestForecast forecast, int mode)
        {
            return ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, mode);
        }
        
    }
}
