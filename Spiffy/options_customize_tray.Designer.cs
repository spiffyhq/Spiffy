namespace Spiffy
{
    partial class options_customize_tray
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.settingsTrayIconTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(6, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.comboBox1);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.comboBox2);
            this.flowLayoutPanel1.Controls.Add(this.checkBox4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 106);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Default Icon";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppDefaultTrayIcon", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flowLayoutPanel1.SetFlowBreak(this.comboBox1, true);
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(75, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.Text = global::Spiffy.Properties.Settings.Default.AppDefaultTrayIcon;
            // 
            // label3
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.label3, true);
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(514, 27);
            this.label3.TabIndex = 23;
            this.label3.Text = "When doubleclicking Tray Icon do this:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppTrayIconBehaviour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flowLayoutPanel1.SetFlowBreak(this.comboBox2, true);
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(3, 57);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(217, 21);
            this.comboBox2.TabIndex = 24;
            this.comboBox2.Text = global::Spiffy.Properties.Settings.Default.AppTrayIconBehaviour;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGreen;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(526, 23);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tray Icon";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(6, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 110);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Custom Tray Icons";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.checkBox3);
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.Controls.Add(this.textBox1);
            this.flowLayoutPanel3.Controls.Add(this.button1);
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.textBox2);
            this.flowLayoutPanel3.Controls.Add(this.button2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(520, 90);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = global::Spiffy.Properties.Settings.Default.AppEnableCustomTrayIcons;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppEnableCustomTrayIcons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel3.SetFlowBreak(this.checkBox3, true);
            this.checkBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox3.Location = new System.Drawing.Point(3, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(145, 17);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "Enable custom tray icons";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppEnableCustomTrayIcons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label4.Enabled = global::Spiffy.Properties.Settings.Default.AppEnableCustomTrayIcons;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Default Icon";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppCustomTrayIconDefaultPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppEnableCustomTrayIcons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Enabled = global::Spiffy.Properties.Settings.Default.AppEnableCustomTrayIcons;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox1.Location = new System.Drawing.Point(93, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(388, 21);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = global::Spiffy.Properties.Settings.Default.AppCustomTrayIconDefaultPath;
            // 
            // button1
            // 
            this.button1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppEnableCustomTrayIcons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button1.Enabled = global::Spiffy.Properties.Settings.Default.AppEnableCustomTrayIcons;
            this.flowLayoutPanel3.SetFlowBreak(this.button1, true);
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.button1.Image = global::Spiffy.Properties.Resources.folder_explore;
            this.button1.Location = new System.Drawing.Point(487, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Cursor = System.Windows.Forms.Cursors.Help;
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppEnableCustomTrayIcons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label5.Enabled = global::Spiffy.Properties.Settings.Default.AppEnableCustomTrayIcons;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "New mail Icon";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppEnableCustomTrayIcons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppCustomTrayIconNewmailIconPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Enabled = global::Spiffy.Properties.Settings.Default.AppEnableCustomTrayIcons;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox2.Location = new System.Drawing.Point(93, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(388, 21);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = global::Spiffy.Properties.Settings.Default.AppCustomTrayIconNewmailIconPath;
            // 
            // button2
            // 
            this.button2.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppEnableCustomTrayIcons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button2.Enabled = global::Spiffy.Properties.Settings.Default.AppEnableCustomTrayIcons;
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.button2.Image = global::Spiffy.Properties.Resources.folder_explore;
            this.button2.Location = new System.Drawing.Point(487, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // settingsTrayIconTooltip
            // 
            this.settingsTrayIconTooltip.IsBalloon = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel2);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(6, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 76);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New Mail Counter";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.checkBox1);
            this.flowLayoutPanel2.Controls.Add(this.comboBox3);
            this.flowLayoutPanel2.Controls.Add(this.checkBox2);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(520, 56);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::Spiffy.Properties.Settings.Default.AppShowUnreadInTray;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppShowUnreadInTray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.checkBox1, true);
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(233, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Show unread count in Tray Icon tooltip for:";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppShowUnreadInTray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppShowUnreadInTrayAccount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Enabled = global::Spiffy.Properties.Settings.Default.AppShowUnreadInTray;
            this.comboBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(3, 30);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(160, 21);
            this.comboBox3.TabIndex = 15;
            this.comboBox3.Text = global::Spiffy.Properties.Settings.Default.AppShowUnreadInTrayAccount;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = global::Spiffy.Properties.Settings.Default.AppShowUnreadAccountInTray;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppShowUnreadAccountInTray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppShowUnreadInTray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Enabled = global::Spiffy.Properties.Settings.Default.AppShowUnreadInTray;
            this.checkBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox2.Location = new System.Drawing.Point(169, 32);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(122, 17);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "Show account name";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = global::Spiffy.Properties.Settings.Default.AppTraySingleClick;
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppTraySingleClick", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox4.Location = new System.Drawing.Point(3, 84);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(258, 17);
            this.checkBox4.TabIndex = 25;
            this.checkBox4.Text = "Use single click instead of double click for actions";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // options_customize_tray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "options_customize_tray";
            this.Size = new System.Drawing.Size(535, 378);
            this.Load += new System.EventHandler(this.options_customize_tray_Load);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip settingsTrayIconTooltip;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox4;
    }
}
