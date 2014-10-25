using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using AutomatedNest.UnofficialNestAPI;

namespace AutomatedNest.ThermostatManager
{
    public static class ThermostatManager
    {
        public static NestCredentials performLogin(string username, string password) 
        {
            return UnofficialNestAPI.UnofficialNestAPI.postLoginRequest(username, password);
  
        }

        public static void getStatus(NestCredentials credentials)
        {

        }

    }
}
