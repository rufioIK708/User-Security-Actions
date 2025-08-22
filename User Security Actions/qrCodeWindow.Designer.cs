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
            this.panelStdCode = new System.Windows.Forms.TabPage();
            this.panelTmpCode = new System.Windows.Forms.TabPage();
            this.labelTmpNoStdMsg = new System.Windows.Forms.Label();
            this.panelPin = new System.Windows.Forms.TabPage();
            this.labelPinNoQrCode = new System.Windows.Forms.Label();
            this.stdCreateQRCode1 = new User_Security_Actions.StdCreateQRCode();
            this.tabControl.SuspendLayout();
            this.panelStdCode.SuspendLayout();
            this.panelTmpCode.SuspendLayout();
            this.panelPin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.panelStdCode);
            this.tabControl.Controls.Add(this.panelTmpCode);
            this.tabControl.Controls.Add(this.panelPin);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(623, 333);
            this.tabControl.TabIndex = 0;
            // 
            // panelStdCode
            // 
            this.panelStdCode.Controls.Add(this.stdCreateQRCode1);
            this.panelStdCode.Location = new System.Drawing.Point(4, 22);
            this.panelStdCode.Name = "panelStdCode";
            this.panelStdCode.Padding = new System.Windows.Forms.Padding(3);
            this.panelStdCode.Size = new System.Drawing.Size(615, 307);
            this.panelStdCode.TabIndex = 0;
            this.panelStdCode.Text = "Standard Qr Code";
            // 
            // panelTmpCode
            // 
            this.panelTmpCode.Controls.Add(this.labelTmpNoStdMsg);
            this.panelTmpCode.Location = new System.Drawing.Point(4, 22);
            this.panelTmpCode.Name = "panelTmpCode";
            this.panelTmpCode.Padding = new System.Windows.Forms.Padding(3);
            this.panelTmpCode.Size = new System.Drawing.Size(615, 307);
            this.panelTmpCode.TabIndex = 1;
            this.panelTmpCode.Text = "Temporary Qr Code";
            this.panelTmpCode.UseVisualStyleBackColor = true;
            // 
            // labelTmpNoStdMsg
            // 
            this.labelTmpNoStdMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTmpNoStdMsg.AutoSize = true;
            this.labelTmpNoStdMsg.Location = new System.Drawing.Point(182, 133);
            this.labelTmpNoStdMsg.Name = "labelTmpNoStdMsg";
            this.labelTmpNoStdMsg.Size = new System.Drawing.Size(278, 26);
            this.labelTmpNoStdMsg.TabIndex = 0;
            this.labelTmpNoStdMsg.Text = "There is no QrCodeAuthentication method configured yet.\r\nPlease create one in the" +
    " Standard QR Code tab.\r\n";
            this.labelTmpNoStdMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelPinNoQrCode.Text = "There is no QrCodeAuthentication method configured yet.\r\nPlease create one in the" +
    " Standard QR Code tab.";
            this.labelPinNoQrCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stdCreateQRCode1
            // 
            this.stdCreateQRCode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stdCreateQRCode1.Location = new System.Drawing.Point(3, 3);
            this.stdCreateQRCode1.Name = "stdCreateQRCode1";
            this.stdCreateQRCode1.Size = new System.Drawing.Size(609, 301);
            this.stdCreateQRCode1.TabIndex = 0;
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
            this.panelStdCode.ResumeLayout(false);
            this.panelTmpCode.ResumeLayout(false);
            this.panelTmpCode.PerformLayout();
            this.panelPin.ResumeLayout(false);
            this.panelPin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage panelTmpCode;
        private System.Windows.Forms.TabPage panelPin;
        private System.Windows.Forms.Label labelPinNoQrCode;
        private System.Windows.Forms.Label labelTmpNoStdMsg;
        private StdCreateQRCode stdCreateQRCode1;
        private System.Windows.Forms.TabPage panelStdCode;
    }
}