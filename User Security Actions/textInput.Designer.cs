namespace User_Security_Actions
{
    partial class textInput
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
            this.input1 = new System.Windows.Forms.TextBox();
            this.accept = new System.Windows.Forms.Button();
            this.inputPurpose = new System.Windows.Forms.Label();
            this.labelMethodMessage = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radioButtonEmailMethod = new System.Windows.Forms.RadioButton();
            this.radioButtonPhoneMethod = new System.Windows.Forms.RadioButton();
            this.radioButtonOffice = new System.Windows.Forms.RadioButton();
            this.radioButtonAltMobile = new System.Windows.Forms.RadioButton();
            this.radioButtonMobile = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(10, 102);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(309, 20);
            this.input1.TabIndex = 0;
            // 
            // accept
            // 
            this.accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accept.Location = new System.Drawing.Point(3, 128);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(146, 23);
            this.accept.TabIndex = 1;
            this.accept.Text = "Accept";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // inputPurpose
            // 
            this.inputPurpose.AutoSize = true;
            this.inputPurpose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPurpose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputPurpose.Location = new System.Drawing.Point(0, 0);
            this.inputPurpose.Name = "inputPurpose";
            this.inputPurpose.Size = new System.Drawing.Size(92, 15);
            this.inputPurpose.TabIndex = 2;
            this.inputPurpose.Text = "inputPurpose";
            // 
            // labelMethodMessage
            // 
            this.labelMethodMessage.AutoSize = true;
            this.labelMethodMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMethodMessage.Location = new System.Drawing.Point(10, 86);
            this.labelMethodMessage.Name = "labelMethodMessage";
            this.labelMethodMessage.Size = new System.Drawing.Size(50, 16);
            this.labelMethodMessage.TabIndex = 4;
            this.labelMethodMessage.Text = "label1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(13, 19);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radioButtonEmailMethod);
            this.splitContainer1.Panel1.Controls.Add(this.radioButtonPhoneMethod);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.radioButtonOffice);
            this.splitContainer1.Panel2.Controls.Add(this.radioButtonAltMobile);
            this.splitContainer1.Panel2.Controls.Add(this.radioButtonMobile);
            this.splitContainer1.Size = new System.Drawing.Size(306, 64);
            this.splitContainer1.SplitterDistance = 31;
            this.splitContainer1.TabIndex = 5;
            // 
            // radioButtonEmailMethod
            // 
            this.radioButtonEmailMethod.AutoSize = true;
            this.radioButtonEmailMethod.Location = new System.Drawing.Point(191, 3);
            this.radioButtonEmailMethod.Name = "radioButtonEmailMethod";
            this.radioButtonEmailMethod.Size = new System.Drawing.Size(53, 17);
            this.radioButtonEmailMethod.TabIndex = 1;
            this.radioButtonEmailMethod.TabStop = true;
            this.radioButtonEmailMethod.Text = "E-mail";
            this.radioButtonEmailMethod.UseVisualStyleBackColor = true;
            this.radioButtonEmailMethod.CheckedChanged += new System.EventHandler(this.radioButtonEmailMethod_CheckedChanged);
            // 
            // radioButtonPhoneMethod
            // 
            this.radioButtonPhoneMethod.AutoSize = true;
            this.radioButtonPhoneMethod.Location = new System.Drawing.Point(51, 3);
            this.radioButtonPhoneMethod.Name = "radioButtonPhoneMethod";
            this.radioButtonPhoneMethod.Size = new System.Drawing.Size(56, 17);
            this.radioButtonPhoneMethod.TabIndex = 0;
            this.radioButtonPhoneMethod.TabStop = true;
            this.radioButtonPhoneMethod.Text = "Phone";
            this.radioButtonPhoneMethod.UseVisualStyleBackColor = true;
            this.radioButtonPhoneMethod.CheckedChanged += new System.EventHandler(this.radioButtonMobileMethod_CheckedChanged);
            // 
            // radioButtonOffice
            // 
            this.radioButtonOffice.AutoSize = true;
            this.radioButtonOffice.Location = new System.Drawing.Point(250, 5);
            this.radioButtonOffice.Name = "radioButtonOffice";
            this.radioButtonOffice.Size = new System.Drawing.Size(53, 17);
            this.radioButtonOffice.TabIndex = 2;
            this.radioButtonOffice.TabStop = true;
            this.radioButtonOffice.Text = "Office";
            this.radioButtonOffice.UseVisualStyleBackColor = true;
            // 
            // radioButtonAltMobile
            // 
            this.radioButtonAltMobile.AutoSize = true;
            this.radioButtonAltMobile.Location = new System.Drawing.Point(94, 5);
            this.radioButtonAltMobile.Name = "radioButtonAltMobile";
            this.radioButtonAltMobile.Size = new System.Drawing.Size(101, 17);
            this.radioButtonAltMobile.TabIndex = 1;
            this.radioButtonAltMobile.TabStop = true;
            this.radioButtonAltMobile.Text = "Alternate Mobile";
            this.radioButtonAltMobile.UseVisualStyleBackColor = true;
            // 
            // radioButtonMobile
            // 
            this.radioButtonMobile.AutoSize = true;
            this.radioButtonMobile.Location = new System.Drawing.Point(3, 5);
            this.radioButtonMobile.Name = "radioButtonMobile";
            this.radioButtonMobile.Size = new System.Drawing.Size(56, 17);
            this.radioButtonMobile.TabIndex = 0;
            this.radioButtonMobile.TabStop = true;
            this.radioButtonMobile.Text = "Mobile";
            this.radioButtonMobile.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(185, 128);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(147, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textInput
            // 
            this.AcceptButton = this.accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(331, 151);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.labelMethodMessage);
            this.Controls.Add(this.inputPurpose);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.input1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "textInput";
            this.Text = "textInput";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.Label inputPurpose;
        private System.Windows.Forms.Label labelMethodMessage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton radioButtonEmailMethod;
        private System.Windows.Forms.RadioButton radioButtonPhoneMethod;
        private System.Windows.Forms.RadioButton radioButtonOffice;
        private System.Windows.Forms.RadioButton radioButtonAltMobile;
        private System.Windows.Forms.RadioButton radioButtonMobile;
        private System.Windows.Forms.Button buttonCancel;
    }
}