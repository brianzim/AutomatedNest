using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using AutomatedNest.UnofficialNestAPI;

namespace AutomatedNest.ThermostatManager
{
    public static class ThermostatManager
    {
        public static NestCredentials performLogin(string username, string password) 
        {
            return UnofficialNestAPI.UnofficialNestAPI.postLoginRequest(username, password);
  
        }

        public static OptimizeHumidityResult optimizeHumidity(NestCredentials credentials, HumidityMode mode)
        {
            OptimizeHumidityResult optimizeHumidityResult = new OptimizeHumidityResult();

            try
            {
                NestStatus status = getStatus(credentials);
                optimizeHumidityResult.OldTargetHumidity = status.TargetHumidity;

                // If no humidifier installed, fail as there's no point to doing anything more
                if (status.HasHumidifier)
                {
                    // Get forecast for location registered to Nest
                    NestForecastBase forecast = ForecastManager.getForecast(credentials, status.PostalCode);
                    optimizeHumidityResult.LowForecastTemperature = forecast.LowestForecastTemp;

                    // Calculate desired humidity based on forecast an mode of calculation
                    optimizeHumidityResult.NewTargetHumidity = ForecastManager.calculateTargetHumidity(forecast, mode);


                    // Compre new target to current target.  Make change if needed.
                    if (status.TargetHumidity != optimizeHumidityResult.NewTargetHumidity)
                    {
                        NestAPISetTargetHumidityResponse response = ThermostatManager.setHumidity(credentials, optimizeHumidityResult.NewTargetHumidity);
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

        private static NestAPISetTargetHumidityResponse setHumidity(NestCredentials credentials, int newTargetHumidity)
        {
            return UnofficialNestAPI.UnofficialNestAPI.setTargetHumidity(credentials, newTargetHumidity);
        }

        public static NestStatus getStatus(NestCredentials credentials)
        {
            return UnofficialNestAPI.UnofficialNestAPI.getNestStatus(credentials);
        }



    }
}
