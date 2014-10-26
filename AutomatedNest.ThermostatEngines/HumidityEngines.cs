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
        public enum HumidityMode
        {
            Normal = 5,
            Aggressive = 7,
            Conservative = 2,
        }
        public static int calculateOptimalHumidity(NestForecast forecast, HumidityMode mode)
        {
            // Calculations Based On AprilAire: http://www.aprilaire.com/docs/default-source/product-owners-manuals/humidifier/aprilaire-humidifier-model-700-owners-manual.pdf?Status=Master&sfvrsn=6

            
            if (mode == HumidityMode.Normal) {
                    if (forecast.LowestForecastTemp >= 40) { return 45; }
                    else if (forecast.LowestForecastTemp >= 30) { return 40; }
                    else if (forecast.LowestForecastTemp >= 20) { return 35; }
                    else if (forecast.LowestForecastTemp >= 10) { return 30; }
                    else if (forecast.LowestForecastTemp >= 0) { return 25; }
                    else if (forecast.LowestForecastTemp >= -10) { return 20; }
                    else { return 15; }
            }

            else if (mode == HumidityMode.Aggressive)
            {
                    if (forecast.LowestForecastTemp >= 40) { return 45; }
                    else if (forecast.LowestForecastTemp >= 30) { return 45; }
                    else if (forecast.LowestForecastTemp >= 20) { return 45; }
                    else if (forecast.LowestForecastTemp >= 10) { return 40; }
                    else if (forecast.LowestForecastTemp >= 0) { return 35; }
                    else if (forecast.LowestForecastTemp >= -10) { return 30; }
                    else { return 25; }
            }

            else if (mode == HumidityMode.Conservative)
            {
                if (forecast.LowestForecastTemp >= 40) { return 30; }
                else if (forecast.LowestForecastTemp >= 30) { return 25; }
                else if (forecast.LowestForecastTemp >= 20) { return 20; }
                else if (forecast.LowestForecastTemp >= 10) { return 15; }
                else if (forecast.LowestForecastTemp >= 0) { return 10; }
                else if (forecast.LowestForecastTemp >= -10) { return 10; }
                else { return 10; }
            }
            else
            {
                return 15;
            }
            
        }
    }
}
