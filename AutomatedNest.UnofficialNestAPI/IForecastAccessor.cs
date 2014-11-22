using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;

namespace AutomatedNest.UnofficialNestAPI
{
    public interface IForecastAccessor
    {
        NestAPIForecastResponse getForecast(NestAPICredentialsResponse credentials, string zip);
    }
}
