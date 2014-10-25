using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedNest.NestDataObjects
{
    public class NestCredentials
    {
        public NestCredentials(string transportURL, string accessToken, string user, string userID, string cacheExpiration)
        {
            this.transportURL = transportURL;
            this.accessToken = accessToken;
            this.user = user;
            this.userID = userID;
            this.cacheExpiration = cacheExpiration;
        }

        private string transportURL;
        private string accessToken;
        private string user;
        private string userID;
        private string cacheExpiration;

        public string TransportURL
        {
            get { return transportURL; }
        }

        public string AccessToken
        {
            get { return accessToken; }
        }

        public string User
        {
            get { return user; }
        }

        public string UserID
        {
            get { return userID; }
        }

        public string CacheExpiration
        {
            get { return cacheExpiration; }
        }
    }
}
