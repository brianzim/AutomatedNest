using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomatedNest.NestDataObjects
{
    public class NestNowForecast
    {
        public string station_id { get; set; }
        public string conditions { get; set; }
        public string current_humidity { get; set; }
        public string current_temperature { get; set; }
        public string current_wind { get; set; }
        public string gmt_offset { get; set; }
        public string icon { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string wind_direction { get; set; }
    }

    public class NestHourlyForecast
    {
        public string time { get; set; }
        public int temp { get; set; }
        public string humidity { get; set; }
    }

    public class NestDailyForecast
    {
        public string conditions { get; set; }
        public string date { get; set; }
        public int high_temperature { get; set; }
        public string icon { get; set; }
        public int low_temperature { get; set; }
    }

    public class NestFutureForecast
    {
        public List<NestHourlyForecast> hourly;
        public List<NestDailyForecast> daily;

    }
    
    public class NestAPIForecastResponse
    {
        public string display_city { get; set; }
        public string city { get; set; }
        public NestNowForecast now { get; set; }
        public NestFutureForecast forecast { get; set; }

        public NestAPIForecastResponse()
        {

        }
    }
}
