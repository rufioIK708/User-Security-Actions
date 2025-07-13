namespace User_Security_Actions
{
    partial class TAPForm
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
            this.tapDatePicker = new System.Windows.Forms.DateTimePicker();
            this.labellabelStartDateTime = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxReUse = new System.Windows.Forms.CheckBox();
            this.labelReusable = new System.Windows.Forms.Label();
            this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
            this.tapTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // tapDatePicker
            // 
            this.tapDatePicker.CustomFormat = "MMMMdd, yyyy";
            this.tapDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tapDatePicker.Location = new System.Drawing.Point(238, 57);
            this.tapDatePicker.MinDate = new System.DateTime(2025, 4, 20, 0, 0, 0, 0);
            this.tapDatePicker.Name = "tapDatePicker";
            this.tapDatePicker.Size = new System.Drawing.Size(132, 20);
            this.tapDatePicker.TabIndex = 0;
            this.tapDatePicker.Value = new System.DateTime(2025, 4, 20, 16, 20, 0, 0);
            // 
            // labellabelStartDateTime
            // 
            this.labellabelStartDateTime.AutoSize = true;
            this.labellabelStartDateTime.Location = new System.Drawing.Point(26, 51);
            this.labellabelStartDateTime.Name = "labellabelStartDateTime";
            this.labellabelStartDateTime.Size = new System.Drawing.Size(205, 26);
            this.labellabelStartDateTime.TabIndex = 1;
            this.labellabelStartDateTime.Text = "Please select the start time for the TAP\r\nRecommend selecting 7+ hours from now.\r" +
    "\n";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(47, 86);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(168, 13);
            this.labelDuration.TabIndex = 2;
            this.labelDuration.Text = "Please set the duration in minutes:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Create TAP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxReUse
            // 
            this.checkBoxReUse.AutoSize = true;
            this.checkBoxReUse.Location = new System.Drawing.Point(267, 109);
            this.checkBoxReUse.Name = "checkBoxReUse";
            this.checkBoxReUse.Size = new System.Drawing.Size(15, 14);
            this.checkBoxReUse.TabIndex = 4;
            this.checkBoxReUse.UseVisualStyleBackColor = true;
            // 
            // labelReusable
            // 
            this.labelReusable.AutoSize = true;
            this.labelReusable.Location = new System.Drawing.Point(47, 109);
            this.labelReusable.Name = "labelReusable";
            this.labelReusable.Size = new System.Drawing.Size(169, 26);
            this.labelReusable.TabIndex = 6;
            this.labelReusable.Text = "Would you like the user to \r\nre-use the TAP during the lifetime?";
            // 
            // numericUpDownMinutes
            // 
            this.numericUpDownMinutes.Location = new System.Drawing.Point(238, 83);
            this.numericUpDownMinutes.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.numericUpDownMinutes.Name = "numericUpDownMinutes";
            this.numericUpDownMinutes.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMinutes.TabIndex = 2;
            // 
            // tapTimePicker
            // 
            this.tapTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tapTimePicker.Location = new System.Drawing.Point(376, 56);
            this.tapTimePicker.Name = "tapTimePicker";
            this.tapTimePicker.ShowUpDown = true;
            this.tapTimePicker.Size = new System.Drawing.Size(101, 20);
            this.tapTimePicker.TabIndex = 1;
            // 
            // TAPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 179);
            this.Controls.Add(this.tapTimePicker);
            this.Controls.Add(this.numericUpDownMinutes);
            this.Controls.Add(this.labelReusable);
            this.Controls.Add(this.checkBoxReUse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.labellabelStartDateTime);
            this.Controls.Add(this.tapDatePicker);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TAPForm";
            this.Text = "                                                                                 " +
    "                                                                                " +
    "                             ";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker tapDatePicker;
        private System.Windows.Forms.Label labellabelStartDateTime;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxReUse;
        private System.Windows.Forms.Label labelReusable;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
        private System.Windows.Forms.DateTimePicker tapTimePicker;
    }
}