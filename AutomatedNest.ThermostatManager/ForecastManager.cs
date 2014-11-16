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
    public class ForecastManager : ManagerBase
    {
        public NestAPIForecastResponse getForecast(NestAPICredentialsResponse credentials, string zip)
        {
            var nestapi = AccessorFactory.Create<IUnofficialNestAPI>();
            return nestapi.getForecast(credentials, zip);
        }

        public int calculateTargetHumidity(NestAPIForecastResponse forecast, HumidityMode mode)
        {
            return ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, mode);
        }
        
    }
}
