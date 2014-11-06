using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomatedNest.NestDataObjects
{
    public class NestAPIStatusResponse
    {
        JObject jsonStatusResponse;

        public NestAPIStatusResponse(string jsonStatusResponse)
        {
            this.jsonStatusResponse = JObject.Parse(jsonStatusResponse);

        }

        public int TargetHumidity
        {
            get
            {
                int result;
                int.TryParse(this.jsonStatusResponse["device"][this.SerialNumber]["target_humidity"].ToString(), out result);
                return result;
            }
        }

        public bool HasHumidifier
        {
            get
            {
                //if (this.jsonStatusResponse["device"][this.SerialNumber]["has_humidifier"].ToString() == "False")
                //    return false;
                return true;
            }
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
