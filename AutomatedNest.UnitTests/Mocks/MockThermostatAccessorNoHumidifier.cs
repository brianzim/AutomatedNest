using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using Newtonsoft.Json;

namespace AutomatedNest.UnofficialNestAPI
{
    public class MockThermostatAccessorNoHumidifier : IThermostatAccessor
    {
        public NestAPICredentialsResponse postLoginRequest(string username, string password)
        {
            NestAPICredentialsResponse response = new NestAPICredentialsResponse();
            
            if (username == "abc123" && password == "xyz987")
            {
                response.access_token = "abcdefghijklmnopqrstuvwxyz1234567890";
                response.email = "test@email.com";
                response.expires_in = DateTime.Now;
                response.user = "test.0000";
                response.userid = "test";
            }
            else
            {
                response.error = "Username or Password was not recognized.  Please try again.";
            }

            return response;
        }

        public NestAPIStatusResponse getNestStatus(NestAPICredentialsResponse credentials)
        {
            NestAPIStatusResponse response = new NestAPIStatusResponse();
            response.CurrentHumidity = "40";
            response.HasHumidifier = false;
            response.PostalCode = "XXXXX";
            response.SerialNumber = "XXXXXXXXX";
            response.StructureGUID = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            response.TargetHumidity = 25;
            return response;
        }

        public NestAPISetTargetHumidityResponse setTargetHumidity(NestAPICredentialsResponse credentials, NestAPIStatusResponse status, int newTargetHumidity)
        {
            NestAPISetTargetHumidityResponse response = new NestAPISetTargetHumidityResponse();
            response.ResponseResult = NestAPISetTargetHumidityResponse.ResponseResultOptions.SUCCESS;
            return response;
        }
    }
}
