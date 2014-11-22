using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomatedNest.UnofficialNestAPI
{
    public class ForecastAccessor : IForecastAccessor
    {
        private static string forecastURL = "https://home.nest.com/api/0.1/weather/forecast/";
        private static string deviceURL = "/v2/put/device";
        private static string userAgent = "'Nest/2.1.3 CFNetwork/548.0.4'";
        private static string protocol_version = "1";

        public NestAPIForecastResponse getForecast(NestAPICredentialsResponse credentials, string zip)
        {
            string url = forecastURL + zip;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = userAgent;
            request.Headers.Add("X-nl-protocol-version", protocol_version);
            request.Headers.Add("X-nl-user-d", credentials.userid);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Set("Authorization", string.Format("Basic ", credentials.access_token));

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseBody;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseBody = reader.ReadToEnd();
                }

            }

            return JsonConvert.DeserializeObject<NestAPIForecastResponse>(responseBody);
        }
    }
}
