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
    public class ThermostatAccessor : IThermostatAccessor
    {
        private static string loginURL = "https://home.nest.com/user/login";
        private static string deviceURL = "/v2/put/device";
        private static string userAgent = "'Nest/2.1.3 CFNetwork/548.0.4'";
        private static string protocol_version = "1";

        public NestAPICredentialsResponse postLoginRequest(string username, string password)
        {
            NestAPICredentialsResponse returnNestCredentials;

            HttpWebRequest request = WebRequest.Create(loginURL) as HttpWebRequest;
            request.Method = "POST";
            request.UserAgent = userAgent;
            request.ContentType = "application/x-www-form-urlencoded";

            try
            {

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

                returnNestCredentials = JsonConvert.DeserializeObject<NestAPICredentialsResponse>(responseBody);
            }
            catch (Exception e)
            {
                returnNestCredentials = new NestAPICredentialsResponse();

                if (e.Message == "The remote server returned an error: (400) Bad Request.")
                {
                    returnNestCredentials.error = "Username or Password was not recognized.  Please try again.";
                }
                else
                { 
                    returnNestCredentials.error = e.Message; 
                }
                

            }

            return returnNestCredentials;

        }

        public NestAPIStatusResponse getNestStatus(NestAPICredentialsResponse credentials)
        {
            string url = credentials.urls.transport_url + "/v2/mobile/" + credentials.user;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = userAgent;
            request.ContentType = "application/x-www-form-urlencoded";

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

            NestAPIStatusResponse statusResponse = new NestAPIStatusResponse();

            try
            {
                JObject jsonResponse = JObject.Parse(responseBody);

                JObject deviceobj = (JObject)jsonResponse["device"];
                IList<string> propertyNames = deviceobj.Properties().Select(p => p.Name).ToList();
                statusResponse.SerialNumber = propertyNames[0].ToString();

                JObject structureobj = (JObject)jsonResponse["structure"];
                IList<string> structpropertyNames = structureobj.Properties().Select(p => p.Name).ToList();
                statusResponse.StructureGUID = structpropertyNames[0].ToString();

                statusResponse.HasHumidifier = (bool)jsonResponse["device"][statusResponse.SerialNumber]["has_humidifier"];
                statusResponse.TargetHumidity = (int)jsonResponse["device"][statusResponse.SerialNumber]["target_humidity"];
                statusResponse.PostalCode = jsonResponse["structure"][statusResponse.StructureGUID]["postal_code"].ToString();
                statusResponse.CurrentHumidity = jsonResponse["device"][statusResponse.SerialNumber]["current_humidity"].ToString();
            }
            catch (Exception e)
            {

            }


            return statusResponse;
        }

        public NestAPISetTargetHumidityResponse setTargetHumidity(NestAPICredentialsResponse credentials, NestAPIStatusResponse status, int newTargetHumidity)
        {
            NestAPISetTargetHumidityResponse returnResponse = new NestAPISetTargetHumidityResponse();

            HttpWebRequest request = WebRequest.Create(credentials.urls.transport_url + deviceURL + "." + status.SerialNumber.ToString()) as HttpWebRequest;
            request.Method = "POST";
            request.UserAgent = userAgent;
            request.ContentType = "text/json";

            request.Headers.Add("X-nl-protocol-version", protocol_version);
            request.Headers.Add("X-nl-user-d", credentials.userid);
            string auth = "Basic " + credentials.access_token;
            request.Headers.Add("Authorization", auth);

            string json = "{\"target_humidity\" : " + newTargetHumidity.ToString() + "}";

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(json);
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusDescription.Equals("OK"))
                {
                    returnResponse.ResponseResult = NestAPISetTargetHumidityResponse.ResponseResultOptions.SUCCESS;
                }
                else
                {
                    returnResponse.ResponseResult = NestAPISetTargetHumidityResponse.ResponseResultOptions.ERROR;
                    returnResponse.ErrorMessage = response.StatusDescription;
                }
            }
            catch (Exception e)
            {
                returnResponse.ResponseResult = NestAPISetTargetHumidityResponse.ResponseResultOptions.ERROR;
                returnResponse.ErrorMessage = e.Message;
            }

            return returnResponse;
        }

        public string getAPI(string url) { return null;  }

        private string WriteEncodedFormParameter(string key, string value)
        {
            return WriteEncodedFormParameter(key, value, false);
        }

        private string WriteEncodedFormParameter(string key, string value, bool isUrl)
        {
            var encoded = string.Format("{0}={1}", Uri.EscapeUriString(key), Uri.EscapeUriString(value));
            return (isUrl ? encoded.Replace("%20", "+") : encoded);
        }
    }
}
