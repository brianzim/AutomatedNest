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

        public NestAPIStatusResponse()
        {

        }

        public int TargetHumidity { get; set; }
        public bool HasHumidifier { get; set; }
        public string StructureGUID { get; set; }
        public string SerialNumber { get; set; }
        public string PostalCode { get; set; }
        public string CurrentHumidity { get; set; }
    }
}
