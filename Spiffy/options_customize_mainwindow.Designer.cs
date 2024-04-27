namespace Spiffy
{
    partial class options_customize_mainwindow
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAppWindowTitle = new System.Windows.Forms.TextBox();
            this.cbAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.cbAppShowMenuBar = new System.Windows.Forms.CheckBox();
            this.cbAppShowToolBar = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(6, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 65);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Translucency";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.flowLayoutPanel2);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(6, 103);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(526, 148);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Misc.";
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
            this.label2.Text = "Main Window";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.trackBar1);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 45);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Opacity";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(466, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.trackBar1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Spiffy.Properties.Settings.Default, "AppOpacity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBar1.Location = new System.Drawing.Point(93, 3);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(367, 42);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = global::Spiffy.Properties.Settings.Default.AppOpacity;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cbAlwaysOnTop);
            this.flowLayoutPanel2.Controls.Add(this.cbAppShowMenuBar);
            this.flowLayoutPanel2.Controls.Add(this.cbAppShowToolBar);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.tbAppWindowTitle);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(520, 128);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.flowLayoutPanel2.SetFlowBreak(this.label1, true);
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(3, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Title Bar / Tray Tooltip text";
            // 
            // tbAppWindowTitle
            // 
            this.tbAppWindowTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Spiffy.Properties.Settings.Default, "AppWindowTitleText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAppWindowTitle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbAppWindowTitle.Location = new System.Drawing.Point(3, 99);
            this.tbAppWindowTitle.MaxLength = 40;
            this.tbAppWindowTitle.Name = "tbAppWindowTitle";
            this.tbAppWindowTitle.Size = new System.Drawing.Size(237, 21);
            this.tbAppWindowTitle.TabIndex = 9;
            this.tbAppWindowTitle.Text = global::Spiffy.Properties.Settings.Default.AppWindowTitleText;
            // 
            // cbAlwaysOnTop
            // 
            this.cbAlwaysOnTop.AutoSize = true;
            this.cbAlwaysOnTop.Checked = global::Spiffy.Properties.Settings.Default.AppAlwaysOnTop;
            this.cbAlwaysOnTop.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.cbAlwaysOnTop, true);
            this.cbAlwaysOnTop.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbAlwaysOnTop.Location = new System.Drawing.Point(3, 3);
            this.cbAlwaysOnTop.Name = "cbAlwaysOnTop";
            this.cbAlwaysOnTop.Size = new System.Drawing.Size(98, 17);
            this.cbAlwaysOnTop.TabIndex = 10;
            this.cbAlwaysOnTop.Text = "Always On Top";
            this.cbAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // cbAppShowMenuBar
            // 
            this.cbAppShowMenuBar.AutoSize = true;
            this.cbAppShowMenuBar.Checked = global::Spiffy.Properties.Settings.Default.AppMenuStripVisible;
            this.cbAppShowMenuBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAppShowMenuBar.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppMenuStripVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.cbAppShowMenuBar, true);
            this.cbAppShowMenuBar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbAppShowMenuBar.Location = new System.Drawing.Point(3, 26);
            this.cbAppShowMenuBar.Name = "cbAppShowMenuBar";
            this.cbAppShowMenuBar.Size = new System.Drawing.Size(100, 17);
            this.cbAppShowMenuBar.TabIndex = 11;
            this.cbAppShowMenuBar.Text = "Show Menu Bar";
            this.cbAppShowMenuBar.UseVisualStyleBackColor = true;
            // 
            // cbAppShowToolBar
            // 
            this.cbAppShowToolBar.AutoSize = true;
            this.cbAppShowToolBar.Checked = global::Spiffy.Properties.Settings.Default.AppToolStripVisible;
            this.cbAppShowToolBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAppShowToolBar.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppToolStripVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel2.SetFlowBreak(this.cbAppShowToolBar, true);
            this.cbAppShowToolBar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbAppShowToolBar.Location = new System.Drawing.Point(3, 49);
            this.cbAppShowToolBar.Name = "cbAppShowToolBar";
            this.cbAppShowToolBar.Size = new System.Drawing.Size(94, 17);
            this.cbAppShowToolBar.TabIndex = 12;
            this.cbAppShowToolBar.Text = "Show Tool Bar";
            this.cbAppShowToolBar.UseVisualStyleBackColor = true;
            // 
            // options_customize_mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "options_customize_mainwindow";
            this.Size = new System.Drawing.Size(535, 328);
            this.Load += new System.EventHandler(this.options_customize_mainwindow_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox cbAlwaysOnTop;
        private System.Windows.Forms.CheckBox cbAppShowMenuBar;
        private System.Windows.Forms.CheckBox cbAppShowToolBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAppWindowTitle;
    }
}
