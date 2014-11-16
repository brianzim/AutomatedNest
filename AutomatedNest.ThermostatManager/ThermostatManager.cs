using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using AutomatedNest.UnofficialNestAPI;

namespace AutomatedNest.ThermostatManager
{
    public class ThermostatManager : ManagerBase
    {
        public NestAPICredentialsResponse performLogin(string username, string password) 
        {
            var nestapi = AccessorFactory.Create<IUnofficialNestAPI>();
            return nestapi.postLoginRequest(username, password); 
        }

        public OptimizeHumidityResult optimizeHumidity(NestAPICredentialsResponse credentials, HumidityMode mode)
        {
            OptimizeHumidityResult optimizeHumidityResult = new OptimizeHumidityResult();

            try
            {
                NestAPIStatusResponse status = getStatus(credentials);
                optimizeHumidityResult.OldTargetHumidity = status.TargetHumidity;

                // If no humidifier installed, fail as there's no point to doing anything more
                if (status.HasHumidifier)
                {
                    // Get forecast for location registered to Nest
                    ForecastManager forecastManager = new ForecastManager();
                    forecastManager.AccessorFactory = this.AccessorFactory;
                    NestAPIForecastResponse forecast = forecastManager.getForecast(credentials, status.PostalCode);
                    optimizeHumidityResult.LowForecastTemperature = forecast.LowestForecastTemp;

                    // Calculate desired humidity based on forecast an mode of calculation
                    optimizeHumidityResult.NewTargetHumidity = forecastManager.calculateTargetHumidity(forecast, mode);


                    // Compre new target to current target.  Make change if needed.
                    if (status.TargetHumidity != optimizeHumidityResult.NewTargetHumidity)
                    {
                        NestAPISetTargetHumidityResponse response = setHumidity(credentials, status, optimizeHumidityResult.NewTargetHumidity);
                        if (response.ResponseResult == NestAPISetTargetHumidityResponse.ResponseResultOptions.SUCCESS)
                        {
                            optimizeHumidityResult.OperationResult = OptimizeHumidityResult.OperationResultOptions.CHANGE_SUCCEEDED;
                            optimizeHumidityResult.OldTargetHumidity = status.TargetHumidity;
                        }
                        else
                        {
                            optimizeHumidityResult.OperationResult = OptimizeHumidityResult.OperationResultOptions.ERROR;
                            optimizeHumidityResult.ErrorMessage = response.ErrorMessage;
                        }
                    }
                    else
                    { 
                        optimizeHumidityResult.OperationResult = OptimizeHumidityResult.OperationResultOptions.NO_CHANGE_NEEDED;                  
                    }
                }
                else
                {
                    optimizeHumidityResult.OperationResult = OptimizeHumidityResult.OperationResultOptions.ERROR;
                    optimizeHumidityResult.ErrorMessage = "Your nest is not configuered to work with a humidifier.";
                }
            }
            catch (Exception e)
            {
                optimizeHumidityResult.OperationResult = OptimizeHumidityResult.OperationResultOptions.ERROR;
                optimizeHumidityResult.ErrorMessage = e.Message;
            }

            return optimizeHumidityResult;
        }

        private NestAPISetTargetHumidityResponse setHumidity(NestAPICredentialsResponse credentials, NestAPIStatusResponse status, int newTargetHumidity)
        {
            var nestapi = AccessorFactory.Create<IUnofficialNestAPI>();
            return nestapi.setTargetHumidity(credentials, status, newTargetHumidity);
        }

        public NestAPIStatusResponse getStatus(NestAPICredentialsResponse credentials)
        {
            var nestapi = AccessorFactory.Create<IUnofficialNestAPI>();
            return nestapi.getNestStatus(credentials);
        }
    }
}
