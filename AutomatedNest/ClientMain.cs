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
using System.Configuration;
using System.Security.Cryptography;
using AutomatedNest.ThermostatManager;
using AutomatedNest.NestDataObjects;
using AutomatedNest.ThermostatEngines;
using AutomatedNest.UnofficialNestAPI;

namespace AutomatedNest
{
    public partial class ClientMain : Form
    {
        NestAPICredentialsResponse credentials;

        public ClientMain()
        {
            InitializeComponent();

            loadCredentials();

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
                systemRunning(true);

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
                this.Show();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            UpdateScheduledUpdateTime();
            OptimizeAction();
            
        }

        private void OptimizeAction()
        {
            ThermostatManager.HumidityManager thermostatManager = new ThermostatManager.HumidityManager();

            credentials = thermostatManager.performLogin(txtUserName.Text.ToString(), txtPassword.Text.ToString());

            if (credentials.success)
            {
                saveCredentials();
                logStatus("Credentials validated for: " + credentials.email);
                OptimizeHumidityResult result = thermostatManager.optimizeHumidity(credentials, (HumidityMode)HumidityComboBox.SelectedValue);
                logStatus(result.OperationStatus);
            }
            else
            {
                logStatus(credentials.error);
            }
            
        }

        private void UpdateScheduledUpdateTime()
        {
            int interval;
            int.TryParse(IntervalComboBox.SelectedItem.ToString(), out interval);
            lblSchedueledUpdateTime.Text = DateTime.Now.AddHours(interval).ToString();
        }

        private void logStatus(string status)
        {
            StatusWindow.Text = DateTime.Now + ":" + status + Environment.NewLine + StatusWindow.Text;
            StatusWindow.Select(0, 0);
        }

        private void systemRunning(bool mode)
        {
            if (mode)
            {
                logStatus("Humidity management has started.");

                txtUserName.ReadOnly = true;
                txtPassword.ReadOnly = true;
                StartManagingButton.Enabled = false;
                StopManagingButton.Enabled = true;

                HumidityComboBox.Enabled = false;
                IntervalComboBox.Enabled = false;

                int interval;
                int.TryParse(IntervalComboBox.SelectedItem.ToString(), out interval);

                MainTimer.Interval = 1000 * 60 * 60 * interval;
                MainTimer.Start();

                UpdateScheduledUpdateTime();
                OptimizeAction();
            }
            else
            {
                logStatus("Humidity management has stopped.");

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
        }

        private void saveCredentials()
        {
            // Referenced StackOverflow for encryption - http://stackoverflow.com/questions/12657792/how-to-securely-save-username-password-local

            // Data to protect. Convert a string to a byte[] using Encoding.UTF8.GetBytes().
            byte[] plaintext = Encoding.UTF8.GetBytes(txtPassword.Text.ToString());

            // Generate additional entropy (will be used as the Initialization vector)
            byte[] entropy = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(entropy);
            }

            byte[] ciphertext = ProtectedData.Protect(plaintext, entropy,
                DataProtectionScope.CurrentUser);

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("NestUserName");
            config.AppSettings.Settings.Add("NestUserName", txtUserName.Text.ToString());

            config.AppSettings.Settings.Remove("NestPassword");
            config.AppSettings.Settings.Add("NestPassword", System.Convert.ToBase64String(ciphertext));

            config.AppSettings.Settings.Remove("NestPasswordEntropy");
            config.AppSettings.Settings.Add("NestPasswordEntropy", System.Convert.ToBase64String(entropy));

            config.Save(ConfigurationSaveMode.Modified);
        }

        private void loadCredentials()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            if (config.AppSettings.Settings["NestUserName"].Value != "")
            {
                txtUserName.Text = config.AppSettings.Settings["NestUserName"].Value;

                byte[] entropy = System.Convert.FromBase64String(config.AppSettings.Settings["NestPasswordEntropy"].Value);
                byte[] ciphertext = System.Convert.FromBase64String(config.AppSettings.Settings["NestPassword"].Value);

                txtPassword.Text = System.Text.Encoding.Default.GetString(ProtectedData.Unprotect(ciphertext, entropy, DataProtectionScope.CurrentUser));
            }
        }
 
    }
}
