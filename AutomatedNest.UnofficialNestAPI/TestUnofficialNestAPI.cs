using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;

namespace AutomatedNest.UnofficialNestAPI
{
    public class TestUnofficialNestAPI : IUnofficialNestAPI
    {
        public NestAPICredentialsResponse postLoginRequest(string username, string password)
        {
            NestAPICredentialsResponse response = new NestAPICredentialsResponse();
            
            if (username == "abc123" && password == "xyz987")
            {
                response.access_token = "abcdefghijklmnopqrstuvwxyz1234567890";
                response.email = "test@email.com";
                response.expires_in = DateTime.Now;
                response.urls.transport_url = "";
                response.user = "test.0000";
                response.userid = "test";
            }
            else
            {
                response.error = "Username or Password was not recognized.  Please try again.";
            }

            return response;
        }

        public NestAPIForecastResponse getForecast(NestAPICredentialsResponse credentials, string zip)
        {
            NestAPIForecastResponse response = new NestAPIForecastResponse();
            NestDailyForecast ndf = new NestDailyForecast();
            ndf.low_temperature = 20;
            NestHourlyForecast nhf = new NestHourlyForecast();
            nhf.temp = 19;

            response.forecast.daily.Add(ndf);
            response.forecast.hourly.Add(nhf);

            return response;
        }

        public NestAPIStatusResponse getNestStatus(NestAPICredentialsResponse credentials)
        {
            NestAPIStatusResponse response = new NestAPIStatusResponse("");
            return response;
        }

        public NestAPISetTargetHumidityResponse setTargetHumidity(NestAPICredentialsResponse credentials, NestAPIStatusResponse status, int newTargetHumidity)
        {
            NestAPISetTargetHumidityResponse response = new NestAPISetTargetHumidityResponse();
            return response;
        }
    }
}
