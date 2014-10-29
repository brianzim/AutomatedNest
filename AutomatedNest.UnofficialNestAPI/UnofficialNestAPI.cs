using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace AutomatedNest.UnofficialNestAPI
{
    public static class UnofficialNestAPI
    {
        private static string loginURL = "https://home.nest.com/user/login";
        private static string forecastURL = "https://home.nest.com/api/0.1/weather/forecast/";
        private static string userAgent = "'Nest/2.1.3 CFNetwork/548.0.4'";
        private static string protocol_version = "1";

        public static NestCredentials postLoginRequest(string username, string password)
        {

            HttpWebRequest request = WebRequest.Create(loginURL) as HttpWebRequest;
            request.Method = "POST";
            request.UserAgent = userAgent;
            request.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(WriteEncodedFormParameter("username", username));
                writer.Write("&");
                writer.Write(WriteEncodedFormParameter("password", password));
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseBody;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseBody = reader.ReadToEnd();
                }
            }

            NestCredentials nc = JsonConvert.DeserializeObject<NestCredentials>(responseBody);

            return nc;

        }

        public static NestForecastBase getForecast(NestCredentials credentials, string zip)
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

            NestForecastBase nfb = JsonConvert.DeserializeObject<NestForecastBase>(responseBody);

            return nfb;
        }

        public static NestStatus getNestStatus(NestCredentials credentials)
        {
            string url = credentials.urls.transport_url + "/v2/mobile/" + credentials.user;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = userAgent;
            request.Headers.Add("X-nl-protocol-version", protocol_version);
            request.Headers.Add("X-nl-user-d", credentials.userid);
            string auth = "Basic " + credentials.access_token;
            request.Headers.Set("Authorization", auth);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseBody;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseBody = reader.ReadToEnd();
                }
            }

            return new NestStatus(responseBody);
        }

        public static string getAPI(string url) { return null;  }

        private static string WriteEncodedFormParameter(string key, string value)
        {
            return WriteEncodedFormParameter(key, value, false);
        }

        private static string WriteEncodedFormParameter(string key, string value, bool isUrl)
        {
            var encoded = string.Format("{0}={1}", Uri.EscapeUriString(key), Uri.EscapeUriString(value));
            return (isUrl ? encoded.Replace("%20", "+") : encoded);
        }
    }
}
