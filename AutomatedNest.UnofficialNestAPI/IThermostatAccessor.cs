using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;

namespace AutomatedNest.UnofficialNestAPI
{
    public interface IThermostatAccessor
    {
        NestAPICredentialsResponse postLoginRequest(string username, string password);

        NestAPIStatusResponse getNestStatus(NestAPICredentialsResponse credentials);

        NestAPISetTargetHumidityResponse setTargetHumidity(NestAPICredentialsResponse credentials, NestAPIStatusResponse status, int newTargetHumidity);
    }
}
