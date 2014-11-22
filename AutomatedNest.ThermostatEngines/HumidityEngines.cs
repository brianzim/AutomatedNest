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
        public static int calculateOptimalHumidity(int lowestForecastTemperature, HumidityMode mode)
        {
            // Calculations Based On AprilAire: http://www.aprilaire.com/docs/default-source/product-owners-manuals/humidifier/aprilaire-humidifier-model-700-owners-manual.pdf?Status=Master&sfvrsn=6

            
            if (mode == HumidityMode.Normal) {
                if (lowestForecastTemperature >= 40) { return 45; }
                else if (lowestForecastTemperature >= 30) { return 40; }
                else if (lowestForecastTemperature >= 20) { return 35; }
                else if (lowestForecastTemperature >= 10) { return 30; }
                else if (lowestForecastTemperature >= 0) { return 25; }
                else if (lowestForecastTemperature >= -10) { return 20; }
                else { return 15; }
            }

            else if (mode == HumidityMode.Aggressive)
            {
                if (lowestForecastTemperature >= 40) { return 45; }
                else if (lowestForecastTemperature >= 30) { return 45; }
                else if (lowestForecastTemperature >= 20) { return 45; }
                else if (lowestForecastTemperature >= 10) { return 40; }
                else if (lowestForecastTemperature >= 0) { return 35; }
                else if (lowestForecastTemperature >= -10) { return 30; }
                else { return 25; }
            }

            else if (mode == HumidityMode.Conservative)
            {
                if (lowestForecastTemperature >= 40) { return 30; }
                else if (lowestForecastTemperature >= 30) { return 25; }
                else if (lowestForecastTemperature >= 20) { return 20; }
                else if (lowestForecastTemperature >= 10) { return 15; }
                else if (lowestForecastTemperature >= 0) { return 10; }
                else if (lowestForecastTemperature >= -10) { return 10; }
                else { return 10; }
            }
            else
            {
                return 15;
            }
            
        }

        public static int findLowestTemperature(NestAPIForecastResponse forecast)
        {
            int returnValue = 200;

            double currentTempDecimal;
            Double.TryParse(forecast.now.current_temperature, out currentTempDecimal);

            currentTempDecimal = currentTempDecimal * (9.0 / 5.0) + 32;

            int currentTemp = (int)currentTempDecimal;

            if (currentTemp < returnValue)
            {
                returnValue = currentTemp;
            }

            // Find lowest value for hourly forecasts
            foreach (NestHourlyForecast nhf in forecast.forecast.hourly)
            {
                if (nhf.temp < returnValue) { returnValue = nhf.temp; }
            }

            // See if there is lower value for upcoming daily forecasts
            foreach (NestDailyForecast ndf in forecast.forecast.daily)
            {
                if (ndf.low_temperature < returnValue) { returnValue = ndf.low_temperature; }
            }

            return returnValue;
        }
    }
}
