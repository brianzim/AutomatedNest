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
            if (txtUserName.Text.ToString().Equals("") || txtPassword.Text.ToString().Equals(""))
            {
                MessageBox.Show("Please enter a UN and PW.");
            }
            else
            {
                credentials = ThermostatManager.ThermostatManager.performLogin(txtUserName.Text.ToString(), txtPassword.Text.ToString());
                lblLoginResult.Text = credentials.User;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtZip.Text.ToString().Equals(""))
            {
                MessageBox.Show("Please enter your zip.");
            }
            else if(credentials == null)
            {
                MessageBox.Show("Please log in.");
            }
            else
            {
                NestForecast forecast = ForecastManager.ForecastManager.getForecast(credentials, txtZip.Text.ToString());
                lblWeatherResult.Text = "Lowest Forecasted Temp: " + forecast.LowestForecastTemp.ToString();
                lblTargetHumidity.Text = "Target Humidity: " + ForecastManager.ForecastManager.calculateTargetHumidity(forecast);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (credentials == null)
            {
                MessageBox.Show("Please log in.");
            }
            else
            {
                NestStatus status = ThermostatManager.ThermostatManager.getStatus(credentials);
                lblStatusResult.Text = "Current Humidity: " + status.CurrentHumidity;
                txtZip.Text = status.PostalCode;
            }
        }

        private void lblStatusResult_Click(object sender, EventArgs e)
        {

        }
    }
}
