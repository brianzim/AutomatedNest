using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomatedNest.NestDataObjects
{
    public class NestCredentialsURLS
    {
        public string transport_url { get; set; }
        public string direct_transport_url { get; set; }
        public string rubyapi_url { get; set; }
        public string weather_url { get; set; }
        public string log_upload_url { get; set; }
        public string support_url { get; set; }

    }
    public class NestAPICredentialsResponse
    {
        public bool success { 
            get
            {
                if (error == null && access_token != null)
                {
                    return true;
                }

                return false;
            }
        
        }
        public string error { get; set; }
        public string access_token { get; set; }
        public string user { get; set; }
        public NestCredentialsURLS urls { get; set; }
        public DateTime expires_in { get; set; }
        public string email { get; set; }
        public string userid { get; set; }

        public NestAPICredentialsResponse()
        {  
        }
    }
}
