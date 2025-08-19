namespace User_Security_Actions
{
    partial class qrCodeWindow
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.stdQrCodePage = new System.Windows.Forms.TabPage();
            this.panelStdCode = new System.Windows.Forms.Panel();
            this.panelTmpCode = new System.Windows.Forms.TabPage();
            this.panelPin = new System.Windows.Forms.TabPage();
            this.labelPinNoQrCode = new System.Windows.Forms.Label();
            this.qrCodeDetailsStd = new User_Security_Actions.QrCodeDetails();
            this.tabControl.SuspendLayout();
            this.stdQrCodePage.SuspendLayout();
            this.panelStdCode.SuspendLayout();
            this.panelPin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.stdQrCodePage);
            this.tabControl.Controls.Add(this.panelTmpCode);
            this.tabControl.Controls.Add(this.panelPin);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(623, 333);
            this.tabControl.TabIndex = 0;
            // 
            // stdQrCodePage
            // 
            this.stdQrCodePage.Controls.Add(this.panelStdCode);
            this.stdQrCodePage.Location = new System.Drawing.Point(4, 22);
            this.stdQrCodePage.Name = "stdQrCodePage";
            this.stdQrCodePage.Padding = new System.Windows.Forms.Padding(3);
            this.stdQrCodePage.Size = new System.Drawing.Size(615, 307);
            this.stdQrCodePage.TabIndex = 0;
            this.stdQrCodePage.Text = "Standard Qr Code";
            this.stdQrCodePage.UseVisualStyleBackColor = true;
            // 
            // panelStdCode
            // 
            this.panelStdCode.Controls.Add(this.qrCodeDetailsStd);
            this.panelStdCode.Location = new System.Drawing.Point(3, 6);
            this.panelStdCode.Name = "panelStdCode";
            this.panelStdCode.Size = new System.Drawing.Size(606, 295);
            this.panelStdCode.TabIndex = 0;
            this.panelStdCode.Visible = false;
            // 
            // panelTmpCode
            // 
            this.panelTmpCode.Location = new System.Drawing.Point(4, 22);
            this.panelTmpCode.Name = "panelTmpCode";
            this.panelTmpCode.Padding = new System.Windows.Forms.Padding(3);
            this.panelTmpCode.Size = new System.Drawing.Size(615, 307);
            this.panelTmpCode.TabIndex = 1;
            this.panelTmpCode.Text = "Temporary Qr Code";
            this.panelTmpCode.UseVisualStyleBackColor = true;
            // 
            // panelPin
            // 
            this.panelPin.Controls.Add(this.labelPinNoQrCode);
            this.panelPin.Location = new System.Drawing.Point(4, 22);
            this.panelPin.Name = "panelPin";
            this.panelPin.Padding = new System.Windows.Forms.Padding(3);
            this.panelPin.Size = new System.Drawing.Size(615, 307);
            this.panelPin.TabIndex = 2;
            this.panelPin.Text = "PIN Details";
            this.panelPin.UseVisualStyleBackColor = true;
            // 
            // labelPinNoQrCode
            // 
            this.labelPinNoQrCode.AutoSize = true;
            this.labelPinNoQrCode.Location = new System.Drawing.Point(167, 120);
            this.labelPinNoQrCode.Name = "labelPinNoQrCode";
            this.labelPinNoQrCode.Size = new System.Drawing.Size(278, 26);
            this.labelPinNoQrCode.TabIndex = 0;
            this.labelPinNoQrCode.Text = "There is no QrCodeAuthentication method configured yet.\r\nPlease create one in teh" +
    " Standard QR Code tab.";
            this.labelPinNoQrCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // qrCodeDetailsStd
            // 
            this.qrCodeDetailsStd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrCodeDetailsStd.Location = new System.Drawing.Point(0, 0);
            this.qrCodeDetailsStd.Name = "qrCodeDetailsStd";
            this.qrCodeDetailsStd.Size = new System.Drawing.Size(606, 295);
            this.qrCodeDetailsStd.TabIndex = 0;
            // 
            // qrCodeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 365);
            this.Controls.Add(this.tabControl);
            this.Name = "qrCodeWindow";
            this.Text = "qrCodeWindow";
            this.tabControl.ResumeLayout(false);
            this.stdQrCodePage.ResumeLayout(false);
            this.panelStdCode.ResumeLayout(false);
            this.panelPin.ResumeLayout(false);
            this.panelPin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage stdQrCodePage;
        private System.Windows.Forms.TabPage panelTmpCode;
        private System.Windows.Forms.TabPage panelPin;
        private System.Windows.Forms.Panel panelStdCode;
        private System.Windows.Forms.Label labelPinNoQrCode;
        private QrCodeDetails qrCodeDetailsStd;
    }
}