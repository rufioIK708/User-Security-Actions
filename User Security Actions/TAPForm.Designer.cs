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
            this.dateStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labellabelStartDateTime = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxMinutes = new System.Windows.Forms.TextBox();
            this.checkBoxReUse = new System.Windows.Forms.CheckBox();
            this.labelReusable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateStartTimePicker
            // 
            this.dateStartTimePicker.Location = new System.Drawing.Point(267, 57);
            this.dateStartTimePicker.Name = "dateStartTimePicker";
            this.dateStartTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateStartTimePicker.TabIndex = 0;
            this.dateStartTimePicker.Value = new System.DateTime(2025, 4, 10, 14, 31, 10, 0);
            // 
            // labellabelStartDateTime
            // 
            this.labellabelStartDateTime.AutoSize = true;
            this.labellabelStartDateTime.Location = new System.Drawing.Point(61, 63);
            this.labellabelStartDateTime.Name = "labellabelStartDateTime";
            this.labellabelStartDateTime.Size = new System.Drawing.Size(190, 13);
            this.labellabelStartDateTime.TabIndex = 1;
            this.labellabelStartDateTime.Text = "Please select the start time for the TAP";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(83, 85);
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
            this.button1.TabIndex = 3;
            this.button1.Text = "Add TAP";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBoxMinutes
            // 
            this.textBoxMinutes.Location = new System.Drawing.Point(267, 82);
            this.textBoxMinutes.Name = "textBoxMinutes";
            this.textBoxMinutes.Size = new System.Drawing.Size(100, 20);
            this.textBoxMinutes.TabIndex = 4;
            // 
            // checkBoxReUse
            // 
            this.checkBoxReUse.AutoSize = true;
            this.checkBoxReUse.Location = new System.Drawing.Point(267, 109);
            this.checkBoxReUse.Name = "checkBoxReUse";
            this.checkBoxReUse.Size = new System.Drawing.Size(15, 14);
            this.checkBoxReUse.TabIndex = 5;
            this.checkBoxReUse.UseVisualStyleBackColor = true;
            // 
            // labelReusable
            // 
            this.labelReusable.AutoSize = true;
            this.labelReusable.Location = new System.Drawing.Point(82, 109);
            this.labelReusable.Name = "labelReusable";
            this.labelReusable.Size = new System.Drawing.Size(169, 26);
            this.labelReusable.TabIndex = 6;
            this.labelReusable.Text = "Would you like the user to \r\nre-use the TAP during the lifetime?";
            // 
            // TAPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 179);
            this.Controls.Add(this.labelReusable);
            this.Controls.Add(this.checkBoxReUse);
            this.Controls.Add(this.textBoxMinutes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.labellabelStartDateTime);
            this.Controls.Add(this.dateStartTimePicker);
            this.Name = "TAPForm";
            this.Text = "Add TAP Method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateStartTimePicker;
        private System.Windows.Forms.Label labellabelStartDateTime;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxMinutes;
        private System.Windows.Forms.CheckBox checkBoxReUse;
        private System.Windows.Forms.Label labelReusable;
    }
}