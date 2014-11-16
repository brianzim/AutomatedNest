using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedNest.ThermostatEngines;
using AutomatedNest.NestDataObjects;

namespace AutomatedNest.UnitTests
{
    [TestClass]
    public class EngineTests
    {

       private NestAPIForecastResponse buildForecast()
        {

           NestAPIForecastResponse forecast = new NestAPIForecastResponse();
           forecast.forecast = new NestFutureForecast();


           NestDailyForecast ndf = new NestDailyForecast();
           ndf.low_temperature = 70;
           forecast.forecast.daily = new System.Collections.Generic.List<NestDailyForecast>();
           forecast.forecast.daily.Add(ndf);

           NestHourlyForecast nhf = new NestHourlyForecast();
           nhf.temp = 70;
           forecast.forecast.hourly = new System.Collections.Generic.List<NestHourlyForecast>();
           forecast.forecast.hourly.Add(nhf);
            
           //Setup Now Attribute
           forecast.now = new NestNowForecast();
           forecast.now.current_temperature = "50";

           return forecast;

        }

        [TestMethod]
        public void HumidityEngineConservativeMode()
        {
            NestAPIForecastResponse forecast = buildForecast();
            int targetHumidity;

            forecast.now.current_temperature = "50";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(30, targetHumidity);

            forecast.now.current_temperature = "40";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(30, targetHumidity);

            forecast.now.current_temperature = "39";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(25, targetHumidity);

            forecast.now.current_temperature = "30";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(25, targetHumidity);

            forecast.now.current_temperature = "29";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(20, targetHumidity);

            forecast.now.current_temperature = "20";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(20, targetHumidity);

            forecast.now.current_temperature = "19";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(15, targetHumidity);

            forecast.now.current_temperature = "10";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(15, targetHumidity);

            forecast.now.current_temperature = "9";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            forecast.now.current_temperature = "0";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            forecast.now.current_temperature = "-1";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            forecast.now.current_temperature = "-10";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            forecast.now.current_temperature = "-50";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);
        }

        [TestMethod]
        public void HumidityEngineNormalMode()
        {
            NestAPIForecastResponse forecast = buildForecast();
            int targetHumidity;

            forecast.now.current_temperature = "50";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(45, targetHumidity);

            forecast.now.current_temperature = "40";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(45, targetHumidity);

            forecast.now.current_temperature = "39";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(40, targetHumidity);

            forecast.now.current_temperature = "30";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(40, targetHumidity);

            forecast.now.current_temperature = "29";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(35, targetHumidity);

            forecast.now.current_temperature = "20";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(35, targetHumidity);

            forecast.now.current_temperature = "19";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(30, targetHumidity);

            forecast.now.current_temperature = "10";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(30, targetHumidity);

            forecast.now.current_temperature = "9";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(25, targetHumidity);

            forecast.now.current_temperature = "0";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(25, targetHumidity);

            forecast.now.current_temperature = "-1";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(20, targetHumidity);

            forecast.now.current_temperature = "-10";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(20, targetHumidity);

            forecast.now.current_temperature = "-50";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(15, targetHumidity);
        }

        [TestMethod]
        public void HumidityEngineAggressiveMode()
        {
            NestAPIForecastResponse forecast = buildForecast();
            int targetHumidity;

            forecast.now.current_temperature = "50";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.now.current_temperature = "40";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.now.current_temperature = "39";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.now.current_temperature = "30";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.now.current_temperature = "29";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.now.current_temperature = "20";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.now.current_temperature = "19";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(40, targetHumidity);

            forecast.now.current_temperature = "10";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(40, targetHumidity);

            forecast.now.current_temperature = "9";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(35, targetHumidity);

            forecast.now.current_temperature = "0";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(35, targetHumidity);

            forecast.now.current_temperature = "-1";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(30, targetHumidity);

            forecast.now.current_temperature = "-10";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(30, targetHumidity);

            forecast.now.current_temperature = "-50";
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(25, targetHumidity);
        }

    }
}
