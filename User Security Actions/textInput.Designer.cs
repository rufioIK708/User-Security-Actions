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
            this.accept.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accept.Location = new System.Drawing.Point(0, 128);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(331, 23);
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
            // textInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 151);
            this.Controls.Add(this.inputPurpose);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.input1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "textInput";
            this.Text = "textInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.Label inputPurpose;
    }
}