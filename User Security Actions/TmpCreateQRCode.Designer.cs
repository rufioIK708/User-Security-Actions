namespace User_Security_Actions
{
    partial class TmpCreateQRCode
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTmpActLater = new System.Windows.Forms.Label();
            this.labelTmpCodeTitle = new System.Windows.Forms.Label();
            this.labelLifeTime = new System.Windows.Forms.Label();
            this.checkBoxActLater = new System.Windows.Forms.CheckBox();
            this.numericUpDownLifetime = new System.Windows.Forms.NumericUpDown();
            this.qrActLaterDatePicker = new System.Windows.Forms.DateTimePicker();
            this.qrActLaterTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLifetime)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.labelTmpActLater, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTmpCodeTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelLifeTime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxActLater, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownLifetime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.qrActLaterDatePicker, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.qrActLaterTimePicker, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 233);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelTmpActLater
            // 
            this.labelTmpActLater.AutoSize = true;
            this.labelTmpActLater.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTmpActLater.Location = new System.Drawing.Point(3, 138);
            this.labelTmpActLater.Name = "labelTmpActLater";
            this.labelTmpActLater.Size = new System.Drawing.Size(145, 46);
            this.labelTmpActLater.TabIndex = 7;
            this.labelTmpActLater.Text = "Activates On :";
            this.labelTmpActLater.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTmpActLater.Visible = false;
            // 
            // labelTmpCodeTitle
            // 
            this.labelTmpCodeTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelTmpCodeTitle, 3);
            this.labelTmpCodeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTmpCodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTmpCodeTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTmpCodeTitle.Name = "labelTmpCodeTitle";
            this.labelTmpCodeTitle.Size = new System.Drawing.Size(450, 46);
            this.labelTmpCodeTitle.TabIndex = 0;
            this.labelTmpCodeTitle.Text = "Temporary QR Code Creation Options";
            this.labelTmpCodeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLifeTime
            // 
            this.labelLifeTime.AutoSize = true;
            this.labelLifeTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLifeTime.Location = new System.Drawing.Point(3, 46);
            this.labelLifeTime.Name = "labelLifeTime";
            this.labelLifeTime.Size = new System.Drawing.Size(145, 46);
            this.labelLifeTime.TabIndex = 1;
            this.labelLifeTime.Text = "QR Code Lifetime in hours";
            this.labelLifeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxActLater
            // 
            this.checkBoxActLater.AutoSize = true;
            this.checkBoxActLater.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxActLater.Location = new System.Drawing.Point(154, 95);
            this.checkBoxActLater.Name = "checkBoxActLater";
            this.checkBoxActLater.Size = new System.Drawing.Size(146, 40);
            this.checkBoxActLater.TabIndex = 2;
            this.checkBoxActLater.Text = "Activate Later";
            this.checkBoxActLater.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxActLater.UseVisualStyleBackColor = true;
            this.checkBoxActLater.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDownLifetime
            // 
            this.numericUpDownLifetime.Location = new System.Drawing.Point(201, 61);
            this.numericUpDownLifetime.Margin = new System.Windows.Forms.Padding(50, 15, 3, 3);
            this.numericUpDownLifetime.Name = "numericUpDownLifetime";
            this.numericUpDownLifetime.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownLifetime.TabIndex = 8;
            this.numericUpDownLifetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // qrActLaterDatePicker
            // 
            this.qrActLaterDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qrActLaterDatePicker.CustomFormat = "MMMMdd, yyyy";
            this.qrActLaterDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.qrActLaterDatePicker.Location = new System.Drawing.Point(154, 150);
            this.qrActLaterDatePicker.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.qrActLaterDatePicker.MinDate = new System.DateTime(2025, 4, 20, 0, 0, 0, 0);
            this.qrActLaterDatePicker.Name = "qrActLaterDatePicker";
            this.qrActLaterDatePicker.Size = new System.Drawing.Size(146, 20);
            this.qrActLaterDatePicker.TabIndex = 9;
            this.qrActLaterDatePicker.Value = new System.DateTime(2025, 4, 20, 16, 20, 0, 0);
            this.qrActLaterDatePicker.Visible = false;
            // 
            // qrActLaterTimePicker
            // 
            this.qrActLaterTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qrActLaterTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.qrActLaterTimePicker.Location = new System.Drawing.Point(306, 150);
            this.qrActLaterTimePicker.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.qrActLaterTimePicker.Name = "qrActLaterTimePicker";
            this.qrActLaterTimePicker.ShowUpDown = true;
            this.qrActLaterTimePicker.Size = new System.Drawing.Size(147, 20);
            this.qrActLaterTimePicker.TabIndex = 10;
            this.qrActLaterTimePicker.Visible = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(154, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 43);
            this.button1.TabIndex = 11;
            this.button1.Text = "Create Temporary QR Code";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TmpCreateQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TmpCreateQRCode";
            this.Size = new System.Drawing.Size(456, 233);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLifetime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTmpCodeTitle;
        private System.Windows.Forms.Label labelTmpActLater;
        private System.Windows.Forms.Label labelLifeTime;
        private System.Windows.Forms.CheckBox checkBoxActLater;
        private System.Windows.Forms.NumericUpDown numericUpDownLifetime;
        private System.Windows.Forms.DateTimePicker qrActLaterDatePicker;
        private System.Windows.Forms.DateTimePicker qrActLaterTimePicker;
        private System.Windows.Forms.Button button1;
    }
}
