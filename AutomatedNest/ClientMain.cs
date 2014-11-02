﻿using System;
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
    public partial class ClientMain : Form
    {
        NestCredentials credentials;

        public ClientMain()
        {
            InitializeComponent();

            HumidityComboBox.DataSource = Enum.GetValues(typeof(HumidityMode))
             .Cast<HumidityMode>()
             .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();

            HumidityComboBox.DisplayMember = "Value";
            HumidityComboBox.ValueMember = "Key";

            HumidityComboBox.SelectedIndex = 1;

            IntervalComboBox.SelectedIndex = 1;
        }

        private void StartManagingButton_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.ToString().Equals("") || txtPassword.Text.ToString().Equals(""))
            {
                MessageBox.Show("Please enter a username and password to begin.");
            }
            else
            {
                credentials = ThermostatManager.ThermostatManager.performLogin(txtUserName.Text.ToString(), txtPassword.Text.ToString());

                if (credentials.success)
                {
                    logStatus("Successful login by " + credentials.email);
                    systemRunning(true);

                }
                else
                {
                    MessageBox.Show(credentials.error, "Failed to Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            logStatus("Tick");
        }

        private void logStatus(string status)
        {

            StatusWindow.AppendText(DateTime.Now + ":" + status + "\n");
        }

        private void systemRunning(bool mode)
        {
            if (mode)
            {
                txtUserName.ReadOnly = true;
                txtPassword.ReadOnly = true;
                StartManagingButton.Enabled = false;
                StopManagingButton.Enabled = true;

                HumidityComboBox.Enabled = false;
                IntervalComboBox.Enabled = false;

                int interval;

                int.TryParse(IntervalComboBox.SelectedItem.ToString(), out interval);

                MainTimer.Interval = 1000 * interval;
                MainTimer.Start();
            }
            else
            {
                txtUserName.ReadOnly = false;
                txtPassword.ReadOnly = false;

                HumidityComboBox.Enabled = true;
                IntervalComboBox.Enabled = true;

                StartManagingButton.Enabled = true;
                StopManagingButton.Enabled = false;

                MainTimer.Stop();
            }
        }

        private void StopManagingButton_Click(object sender, EventArgs e)
        {
            systemRunning(false);
            logStatus("Monitoring Stopped");
        }
 
    }
}