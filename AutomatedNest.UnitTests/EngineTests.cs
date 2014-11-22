using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedNest.ThermostatEngines;
using AutomatedNest.NestDataObjects;
using AutomatedNest.UnofficialNestAPI;

namespace AutomatedNest.UnitTests
{
    [TestClass]
    public class EngineTests
    {

       private NestAPIForecastResponse BuildForecast()
        {
           MockForecastAccessor mfa = new MockForecastAccessor();
           NestAPIForecastResponse forecast = mfa.getForecast(new NestAPICredentialsResponse(), "XXXXX");

           return forecast;
        }

        [TestMethod]
        public void HumidityEngineConservativeMode()
        {
            int targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(50, HumidityMode.Conservative);
            Assert.AreEqual(30, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(40, HumidityMode.Conservative);
            Assert.AreEqual(30, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(39, HumidityMode.Conservative);
            Assert.AreEqual(25, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(30, HumidityMode.Conservative);
            Assert.AreEqual(25, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(29, HumidityMode.Conservative);
            Assert.AreEqual(20, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(20, HumidityMode.Conservative);
            Assert.AreEqual(20, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(19, HumidityMode.Conservative);
            Assert.AreEqual(15, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(10, HumidityMode.Conservative);
            Assert.AreEqual(15, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(9, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(0, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(-1, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(-10, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(-50, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);
        }

        [TestMethod]
        public void HumidityEngineNormalMode()
        {
            int targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(50, HumidityMode.Normal);
            Assert.AreEqual(45, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(40, HumidityMode.Normal);
            Assert.AreEqual(45, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(39, HumidityMode.Normal);
            Assert.AreEqual(40, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(30, HumidityMode.Normal);
            Assert.AreEqual(40, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(29, HumidityMode.Normal);
            Assert.AreEqual(35, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(20, HumidityMode.Normal);
            Assert.AreEqual(35, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(19, HumidityMode.Normal);
            Assert.AreEqual(30, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(10, HumidityMode.Normal);
            Assert.AreEqual(30, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(9, HumidityMode.Normal);
            Assert.AreEqual(25, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(0, HumidityMode.Normal);
            Assert.AreEqual(25, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(-1, HumidityMode.Normal);
            Assert.AreEqual(20, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(-10, HumidityMode.Normal);
            Assert.AreEqual(20, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(-50, HumidityMode.Normal);
            Assert.AreEqual(15, targetHumidity);
        }

        [TestMethod]
        public void HumidityEngineAggressiveMode()
        {
            int targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(50, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(40, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(39, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(30, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(29, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(20, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(19, HumidityMode.Aggressive);
            Assert.AreEqual(40, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(10, HumidityMode.Aggressive);
            Assert.AreEqual(40, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(9, HumidityMode.Aggressive);
            Assert.AreEqual(35, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(0, HumidityMode.Aggressive);
            Assert.AreEqual(35, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(-1, HumidityMode.Aggressive);
            Assert.AreEqual(30, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(-10, HumidityMode.Aggressive);
            Assert.AreEqual(30, targetHumidity);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(-50, HumidityMode.Aggressive);
            Assert.AreEqual(25, targetHumidity);
        }
        
        [TestMethod]
        public void TestLowTemperatureCalculation()
        {
            NestAPIForecastResponse forecast = BuildForecast();
            string stringStateResetValue;
            int intStateResetValue;

            // Test Base Object
            Assert.AreEqual(8, ThermostatEngines.HumidityEngines.findLowestTemperature(forecast));
            
            // Test Low As Current Tempearture (this one is only value expressed in C)
            stringStateResetValue = forecast.now.current_temperature;
            forecast.now.current_temperature = "-18";
            Assert.AreEqual(0, ThermostatEngines.HumidityEngines.findLowestTemperature(forecast));
            forecast.now.current_temperature = stringStateResetValue;

            // Test First Element of Hourly Forecast as Low
            intStateResetValue = forecast.forecast.hourly[0].temp;
            forecast.forecast.hourly[0].temp = 1;
            Assert.AreEqual(1, ThermostatEngines.HumidityEngines.findLowestTemperature(forecast));
            forecast.forecast.hourly[0].temp = intStateResetValue;

            // Test Middle Element of Hourly Forecast as Low
            intStateResetValue = forecast.forecast.hourly[25].temp;
            forecast.forecast.hourly[25].temp = 2;
            Assert.AreEqual(2, ThermostatEngines.HumidityEngines.findLowestTemperature(forecast));
            forecast.forecast.hourly[25].temp = intStateResetValue;

            // Test last (48th) Element of Hourly Forecast as Low
            intStateResetValue = forecast.forecast.hourly[0].temp;
            forecast.forecast.hourly[47].temp = 3;
            Assert.AreEqual(3, ThermostatEngines.HumidityEngines.findLowestTemperature(forecast));
            forecast.forecast.hourly[47].temp = intStateResetValue;

            // Test first element of daily forecast
            intStateResetValue = forecast.forecast.daily[0].low_temperature;
            forecast.forecast.daily[0].low_temperature = 4;
            Assert.AreEqual(4, ThermostatEngines.HumidityEngines.findLowestTemperature(forecast));
            forecast.forecast.daily[0].low_temperature = intStateResetValue;

            // Test middle element of daily forecast
            intStateResetValue = forecast.forecast.daily[2].low_temperature;
            forecast.forecast.daily[2].low_temperature = 5;
            Assert.AreEqual(5, ThermostatEngines.HumidityEngines.findLowestTemperature(forecast));
            forecast.forecast.daily[2].low_temperature = intStateResetValue;

            // Test last element of daily forecast
            intStateResetValue = forecast.forecast.daily[5].low_temperature;
            forecast.forecast.daily[5].low_temperature = 6;
            Assert.AreEqual(6, ThermostatEngines.HumidityEngines.findLowestTemperature(forecast));
            forecast.forecast.daily[5].low_temperature = intStateResetValue;
        }
    }
}
