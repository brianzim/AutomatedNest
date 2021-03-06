﻿namespace AutomatedNest
{
    partial class ClientMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMain));
            this.StartManagingButton = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.StatusWindow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StopManagingButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.IntervalComboBox = new System.Windows.Forms.ComboBox();
            this.HumidityComboBox = new System.Windows.Forms.ComboBox();
            this.lblNexScheduledUpdate = new System.Windows.Forms.Label();
            this.lblSchedueledUpdateTime = new System.Windows.Forms.Label();
            this.chkSaveCredentials = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // StartManagingButton
            // 
            this.StartManagingButton.Location = new System.Drawing.Point(442, 21);
            this.StartManagingButton.Name = "StartManagingButton";
            this.StartManagingButton.Size = new System.Drawing.Size(142, 76);
            this.StartManagingButton.TabIndex = 4;
            this.StartManagingButton.Text = "Start Managing Humidity";
            this.StartManagingButton.UseVisualStyleBackColor = true;
            this.StartManagingButton.Click += new System.EventHandler(this.StartManagingButton_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(188, 50);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(189, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(188, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(189, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "AutomatedNest is still running";
            this.notifyIcon1.BalloonTipTitle = "AutomatedNest";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 5000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // StatusWindow
            // 
            this.StatusWindow.Location = new System.Drawing.Point(13, 304);
            this.StatusWindow.Multiline = true;
            this.StatusWindow.Name = "StatusWindow";
            this.StatusWindow.ReadOnly = true;
            this.StatusWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.StatusWindow.Size = new System.Drawing.Size(606, 286);
            this.StatusWindow.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Status Window";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Humidity Mode";
            // 
            // StopManagingButton
            // 
            this.StopManagingButton.Enabled = false;
            this.StopManagingButton.Location = new System.Drawing.Point(442, 116);
            this.StopManagingButton.Name = "StopManagingButton";
            this.StopManagingButton.Size = new System.Drawing.Size(142, 76);
            this.StopManagingButton.TabIndex = 10;
            this.StopManagingButton.Text = "Stop Managing Humidity";
            this.StopManagingButton.UseVisualStyleBackColor = true;
            this.StopManagingButton.Click += new System.EventHandler(this.StopManagingButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Interval Time (hrs)";
            // 
            // IntervalComboBox
            // 
            this.IntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IntervalComboBox.FormattingEnabled = true;
            this.IntervalComboBox.Items.AddRange(new object[] {
            "1",
            "6",
            "12",
            "24"});
            this.IntervalComboBox.Location = new System.Drawing.Point(188, 146);
            this.IntervalComboBox.Name = "IntervalComboBox";
            this.IntervalComboBox.Size = new System.Drawing.Size(189, 21);
            this.IntervalComboBox.TabIndex = 12;
            // 
            // HumidityComboBox
            // 
            this.HumidityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HumidityComboBox.FormattingEnabled = true;
            this.HumidityComboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.HumidityComboBox.Location = new System.Drawing.Point(188, 116);
            this.HumidityComboBox.Name = "HumidityComboBox";
            this.HumidityComboBox.Size = new System.Drawing.Size(189, 21);
            this.HumidityComboBox.TabIndex = 8;
            // 
            // lblNexScheduledUpdate
            // 
            this.lblNexScheduledUpdate.AutoSize = true;
            this.lblNexScheduledUpdate.Location = new System.Drawing.Point(44, 188);
            this.lblNexScheduledUpdate.Name = "lblNexScheduledUpdate";
            this.lblNexScheduledUpdate.Size = new System.Drawing.Size(124, 13);
            this.lblNexScheduledUpdate.TabIndex = 13;
            this.lblNexScheduledUpdate.Text = "Next Scheduled Update:";
            // 
            // lblSchedueledUpdateTime
            // 
            this.lblSchedueledUpdateTime.AutoSize = true;
            this.lblSchedueledUpdateTime.Location = new System.Drawing.Point(185, 188);
            this.lblSchedueledUpdateTime.Name = "lblSchedueledUpdateTime";
            this.lblSchedueledUpdateTime.Size = new System.Drawing.Size(37, 13);
            this.lblSchedueledUpdateTime.TabIndex = 14;
            this.lblSchedueledUpdateTime.Text = "(none)";
            // 
            // chkSaveCredentials
            // 
            this.chkSaveCredentials.AutoSize = true;
            this.chkSaveCredentials.Location = new System.Drawing.Point(188, 216);
            this.chkSaveCredentials.Name = "chkSaveCredentials";
            this.chkSaveCredentials.Size = new System.Drawing.Size(172, 17);
            this.chkSaveCredentials.TabIndex = 15;
            this.chkSaveCredentials.Text = "Save Credentials and Autostart";
            this.chkSaveCredentials.UseVisualStyleBackColor = true;
            // 
            // ClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 593);
            this.Controls.Add(this.chkSaveCredentials);
            this.Controls.Add(this.lblSchedueledUpdateTime);
            this.Controls.Add(this.lblNexScheduledUpdate);
            this.Controls.Add(this.IntervalComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StopManagingButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HumidityComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StatusWindow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.StartManagingButton);
            this.Name = "ClientMain";
            this.ShowInTaskbar = false;
            this.Text = "AutomatedNest";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartManagingButton;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.TextBox StatusWindow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StopManagingButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox IntervalComboBox;
        private System.Windows.Forms.ComboBox HumidityComboBox;
        private System.Windows.Forms.Label lblNexScheduledUpdate;
        private System.Windows.Forms.Label lblSchedueledUpdateTime;
        private System.Windows.Forms.CheckBox chkSaveCredentials;
    }
}

