namespace Spiffy
{
    partial class options_alerts
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tbAlertSound = new System.Windows.Forms.TextBox();
            this.btnBrowseForSound = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbAppTrayIconChangeEnabled = new System.Windows.Forms.CheckBox();
            this.cmbTrayIcon = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbShowAlert = new System.Windows.Forms.CheckBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbShowUntilRead = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cbAlertSliding = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown13 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown14 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel4);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(6, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 78);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Play sound alert on new e-mail";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.checkBox3);
            this.flowLayoutPanel4.Controls.Add(this.tbAlertSound);
            this.flowLayoutPanel4.Controls.Add(this.btnBrowseForSound);
            this.flowLayoutPanel4.Controls.Add(this.button1);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(520, 58);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = global::Spiffy.Properties.Settings.Default.AppAlertSoundEnabled;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlertSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel4.SetFlowBreak(this.checkBox3, true);
            this.checkBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox3.Location = new System.Drawing.Point(3, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(115, 17);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Enable sound alert";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // tbAlertSound
            // 
            this.tbAlertSound.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppAlertSound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAlertSound.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppAlertSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAlertSound.Enabled = global::Spiffy.Properties.Settings.Default.AppAlertSoundEnabled;
            this.tbAlertSound.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbAlertSound.Location = new System.Drawing.Point(3, 26);
            this.tbAlertSound.Name = "tbAlertSound";
            this.tbAlertSound.Size = new System.Drawing.Size(437, 21);
            this.tbAlertSound.TabIndex = 3;
            this.tbAlertSound.Text = global::Spiffy.Properties.Settings.Default.AppAlertSound;
            // 
            // btnBrowseForSound
            // 
            this.btnBrowseForSound.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppAlertSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnBrowseForSound.Enabled = global::Spiffy.Properties.Settings.Default.AppAlertSoundEnabled;
            this.btnBrowseForSound.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnBrowseForSound.Image = global::Spiffy.Properties.Resources.folder_explore;
            this.btnBrowseForSound.Location = new System.Drawing.Point(446, 26);
            this.btnBrowseForSound.Name = "btnBrowseForSound";
            this.btnBrowseForSound.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseForSound.TabIndex = 4;
            this.btnBrowseForSound.UseVisualStyleBackColor = true;
            this.btnBrowseForSound.Click += new System.EventHandler(this.btnBrowseForSound_Click);
            // 
            // button1
            // 
            this.button1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppAlertSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button1.Enabled = global::Spiffy.Properties.Settings.Default.AppAlertSoundEnabled;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.button1.Image = global::Spiffy.Properties.Resources.sound;
            this.button1.Location = new System.Drawing.Point(482, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.flowLayoutPanel3);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox6.Location = new System.Drawing.Point(6, 266);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(526, 76);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tray Icon";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.cbAppTrayIconChangeEnabled);
            this.flowLayoutPanel3.Controls.Add(this.cmbTrayIcon);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(520, 56);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // cbAppTrayIconChangeEnabled
            // 
            this.cbAppTrayIconChangeEnabled.AutoSize = true;
            this.cbAppTrayIconChangeEnabled.Checked = global::Spiffy.Properties.Settings.Default.AppTrayIconChange;
            this.cbAppTrayIconChangeEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppTrayIconChange", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel3.SetFlowBreak(this.cbAppTrayIconChangeEnabled, true);
            this.cbAppTrayIconChangeEnabled.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbAppTrayIconChangeEnabled.Location = new System.Drawing.Point(3, 3);
            this.cbAppTrayIconChangeEnabled.Name = "cbAppTrayIconChangeEnabled";
            this.cbAppTrayIconChangeEnabled.Size = new System.Drawing.Size(268, 17);
            this.cbAppTrayIconChangeEnabled.TabIndex = 3;
            this.cbAppTrayIconChangeEnabled.Text = "Change tray icon on new e-mail, and use this icon:";
            this.cbAppTrayIconChangeEnabled.UseVisualStyleBackColor = true;
            // 
            // cmbTrayIcon
            // 
            this.cmbTrayIcon.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppTrayIconChange", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbTrayIcon.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppTrayIconAlertImage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbTrayIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrayIcon.Enabled = global::Spiffy.Properties.Settings.Default.AppTrayIconChange;
            this.cmbTrayIcon.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cmbTrayIcon.FormattingEnabled = true;
            this.cmbTrayIcon.Location = new System.Drawing.Point(3, 30);
            this.cmbTrayIcon.Name = "cmbTrayIcon";
            this.cmbTrayIcon.Size = new System.Drawing.Size(150, 21);
            this.cmbTrayIcon.TabIndex = 4;
            this.cmbTrayIcon.Text = global::Spiffy.Properties.Settings.Default.AppTrayIconAlertImage;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(6, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 98);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbShowAlert);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDown3);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.cbShowUntilRead);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDown1);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 78);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cbShowAlert
            // 
            this.cbShowAlert.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbShowAlert.AutoSize = true;
            this.cbShowAlert.Checked = global::Spiffy.Properties.Settings.Default.AppAlertEnabled;
            this.cbShowAlert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowAlert.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlertEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbShowAlert.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbShowAlert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbShowAlert.Location = new System.Drawing.Point(3, 5);
            this.cbShowAlert.Name = "cbShowAlert";
            this.cbShowAlert.Size = new System.Drawing.Size(221, 17);
            this.cbShowAlert.TabIndex = 25;
            this.cbShowAlert.Text = "Show alert on new e-mail and show it for";
            this.cbShowAlert.UseVisualStyleBackColor = true;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Spiffy.Properties.Settings.Default, "AppAlertDelay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.numericUpDown3.Location = new System.Drawing.Point(230, 3);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown3.TabIndex = 28;
            this.numericUpDown3.Value = global::Spiffy.Properties.Settings.Default.AppAlertDelay;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.label4, true);
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(284, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "second(s).";
            // 
            // cbShowUntilRead
            // 
            this.cbShowUntilRead.AutoSize = true;
            this.cbShowUntilRead.Checked = global::Spiffy.Properties.Settings.Default.AppAlertShowUntilRead;
            this.cbShowUntilRead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowUntilRead.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlertShowUntilRead", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.SetFlowBreak(this.cbShowUntilRead, true);
            this.cbShowUntilRead.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbShowUntilRead.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbShowUntilRead.Location = new System.Drawing.Point(3, 30);
            this.cbShowUntilRead.Name = "cbShowUntilRead";
            this.cbShowUntilRead.Size = new System.Drawing.Size(385, 17);
            this.cbShowUntilRead.TabIndex = 29;
            this.cbShowUntilRead.Text = "Show alert until e-mail is read in Gmail, if unchecked alerts are shown once.";
            this.cbShowUntilRead.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Show a maximum of";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Spiffy.Properties.Settings.Default, "AppAlertShowNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.numericUpDown1.Location = new System.Drawing.Point(111, 53);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown1.TabIndex = 31;
            this.numericUpDown1.Value = global::Spiffy.Properties.Settings.Default.AppAlertShowNumber;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(157, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "alert(s) for each account, every check.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel2);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(6, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 124);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Behavior";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.checkBox2);
            this.flowLayoutPanel2.Controls.Add(this.cbAlertSliding);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.numericUpDown13);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.label10);
            this.flowLayoutPanel2.Controls.Add(this.numericUpDown14);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(520, 104);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = global::Spiffy.Properties.Settings.Default.AppAlertsStackAlerts;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlertsStackAlerts", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.checkBox2, true);
            this.checkBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox2.Location = new System.Drawing.Point(3, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(335, 17);
            this.checkBox2.TabIndex = 33;
            this.checkBox2.Text = "Stack alerts, if unchecked alerts are all shown in the same place.";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // cbAlertSliding
            // 
            this.cbAlertSliding.AutoSize = true;
            this.cbAlertSliding.Checked = global::Spiffy.Properties.Settings.Default.AppAlertSliding;
            this.cbAlertSliding.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlertSliding", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.cbAlertSliding, true);
            this.cbAlertSliding.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbAlertSliding.Location = new System.Drawing.Point(3, 26);
            this.cbAlertSliding.Name = "cbAlertSliding";
            this.cbAlertSliding.Size = new System.Drawing.Size(200, 17);
            this.cbAlertSliding.TabIndex = 26;
            this.cbAlertSliding.Text = "Show alert Sliding instead of Fading.";
            this.cbAlertSliding.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.Location = new System.Drawing.Point(3, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Show in";
            // 
            // numericUpDown13
            // 
            this.numericUpDown13.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Spiffy.Properties.Settings.Default, "AppAlertShowDelay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.numericUpDown13.Location = new System.Drawing.Point(81, 49);
            this.numericUpDown13.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown13.Name = "numericUpDown13";
            this.numericUpDown13.Size = new System.Drawing.Size(55, 21);
            this.numericUpDown13.TabIndex = 29;
            this.numericUpDown13.Value = global::Spiffy.Properties.Settings.Default.AppAlertShowDelay;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.flowLayoutPanel2.SetFlowBreak(this.label1, true);
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(142, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "ms";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.Location = new System.Drawing.Point(3, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Hide in";
            // 
            // numericUpDown14
            // 
            this.numericUpDown14.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Spiffy.Properties.Settings.Default, "AppAlertHideDelay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown14.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.numericUpDown14.Location = new System.Drawing.Point(81, 76);
            this.numericUpDown14.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown14.Name = "numericUpDown14";
            this.numericUpDown14.Size = new System.Drawing.Size(55, 21);
            this.numericUpDown14.TabIndex = 30;
            this.numericUpDown14.Value = global::Spiffy.Properties.Settings.Default.AppAlertHideDelay;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(142, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "ms";
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
            this.label3.TabIndex = 32;
            this.label3.Text = "Alerts";
            // 
            // options_alerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "options_alerts";
            this.Size = new System.Drawing.Size(535, 432);
            this.Load += new System.EventHandler(this.options_alerts_Load);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cbShowAlert;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbShowUntilRead;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox cbAlertSliding;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.CheckBox cbAppTrayIconChangeEnabled;
        private System.Windows.Forms.ComboBox cmbTrayIcon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox tbAlertSound;
        private System.Windows.Forms.Button btnBrowseForSound;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;

    }
}
