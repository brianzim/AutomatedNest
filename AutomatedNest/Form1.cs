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

namespace AutomatedNest
{
    public partial class Form1 : Form
    {

        const string user_agent = "Nest/2.1.3 CFNetwork/548.0.4"; 
        const string protocol_version = "1"; 
        const string login_url = "https://home.nest.com/user/login";

        NestCredentials nc;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = WebRequest.Create(login_url) as HttpWebRequest;
            request.Method = "POST";
            request.UserAgent = "'Nest/2.1.3 CFNetwork/548.0.4'";
            request.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(WriteEncodedFormParameter("username", txtUserName.Text.ToString()));
                writer.Write("&");
                writer.Write(WriteEncodedFormParameter("password", txtPassword.Text.ToString()));
            }

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

            nc = new NestCredentials(jo.urls.transport_url.ToString(), jo.access_token.ToString(), jo.user.ToString(), jo.userid.ToString(), jo.expires_in.ToString());

            
        }

        private string WriteEncodedFormParameter(string key, string value)
        {
            return WriteEncodedFormParameter(key, value, false);
        }

        private string WriteEncodedFormParameter(string key, string value, bool isUrl)
        {

            var encoded = string.Format("{0}={1}", Uri.EscapeUriString(key), Uri.EscapeUriString(value));
            return (isUrl ? encoded.Replace("%20", "+") : encoded);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string url = nc.TransportURL + "/v2/mobile/" + nc.User;
            string url = "https://home.nest.com/api/0.1/weather/forecast/" + txtZip.Text.ToString();
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = "'Nest/2.1.3 CFNetwork/548.0.4'";
            request.Headers.Add("X-nl-protocol-version", protocol_version);
            request.Headers.Add("X-nl-user-d", nc.UserID);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Set("Authorization", string.Format("Basic ", nc.AccessToken));

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
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
        }
    }
}
