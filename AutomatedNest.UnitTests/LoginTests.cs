using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedNest.ThermostatManager;
using AutomatedNest.UnofficialNestAPI;

namespace ConnectivityUnitTests
{
    [TestClass]
    public class LoginTests
    {
        string correctUserName = "abc123";
        string correctPassword = "xyz987";
        private ThermostatManager SetupThermostatManager()
        {
            var factory = new MockAccessorFactory();
            factory.AddOverride<IUnofficialNestAPI>(new MockUnofficialNestAPI());

            var thermostatManager = new ThermostatManager();
            thermostatManager.AccessorFactory = factory;

            return thermostatManager;
        }

        [TestMethod]
        public void SuccessfulLogin()
        {
            var thermostatManager = SetupThermostatManager();

            var mockUnofficialNestAPI = new MockUnofficialNestAPI();

            AutomatedNest.NestDataObjects.NestAPICredentialsResponse response = thermostatManager.performLogin(correctUserName, correctPassword);

            Assert.AreEqual(true, response.success);
        }

        [TestMethod]
        public void BadUserNameLogin()
        {
            var thermostatManager = SetupThermostatManager();

            var mockUnofficialNestAPI = new MockUnofficialNestAPI();

            AutomatedNest.NestDataObjects.NestAPICredentialsResponse response = thermostatManager.performLogin("a", correctPassword);

            Assert.AreEqual(false, response.success);
        }

        [TestMethod]
        public void BadPasswordLogin()
        {
            var thermostatManager = SetupThermostatManager();

            var mockUnofficialNestAPI = new MockUnofficialNestAPI();

            AutomatedNest.NestDataObjects.NestAPICredentialsResponse response = thermostatManager.performLogin(correctUserName, "a");

            Assert.AreEqual(false, response.success);
        }




    }
}
