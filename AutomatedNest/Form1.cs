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
        {
            NestStatus status = ThermostatManager.ThermostatManager.getStatus(credentials);
        }
    }
}
