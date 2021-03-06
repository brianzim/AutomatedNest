﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedNest.ThermostatManager;
using AutomatedNest.UnofficialNestAPI;

namespace AutomatedNest.UnitTests
{
    [TestClass]
    public class IntegrationTests
    {
        string correctUserName = "abc123";
        string correctPassword = "xyz987";
        private AutomatedNest.ThermostatManager.HumidityManager SetupThermostatManager()
        {
            var factory = new MockAccessorFactory();
            factory.AddOverride<IThermostatAccessor>(new MockThermostatAccessor());
            factory.AddOverride<IForecastAccessor>(new MockForecastAccessor());

            var thermostatManager = new AutomatedNest.ThermostatManager.HumidityManager();
            thermostatManager.AccessorFactory = factory;

            return thermostatManager;
        }

        private AutomatedNest.ThermostatManager.HumidityManager SetupThermostatManagerNoHumidifier()
        {
            var factory = new MockAccessorFactory();
            factory.AddOverride<IThermostatAccessor>(new MockThermostatAccessorNoHumidifier());
            factory.AddOverride<IForecastAccessor>(new MockForecastAccessor());

            var thermostatManager = new AutomatedNest.ThermostatManager.HumidityManager();
            thermostatManager.AccessorFactory = factory;

            return thermostatManager;
        }

        [TestMethod]
        public void SuccessfulLogin()
        {
            var thermostatManager = SetupThermostatManager();

            AutomatedNest.NestDataObjects.NestAPICredentialsResponse response = thermostatManager.performLogin(correctUserName, correctPassword);

            Assert.AreEqual(true, response.success);
        }

        [TestMethod]
        public void BadUserNameLogin()
        {
            var thermostatManager = SetupThermostatManager();

            AutomatedNest.NestDataObjects.NestAPICredentialsResponse response = thermostatManager.performLogin("a", correctPassword);

            Assert.AreEqual(false, response.success);
        }

        [TestMethod]
        public void BadPasswordLogin()
        {
            var thermostatManager = SetupThermostatManager();

            AutomatedNest.NestDataObjects.NestAPICredentialsResponse response = thermostatManager.performLogin(correctUserName, "a");

            Assert.AreEqual(false, response.success);
        }

        [TestMethod]
        public void OptimizeHumidityChangeSuccessful()
        {
            var thermostatManager = SetupThermostatManager();

            NestDataObjects.OptimizeHumidityResult result = thermostatManager.optimizeHumidity(new NestDataObjects.NestAPICredentialsResponse(), NestDataObjects.HumidityMode.Conservative);

            Assert.AreEqual(NestDataObjects.OptimizeHumidityResult.OperationResultOptions.CHANGE_SUCCEEDED, result.OperationResult);
            Assert.AreEqual(10, result.NewTargetHumidity);
            Assert.AreEqual(40, result.OldTargetHumidity);
            Assert.AreEqual(8, result.LowForecastTemperature); 
        }

        [TestMethod]
        public void OptimizeHumidityNoHumidifier()
        {
            var thermostatManager = SetupThermostatManagerNoHumidifier();

            NestDataObjects.OptimizeHumidityResult result = thermostatManager.optimizeHumidity(new NestDataObjects.NestAPICredentialsResponse(), NestDataObjects.HumidityMode.Conservative);

            Assert.AreEqual(NestDataObjects.OptimizeHumidityResult.OperationResultOptions.ERROR, result.OperationResult);

        }
    }
}
