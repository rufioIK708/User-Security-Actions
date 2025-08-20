namespace User_Security_Actions
{
    partial class StdCreateQRCode
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelStdSetExp = new System.Windows.Forms.Label();
            this.qrTimePicker = new System.Windows.Forms.DateTimePicker();
            this.checkBoxActLater = new System.Windows.Forms.CheckBox();
            this.qrDatePicker = new System.Windows.Forms.DateTimePicker();
            this.qrActLaterDatePicker = new System.Windows.Forms.DateTimePicker();
            this.qrActLaterTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelStdActLater = new System.Windows.Forms.Label();
            this.labelEnterPin = new System.Windows.Forms.Label();
            this.buttonCreateQrCode = new System.Windows.Forms.Button();
            this.textBoxPin = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelStdSetExp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.qrTimePicker, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxActLater, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.qrDatePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.qrActLaterDatePicker, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.qrActLaterTimePicker, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelStdActLater, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelEnterPin, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateQrCode, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPin, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 259);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Standard QR Code Creation Options";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStdSetExp
            // 
            this.labelStdSetExp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStdSetExp.AutoSize = true;
            this.labelStdSetExp.Location = new System.Drawing.Point(3, 43);
            this.labelStdSetExp.Name = "labelStdSetExp";
            this.labelStdSetExp.Size = new System.Drawing.Size(173, 43);
            this.labelStdSetExp.TabIndex = 1;
            this.labelStdSetExp.Text = "Set Expiration Date :";
            this.labelStdSetExp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrTimePicker
            // 
            this.qrTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qrTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.qrTimePicker.Location = new System.Drawing.Point(361, 58);
            this.qrTimePicker.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.qrTimePicker.Name = "qrTimePicker";
            this.qrTimePicker.ShowUpDown = true;
            this.qrTimePicker.Size = new System.Drawing.Size(143, 20);
            this.qrTimePicker.TabIndex = 4;
            // 
            // checkBoxActLater
            // 
            this.checkBoxActLater.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxActLater.AutoSize = true;
            this.checkBoxActLater.Location = new System.Drawing.Point(182, 89);
            this.checkBoxActLater.Name = "checkBoxActLater";
            this.checkBoxActLater.Size = new System.Drawing.Size(173, 37);
            this.checkBoxActLater.TabIndex = 5;
            this.checkBoxActLater.Text = "Activate Later";
            this.checkBoxActLater.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxActLater.UseVisualStyleBackColor = true;
            this.checkBoxActLater.CheckedChanged += new System.EventHandler(this.checkBoxActLater_CheckedChanged);
            // 
            // qrDatePicker
            // 
            this.qrDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qrDatePicker.CustomFormat = "MMMMdd, yyyy";
            this.qrDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.qrDatePicker.Location = new System.Drawing.Point(182, 58);
            this.qrDatePicker.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.qrDatePicker.MinDate = new System.DateTime(2025, 4, 20, 0, 0, 0, 0);
            this.qrDatePicker.Name = "qrDatePicker";
            this.qrDatePicker.Size = new System.Drawing.Size(173, 20);
            this.qrDatePicker.TabIndex = 3;
            this.qrDatePicker.Value = new System.DateTime(2025, 4, 20, 16, 20, 0, 0);
            // 
            // qrActLaterDatePicker
            // 
            this.qrActLaterDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qrActLaterDatePicker.CustomFormat = "MMMMdd, yyyy";
            this.qrActLaterDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.qrActLaterDatePicker.Location = new System.Drawing.Point(182, 144);
            this.qrActLaterDatePicker.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.qrActLaterDatePicker.MinDate = new System.DateTime(2025, 4, 20, 0, 0, 0, 0);
            this.qrActLaterDatePicker.Name = "qrActLaterDatePicker";
            this.qrActLaterDatePicker.Size = new System.Drawing.Size(173, 20);
            this.qrActLaterDatePicker.TabIndex = 6;
            this.qrActLaterDatePicker.Value = new System.DateTime(2025, 4, 20, 16, 20, 0, 0);
            this.qrActLaterDatePicker.Visible = false;
            // 
            // qrActLaterTimePicker
            // 
            this.qrActLaterTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qrActLaterTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.qrActLaterTimePicker.Location = new System.Drawing.Point(361, 144);
            this.qrActLaterTimePicker.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.qrActLaterTimePicker.Name = "qrActLaterTimePicker";
            this.qrActLaterTimePicker.ShowUpDown = true;
            this.qrActLaterTimePicker.Size = new System.Drawing.Size(143, 20);
            this.qrActLaterTimePicker.TabIndex = 7;
            this.qrActLaterTimePicker.Visible = false;
            // 
            // labelStdActLater
            // 
            this.labelStdActLater.AutoSize = true;
            this.labelStdActLater.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStdActLater.Location = new System.Drawing.Point(3, 129);
            this.labelStdActLater.Name = "labelStdActLater";
            this.labelStdActLater.Size = new System.Drawing.Size(173, 43);
            this.labelStdActLater.TabIndex = 8;
            this.labelStdActLater.Text = "Activates on :";
            this.labelStdActLater.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelStdActLater.Visible = false;
            // 
            // labelEnterPin
            // 
            this.labelEnterPin.AutoSize = true;
            this.labelEnterPin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEnterPin.Location = new System.Drawing.Point(3, 172);
            this.labelEnterPin.Name = "labelEnterPin";
            this.labelEnterPin.Size = new System.Drawing.Size(173, 43);
            this.labelEnterPin.TabIndex = 9;
            this.labelEnterPin.Text = "Enter PIN";
            this.labelEnterPin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCreateQrCode
            // 
            this.buttonCreateQrCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateQrCode.Location = new System.Drawing.Point(182, 218);
            this.buttonCreateQrCode.Name = "buttonCreateQrCode";
            this.buttonCreateQrCode.Size = new System.Drawing.Size(173, 38);
            this.buttonCreateQrCode.TabIndex = 10;
            this.buttonCreateQrCode.Text = "Create a Standard QR Code";
            this.buttonCreateQrCode.UseVisualStyleBackColor = true;
            // 
            // textBoxPin
            // 
            this.textBoxPin.Location = new System.Drawing.Point(182, 187);
            this.textBoxPin.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.textBoxPin.Name = "textBoxPin";
            this.textBoxPin.Size = new System.Drawing.Size(173, 20);
            this.textBoxPin.TabIndex = 11;
            // 
            // StdCreateQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StdCreateQRCode";
            this.Size = new System.Drawing.Size(507, 259);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStdSetExp;
        private System.Windows.Forms.DateTimePicker qrTimePicker;
        private System.Windows.Forms.DateTimePicker qrDatePicker;
        private System.Windows.Forms.CheckBox checkBoxActLater;
        private System.Windows.Forms.DateTimePicker qrActLaterDatePicker;
        private System.Windows.Forms.DateTimePicker qrActLaterTimePicker;
        private System.Windows.Forms.Label labelStdActLater;
        private System.Windows.Forms.Label labelEnterPin;
        private System.Windows.Forms.Button buttonCreateQrCode;
        private System.Windows.Forms.TextBox textBoxPin;
    }
}
