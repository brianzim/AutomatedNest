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
        JObject jsonStatusResponse;

        public NestStatus(string jsonStatusResponse)
        {
            this.jsonStatusResponse = JObject.Parse(jsonStatusResponse);

        }

        public string StructureGUID { 
            get 
            {
                JObject structureobj = (JObject)this.jsonStatusResponse["structure"];
                IList<string> structpropertyNames = structureobj.Properties().Select(p => p.Name).ToList();
                return structpropertyNames[0];
            }
        }
        public string SerialNumber
        {
            get
            {
                JObject deviceobj = (JObject)this.jsonStatusResponse["device"];
                IList<string> propertyNames = deviceobj.Properties().Select(p => p.Name).ToList();
                return propertyNames[0];
            }
        }
        public string PostalCode
        {
            get
            {
                return this.jsonStatusResponse["structure"][this.StructureGUID]["postal_code"].ToString();
            }
        }
        public string CurrentHumidity
        {
            get
            {
                return this.jsonStatusResponse["device"][this.SerialNumber]["current_humidity"].ToString();
            }
        }
    }
}
