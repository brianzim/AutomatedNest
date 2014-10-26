using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;

namespace AutomatedNest.ThermostatEngines
{
    public static class HumidityEngines
    {
        public static int calculateOptimalHumidity(NestForecast forecast)
        {
            if (forecast.LowestForecastTemp >= 40) { return 45; }
            else if (forecast.LowestForecastTemp >= 30) { return 40; }
            else if (forecast.LowestForecastTemp >= 20) { return 35; }
            else if (forecast.LowestForecastTemp >= 10) { return 30; }
            else if (forecast.LowestForecastTemp >= 0) { return 25; }
            else if (forecast.LowestForecastTemp >= -10) { return 20; }
            else { return 15; }
            
        }
    }
}
