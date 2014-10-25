using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomatedNest.NestDataObjects
{
    public class NestStatus
    {
        dynamic jsonStatusResponse;

        public NestStatus(string jsonStatusResponse)
        {
            this.jsonStatusResponse = JObject.Parse(jsonStatusResponse);

         //   JObject jo = JObject.Parse(jsonStatusResponse);
          //  string result = (string)jo["device"][0];

        }
    }
}
