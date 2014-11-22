using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using AutomatedNest.UnofficialNestAPI;
using AutomatedNest.ThermostatEngines;

namespace AutomatedNest.ThermostatManager
{
    public class HumidityManager : ManagerBase
    {
        public NestAPICredentialsResponse performLogin(string username, string password) 
        {
            IThermostatAccessor nestapi = AccessorFactory.Create<IThermostatAccessor>();
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
                    NestAPIForecastResponse forecast = getForecast(credentials, status.PostalCode);
                    optimizeHumidityResult.LowForecastTemperature = HumidityEngines.findLowestTemperature(forecast);

                    // Calculate desired humidity based on forecast an mode of calculation
                    optimizeHumidityResult.NewTargetHumidity = HumidityEngines.calculateOptimalHumidity(optimizeHumidityResult.LowForecastTemperature, mode);

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
            var nestapi = AccessorFactory.Create<IThermostatAccessor>();
            return nestapi.setTargetHumidity(credentials, status, newTargetHumidity);
        }

        public NestAPIStatusResponse getStatus(NestAPICredentialsResponse credentials)
        {
            var nestapi = AccessorFactory.Create<IThermostatAccessor>();
            return nestapi.getNestStatus(credentials);
        }

        public NestAPIForecastResponse getForecast(NestAPICredentialsResponse credentials, string zip)
        {
            var nestapi = AccessorFactory.Create<IForecastAccessor>();
            return nestapi.getForecast(credentials, zip);
        }
    }
}
