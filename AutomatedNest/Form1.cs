using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using AutomatedNest.ThermostatManager;
using AutomatedNest.ForecastManager;
using AutomatedNest.NestDataObjects;

namespace AutomatedNest
{
    public partial class Form1 : Form
    {

        const string user_agent = "Nest/2.1.3 CFNetwork/548.0.4"; 
        const string protocol_version = "1"; 
        const string login_url = "https://home.nest.com/user/login";

        NestCredentials credentials;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            credentials = ThermostatManager.ThermostatManager.performLogin(txtUserName.Text.ToString(), txtPassword.Text.ToString());   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NestForecast forecast = ForecastManager.ForecastManager.getForecast(credentials, txtZip.Text.ToString());
            
        }

        private void button3_Click(object sender, EventArgs e)
        {/*
            string url = nc.TransportURL + "/v2/mobile/" + nc.User;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = "'Nest/2.1.3 CFNetwork/548.0.4'";
            request.Headers.Add("X-nl-protocol-version", protocol_version);
            request.Headers.Add("X-nl-user-d", nc.UserID);
            string auth = "Basic " + nc.AccessToken;
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
            dynamic jo = JObject.Parse(responseBody);
          * */
        }
    }
}
