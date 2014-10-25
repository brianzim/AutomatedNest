using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using AutomatedNest.UnofficialNestAPI;

namespace AutomatedNest.ForecastManager
{
    public static class ForecastManager
    {

        public static NestForecast getForecast(NestCredentials credentials, string zip)
        {
            return UnofficialNestAPI.UnofficialNestAPI.getForecast(credentials, zip);
        }
        
    }
}
