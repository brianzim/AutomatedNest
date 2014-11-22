using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.UnofficialNestAPI;

namespace AutomatedNest.ThermostatManager
{
    public class AccessorFactory
    {
        public virtual T Create<T>()
            where T : class
        {
            if (typeof(T).Name == "IThermostatAccessor")
                return new AutomatedNest.UnofficialNestAPI.ThermostatAccessor() as T;
            if (typeof(T).Name == "IForecastAccessor")
                return new AutomatedNest.UnofficialNestAPI.ForecastAccessor() as T;

            return null;
        }
    }
}
