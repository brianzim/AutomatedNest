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
        public static NestForecastBase getForecast(NestCredentials credentials, string zip)
        {
            return UnofficialNestAPI.UnofficialNestAPI.getForecast(credentials, zip);
        }

        public static int calculateTargetHumidity(NestForecastBase forecast, HumidityMode mode)
        {
            return ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, mode);
        }
        
    }
}
