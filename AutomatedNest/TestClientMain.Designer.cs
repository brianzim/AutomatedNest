namespace AutomatedNest
{
    partial class TestClientMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestClientMain));
            this.button1 = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lblLoginResult = new System.Windows.Forms.Label();
            this.lblWeatherResult = new System.Windows.Forms.Label();
            this.lblStatusResult = new System.Windows.Forms.Label();
            this.lblTargetHumidity = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 76);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(142, 55);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(172, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(142, 91);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(172, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(439, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 80);
            this.button2.TabIndex = 5;
            this.button2.Text = "Get Weather";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Zip";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(142, 130);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(100, 20);
            this.txtZip.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(220, 219);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 78);
            this.button3.TabIndex = 6;
            this.button3.Text = "Get Nest Status";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblLoginResult
            // 
            this.lblLoginResult.AutoSize = true;
            this.lblLoginResult.Location = new System.Drawing.Point(12, 311);
            this.lblLoginResult.Name = "lblLoginResult";
            this.lblLoginResult.Size = new System.Drawing.Size(53, 13);
            this.lblLoginResult.TabIndex = 7;
            this.lblLoginResult.Text = "(no result)";
            // 
            // lblWeatherResult
            // 
            this.lblWeatherResult.AutoSize = true;
            this.lblWeatherResult.Location = new System.Drawing.Point(439, 313);
            this.lblWeatherResult.Name = "lblWeatherResult";
            this.lblWeatherResult.Size = new System.Drawing.Size(53, 13);
            this.lblWeatherResult.TabIndex = 8;
            this.lblWeatherResult.Text = "(no result)";
            // 
            // lblStatusResult
            // 
            this.lblStatusResult.AutoSize = true;
            this.lblStatusResult.Location = new System.Drawing.Point(220, 310);
            this.lblStatusResult.Name = "lblStatusResult";
            this.lblStatusResult.Size = new System.Drawing.Size(53, 13);
            this.lblStatusResult.TabIndex = 9;
            this.lblStatusResult.Text = "(no result)";
            // 
            // lblTargetHumidity
            // 
            this.lblTargetHumidity.AutoSize = true;
            this.lblTargetHumidity.Location = new System.Drawing.Point(439, 339);
            this.lblTargetHumidity.Name = "lblTargetHumidity";
            this.lblTargetHumidity.Size = new System.Drawing.Size(53, 13);
            this.lblTargetHumidity.TabIndex = 10;
            this.lblTargetHumidity.Text = "(no result)";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 370);
            this.Controls.Add(this.lblTargetHumidity);
            this.Controls.Add(this.lblStatusResult);
            this.Controls.Add(this.lblWeatherResult);
            this.Controls.Add(this.lblLoginResult);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Test Client";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblLoginResult;
        private System.Windows.Forms.Label lblWeatherResult;
        private System.Windows.Forms.Label lblStatusResult;
        private System.Windows.Forms.Label lblTargetHumidity;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

