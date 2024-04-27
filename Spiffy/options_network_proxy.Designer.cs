namespace Spiffy
{
    partial class options_network_proxy
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbProxyEnabled = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbProxyServerName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbProxyServerPort = new System.Windows.Forms.TextBox();
            this.cbProxyAuthReq = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbProxyUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbProxyPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTipProxy = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel1);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(6, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 185);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Settings";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbProxyEnabled);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.tbProxyServerName);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.tbProxyServerPort);
            this.flowLayoutPanel1.Controls.Add(this.cbProxyAuthReq);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.tbProxyUserName);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.tbProxyPassword);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 165);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cbProxyEnabled
            // 
            this.cbProxyEnabled.AutoSize = true;
            this.cbProxyEnabled.Checked = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.cbProxyEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.SetFlowBreak(this.cbProxyEnabled, true);
            this.cbProxyEnabled.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbProxyEnabled.Location = new System.Drawing.Point(3, 3);
            this.cbProxyEnabled.Name = "cbProxyEnabled";
            this.cbProxyEnabled.Size = new System.Drawing.Size(109, 17);
            this.cbProxyEnabled.TabIndex = 13;
            this.cbProxyEnabled.Text = "Use proxy server";
            this.cbProxyEnabled.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label6.Enabled = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(3, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hostname or IP";
            // 
            // tbProxyServerName
            // 
            this.tbProxyServerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "proxyServerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbProxyServerName.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbProxyServerName.Enabled = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.flowLayoutPanel1.SetFlowBreak(this.tbProxyServerName, true);
            this.tbProxyServerName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbProxyServerName.Location = new System.Drawing.Point(107, 26);
            this.tbProxyServerName.Name = "tbProxyServerName";
            this.tbProxyServerName.Size = new System.Drawing.Size(189, 21);
            this.tbProxyServerName.TabIndex = 16;
            this.tbProxyServerName.Text = global::Spiffy.Properties.Settings.Default.proxyServerName;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label7.Enabled = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(3, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Port";
            // 
            // tbProxyServerPort
            // 
            this.tbProxyServerPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "proxyServerPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbProxyServerPort.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbProxyServerPort.Enabled = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.flowLayoutPanel1.SetFlowBreak(this.tbProxyServerPort, true);
            this.tbProxyServerPort.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbProxyServerPort.Location = new System.Drawing.Point(107, 53);
            this.tbProxyServerPort.MaxLength = 5;
            this.tbProxyServerPort.Name = "tbProxyServerPort";
            this.tbProxyServerPort.Size = new System.Drawing.Size(38, 21);
            this.tbProxyServerPort.TabIndex = 17;
            this.tbProxyServerPort.Text = global::Spiffy.Properties.Settings.Default.proxyServerPort;
            this.tbProxyServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbProxyServerPort_KeyPress);
            // 
            // cbProxyAuthReq
            // 
            this.cbProxyAuthReq.AutoSize = true;
            this.cbProxyAuthReq.Checked = global::Spiffy.Properties.Settings.Default.proxyServerAuthReq;
            this.cbProxyAuthReq.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "proxyServerAuthReq", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbProxyAuthReq.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbProxyAuthReq.Enabled = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.flowLayoutPanel1.SetFlowBreak(this.cbProxyAuthReq, true);
            this.cbProxyAuthReq.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbProxyAuthReq.Location = new System.Drawing.Point(3, 80);
            this.cbProxyAuthReq.Name = "cbProxyAuthReq";
            this.cbProxyAuthReq.Size = new System.Drawing.Size(190, 17);
            this.cbProxyAuthReq.TabIndex = 15;
            this.cbProxyAuthReq.Text = "This proxy &requires authentication";
            this.cbProxyAuthReq.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label8.Enabled = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.Location = new System.Drawing.Point(3, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Username";
            // 
            // tbProxyUserName
            // 
            this.tbProxyUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "proxyServerUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbProxyUserName.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbProxyUserName.Enabled = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.flowLayoutPanel1.SetFlowBreak(this.tbProxyUserName, true);
            this.tbProxyUserName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbProxyUserName.Location = new System.Drawing.Point(107, 103);
            this.tbProxyUserName.Name = "tbProxyUserName";
            this.tbProxyUserName.Size = new System.Drawing.Size(189, 21);
            this.tbProxyUserName.TabIndex = 18;
            this.tbProxyUserName.Tag = "#none";
            this.tbProxyUserName.Text = global::Spiffy.Properties.Settings.Default.proxyServerUsername;
            this.toolTipProxy.SetToolTip(this.tbProxyUserName, "username or domain\\username");
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label9.Enabled = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.Location = new System.Drawing.Point(3, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Password";
            // 
            // tbProxyPassword
            // 
            this.tbProxyPassword.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "proxyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbProxyPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "proxyServerPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbProxyPassword.Enabled = global::Spiffy.Properties.Settings.Default.proxyEnabled;
            this.tbProxyPassword.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbProxyPassword.Location = new System.Drawing.Point(107, 130);
            this.tbProxyPassword.Name = "tbProxyPassword";
            this.tbProxyPassword.PasswordChar = '*';
            this.tbProxyPassword.Size = new System.Drawing.Size(189, 21);
            this.tbProxyPassword.TabIndex = 19;
            this.tbProxyPassword.Text = global::Spiffy.Properties.Settings.Default.proxyServerPassword;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Help;
            this.flowLayoutPanel1.SetFlowBreak(this.pictureBox1, true);
            this.pictureBox1.Image = global::Spiffy.Properties.Resources.information;
            this.pictureBox1.Location = new System.Drawing.Point(302, 132);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // toolTipProxy
            // 
            this.toolTipProxy.IsBalloon = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGreen;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(526, 23);
            this.label3.TabIndex = 33;
            this.label3.Text = "Proxy";
            // 
            // options_network_proxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "options_network_proxy";
            this.Size = new System.Drawing.Size(535, 328);
            this.Load += new System.EventHandler(this.options_network_proxy_Load);
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolTip toolTipProxy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cbProxyEnabled;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbProxyServerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbProxyServerPort;
        private System.Windows.Forms.CheckBox cbProxyAuthReq;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tbProxyUserName;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox tbProxyPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
