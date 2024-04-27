namespace Spiffy
{
    partial class options_customize_text
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbFontName = new System.Windows.Forms.ComboBox();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbWordWrap = new System.Windows.Forms.CheckBox();
            this.cbLogDateTimeEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTipCustomLogging = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(6, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 189);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log Window";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label10);
            this.flowLayoutPanel2.Controls.Add(this.cmbFontName);
            this.flowLayoutPanel2.Controls.Add(this.cmbFontSize);
            this.flowLayoutPanel2.Controls.Add(this.label11);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.button2);
            this.flowLayoutPanel2.Controls.Add(this.cbWordWrap);
            this.flowLayoutPanel2.Controls.Add(this.cbLogDateTimeEnabled);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.textBox1);
            this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(520, 169);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(3, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Font";
            // 
            // cmbFontName
            // 
            this.cmbFontName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppLogDefaultFontName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cmbFontName.FormattingEnabled = true;
            this.cmbFontName.Items.AddRange(new object[] {
            "Arial",
            "Arial Black",
            "Comic Sans MS",
            "Courier New",
            "Dotum",
            "Georgia",
            "Impact",
            "Lucida Console",
            "Tahoma",
            "Times New Roman",
            "Trebuchet MS",
            "Verdana"});
            this.cmbFontName.Location = new System.Drawing.Point(98, 3);
            this.cmbFontName.Name = "cmbFontName";
            this.cmbFontName.Size = new System.Drawing.Size(123, 21);
            this.cmbFontName.TabIndex = 26;
            this.cmbFontName.Text = global::Spiffy.Properties.Settings.Default.AppLogDefaultFontName;
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppLogDefaultFontSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontSize.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cmbFontSize.Location = new System.Drawing.Point(227, 3);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(56, 21);
            this.cmbFontSize.TabIndex = 27;
            this.cmbFontSize.Text = global::Spiffy.Properties.Settings.Default.AppLogDefaultFontSize;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.flowLayoutPanel2.SetFlowBreak(this.label11, true);
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(289, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "pt";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Color";
            // 
            // button1
            // 
            this.button1.BackColor = global::Spiffy.Properties.Settings.Default.AppLogWindowForeColor;
            this.button1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Spiffy.Properties.Settings.Default, "AppLogWindowForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.button1, true);
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.button1.Image = global::Spiffy.Properties.Resources.color_swatch;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(98, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Background";
            // 
            // button2
            // 
            this.button2.BackColor = global::Spiffy.Properties.Settings.Default.AppLogWindowBackColor;
            this.button2.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Spiffy.Properties.Settings.Default, "AppLogWindowBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.button2, true);
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.button2.Image = global::Spiffy.Properties.Resources.color_swatch;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(98, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 38;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbWordWrap
            // 
            this.cbWordWrap.AutoSize = true;
            this.cbWordWrap.Checked = global::Spiffy.Properties.Settings.Default.AppLogWordWrap;
            this.cbWordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWordWrap.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppLogWordWrap", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.cbWordWrap, true);
            this.cbWordWrap.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbWordWrap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbWordWrap.Location = new System.Drawing.Point(3, 88);
            this.cbWordWrap.Name = "cbWordWrap";
            this.cbWordWrap.Size = new System.Drawing.Size(81, 17);
            this.cbWordWrap.TabIndex = 30;
            this.cbWordWrap.Text = "Word Wrap";
            this.cbWordWrap.UseVisualStyleBackColor = true;
            // 
            // cbLogDateTimeEnabled
            // 
            this.cbLogDateTimeEnabled.AutoSize = true;
            this.cbLogDateTimeEnabled.Checked = global::Spiffy.Properties.Settings.Default.AppLogTimeEnabled;
            this.cbLogDateTimeEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLogDateTimeEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppLogTimeEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.cbLogDateTimeEnabled, true);
            this.cbLogDateTimeEnabled.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbLogDateTimeEnabled.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbLogDateTimeEnabled.Location = new System.Drawing.Point(3, 111);
            this.cbLogDateTimeEnabled.Name = "cbLogDateTimeEnabled";
            this.cbLogDateTimeEnabled.Size = new System.Drawing.Size(115, 17);
            this.cbLogDateTimeEnabled.TabIndex = 31;
            this.cbLogDateTimeEnabled.Text = "Log Date and Time";
            this.cbLogDateTimeEnabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppLogTimeEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Enabled = global::Spiffy.Properties.Settings.Default.AppLogTimeEnabled;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Format";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppLogDateTimeFormat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppLogTimeEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Enabled = global::Spiffy.Properties.Settings.Default.AppLogTimeEnabled;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox1.Location = new System.Drawing.Point(98, 134);
            this.textBox1.MaxLength = 45;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 21);
            this.textBox1.TabIndex = 33;
            this.textBox1.Text = global::Spiffy.Properties.Settings.Default.AppLogDateTimeFormat;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Spiffy.Properties.Settings.Default, "AppLogTimeEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pictureBox1.Enabled = global::Spiffy.Properties.Settings.Default.AppLogTimeEnabled;
            this.pictureBox1.Image = global::Spiffy.Properties.Resources.information;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(381, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // toolTipCustomLogging
            // 
            this.toolTipCustomLogging.IsBalloon = true;
            // 
            // checkBox21
            // 
            this.checkBox21.AutoSize = true;
            this.checkBox21.Checked = global::Spiffy.Properties.Settings.Default.AppSpiffyDateFormat;
            this.checkBox21.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkBox21.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppSpiffyDateFormat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox21.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox21.Location = new System.Drawing.Point(3, 3);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(304, 17);
            this.checkBox21.TabIndex = 1;
            this.checkBox21.Text = "Use \'Today\' and \'Yesterday\' instead of date (used in alert)";
            this.checkBox21.UseVisualStyleBackColor = true;
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
            this.label3.Text = "Text";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(6, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 47);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Misc.";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.checkBox21);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // options_customize_text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "options_customize_text";
            this.Size = new System.Drawing.Size(535, 352);
            this.Load += new System.EventHandler(this.options_customize_logging_Load);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTipCustomLogging;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox21;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbFontName;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbWordWrap;
        private System.Windows.Forms.CheckBox cbLogDateTimeEnabled;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
