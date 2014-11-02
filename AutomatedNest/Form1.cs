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
using AutomatedNest.ThermostatEngines;

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

                if (credentials.success)
                {
                    lblLoginResult.Text = credentials.user;
                }
                else
                {
                    MessageBox.Show(credentials.error, "Failed to Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                NestForecastBase forecast = ForecastManager.ForecastManager.getForecast(credentials, txtZip.Text.ToString());
                lblWeatherResult.Text = "Lowest Forecasted Temp: " + forecast.LowestForecastTemp.ToString();
                lblTargetHumidity.Text = "Target Humidity: " + ForecastManager.ForecastManager.calculateTargetHumidity(forecast, ThermostatEngines.HumidityEngines.HumidityMode.Normal);
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
 
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();

            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
 
    }
}
