using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedNest.NestDataObjects
{
    public class NestAPISetTargetHumidityResponse
    {
        public enum ResponseResultOptions
        {
            SUCCESS = 1,
            ERROR = -1,
        }

        public ResponseResultOptions ResponseResult
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get;
            set;
        }
    }
}
