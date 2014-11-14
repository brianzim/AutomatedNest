using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;

namespace AutomatedNest.UnofficialNestAPI
{
    public interface IUnofficialNestAPI
    {
        NestAPICredentialsResponse postLoginRequest(string username, string password);

        NestAPIForecastResponse getForecast(NestAPICredentialsResponse credentials, string zip);

        NestAPIStatusResponse getNestStatus(NestAPICredentialsResponse credentials);

        NestAPISetTargetHumidityResponse setTargetHumidity(NestAPICredentialsResponse credentials, NestAPIStatusResponse status, int newTargetHumidity);
    }
}
