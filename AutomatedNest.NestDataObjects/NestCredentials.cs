using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomatedNest.NestDataObjects
{
    public class NestCredentials
    {
        JObject jsonLoginResponse;

        public NestCredentials(string jsonLoginResponse)
        {
            this.jsonLoginResponse = JObject.Parse(jsonLoginResponse);      
        }


        public string TransportURL
        {
            get { return jsonLoginResponse["urls"]["transport_url"].ToString(); }
        }

        public string AccessToken
        {
            get { return jsonLoginResponse["access_token"].ToString(); }
        }

        public string User
        {
            get { return jsonLoginResponse["user"].ToString(); }
        }

        public string UserID
        {
            get { return jsonLoginResponse["userid"].ToString(); }
        }

        public string CacheExpiration
        {
            get { return jsonLoginResponse["expires_in"].ToString(); }
        }
    }
}
