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
            
           //Setup Now Attribute (in deg C, all other values are in deg F.  21C = 70F.
           forecast.now = new NestNowForecast();
           forecast.now.current_temperature = "21";

           return forecast;

        }

        [TestMethod]
        public void HumidityEngineConservativeMode()
        {
            NestAPIForecastResponse forecast = buildForecast();
            int targetHumidity;

            NestHourlyForecast nhftest = new NestHourlyForecast();
            nhftest.temp = 50;
            forecast.forecast.hourly.Add(nhftest);

            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(30, targetHumidity);

            forecast.forecast.hourly[1].temp = 40;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(30, targetHumidity);

            forecast.forecast.hourly[1].temp = 39;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(25, targetHumidity);

            forecast.forecast.hourly[1].temp = 30;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(25, targetHumidity);

            forecast.forecast.hourly[1].temp = 29;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(20, targetHumidity);

            forecast.forecast.hourly[1].temp = 20;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(20, targetHumidity);

            forecast.forecast.hourly[1].temp = 19;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(15, targetHumidity);

            forecast.forecast.hourly[1].temp = 10;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(15, targetHumidity);

            forecast.forecast.hourly[1].temp = 9;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            forecast.forecast.hourly[1].temp = 0;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            forecast.forecast.hourly[1].temp = -1;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            forecast.forecast.hourly[1].temp = -10;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);

            forecast.forecast.hourly[1].temp = -50;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Conservative);
            Assert.AreEqual(10, targetHumidity);
        }

        [TestMethod]
        public void HumidityEngineNormalMode()
        {
            NestAPIForecastResponse forecast = buildForecast();
            int targetHumidity;

            NestHourlyForecast nhftest = new NestHourlyForecast();
            nhftest.temp = 50;
            forecast.forecast.hourly.Add(nhftest);

            forecast.forecast.hourly[1].temp = 50;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(45, targetHumidity);

            forecast.forecast.hourly[1].temp = 40;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(45, targetHumidity);

            forecast.forecast.hourly[1].temp = 39;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(40, targetHumidity);

            forecast.forecast.hourly[1].temp = 30;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(40, targetHumidity);

            forecast.forecast.hourly[1].temp = 29;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(35, targetHumidity);

            forecast.forecast.hourly[1].temp = 20;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(35, targetHumidity);

            forecast.forecast.hourly[1].temp = 19;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(30, targetHumidity);

            forecast.forecast.hourly[1].temp = 10;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(30, targetHumidity);

            forecast.forecast.hourly[1].temp = 9;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(25, targetHumidity);

            forecast.forecast.hourly[1].temp = 0;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(25, targetHumidity);

            forecast.forecast.hourly[1].temp = -1;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(20, targetHumidity);

            forecast.forecast.hourly[1].temp = -10;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(20, targetHumidity);

            forecast.forecast.hourly[1].temp = -50;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Normal);
            Assert.AreEqual(15, targetHumidity);
        }

        [TestMethod]
        public void HumidityEngineAggressiveMode()
        {
            NestAPIForecastResponse forecast = buildForecast();
            int targetHumidity;

            NestHourlyForecast nhftest = new NestHourlyForecast();
            nhftest.temp = 50;
            forecast.forecast.hourly.Add(nhftest);

            forecast.forecast.hourly[1].temp = 50;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.forecast.hourly[1].temp = 40;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.forecast.hourly[1].temp = 39;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.forecast.hourly[1].temp = 30;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.forecast.hourly[1].temp = 29;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.forecast.hourly[1].temp = 20;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(45, targetHumidity);

            forecast.forecast.hourly[1].temp = 19;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(40, targetHumidity);

            forecast.forecast.hourly[1].temp = 10;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(40, targetHumidity);

            forecast.forecast.hourly[1].temp = 9;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(35, targetHumidity);

            forecast.forecast.hourly[1].temp = 0;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(35, targetHumidity);

            forecast.forecast.hourly[1].temp = -1;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(30, targetHumidity);

            forecast.forecast.hourly[1].temp = -10;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(30, targetHumidity);

            forecast.forecast.hourly[1].temp = -50;
            targetHumidity = ThermostatEngines.HumidityEngines.calculateOptimalHumidity(forecast, HumidityMode.Aggressive);
            Assert.AreEqual(25, targetHumidity);
        }

    }
}
