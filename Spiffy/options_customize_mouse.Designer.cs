namespace Spiffy
{
    partial class options_customize_mouse
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel1);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(6, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(526, 114);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
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
            this.label2.TabIndex = 34;
            this.label2.Text = "Mouse";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.checkBox3);
            this.flowLayoutPanel1.Controls.Add(this.checkBox4);
            this.flowLayoutPanel1.Controls.Add(this.checkBox6);
            this.flowLayoutPanel1.Controls.Add(this.checkBox5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 94);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = global::Spiffy.Properties.Settings.Default.AppAlertCloseClickable;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlertCloseClickable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.SetFlowBreak(this.checkBox6, true);
            this.checkBox6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox6.Location = new System.Drawing.Point(3, 49);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(164, 17);
            this.checkBox6.TabIndex = 7;
            this.checkBox6.Text = "Alert \'Close Area\' is clickable.";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = global::Spiffy.Properties.Settings.Default.AppAlertMessageLineClickable;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlertMessageLineClickable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.SetFlowBreak(this.checkBox5, true);
            this.checkBox5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox5.Location = new System.Drawing.Point(3, 72);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(260, 17);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "Alert \'Message Line\' is clickable and opens Inbox.";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = global::Spiffy.Properties.Settings.Default.AppAlertReShowOnMouseOver;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlertReShowOnMouseOver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.SetFlowBreak(this.checkBox4, true);
            this.checkBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox4.Location = new System.Drawing.Point(3, 26);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(203, 17);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "Re-show alert when mouse enters it.";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = global::Spiffy.Properties.Settings.Default.AppAlertKeepVisibleOnMouseOver;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Spiffy.Properties.Settings.Default, "AppAlertKeepVisibleOnMouseOver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.SetFlowBreak(this.checkBox3, true);
            this.checkBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox3.Location = new System.Drawing.Point(3, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(219, 17);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "Keep alert visible when mouse hovers it.";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // options_customize_mouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox4);
            this.Name = "options_customize_mouse";
            this.Size = new System.Drawing.Size(535, 327);
            this.Load += new System.EventHandler(this.options_customize_mouse_Load);
            this.groupBox4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}
