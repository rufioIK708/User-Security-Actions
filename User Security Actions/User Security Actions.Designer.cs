namespace User_Security_Actions
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.signin = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelSelectedUser = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonToggleAccount = new System.Windows.Forms.Button();
            this.getUserMFA = new System.Windows.Forms.Button();
            this.updateImmutableId = new System.Windows.Forms.Button();
            this.buttonResetPassword = new System.Windows.Forms.Button();
            this.getAUser = new System.Windows.Forms.Button();
            this.displayBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please sign-in.";
            // 
            // signin
            // 
            this.signin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signin.Location = new System.Drawing.Point(453, 145);
            this.signin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.signin.Name = "signin";
            this.signin.Size = new System.Drawing.Size(177, 39);
            this.signin.TabIndex = 1;
            this.signin.Text = "Sign-in";
            this.signin.UseVisualStyleBackColor = true;
            this.signin.Click += new System.EventHandler(this.signin_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelSelectedUser);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.displayBox);
            this.splitContainer1.Size = new System.Drawing.Size(1079, 567);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 2;
            // 
            // labelSelectedUser
            // 
            this.labelSelectedUser.AutoSize = true;
            this.labelSelectedUser.Location = new System.Drawing.Point(13, 34);
            this.labelSelectedUser.Name = "labelSelectedUser";
            this.labelSelectedUser.Size = new System.Drawing.Size(143, 13);
            this.labelSelectedUser.TabIndex = 1;
            this.labelSelectedUser.Text = "labelSignedInUser";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button8, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonToggleAccount, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.getUserMFA, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.updateImmutableId, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetPassword, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.getAUser, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 90);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1079, 159);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(810, 56);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(266, 47);
            this.button8.TabIndex = 7;
            this.button8.Text = "Get a User";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(541, 56);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(263, 47);
            this.button7.TabIndex = 6;
            this.button7.Text = "Get a User";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(272, 56);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(263, 47);
            this.button6.TabIndex = 5;
            this.button6.Text = "Get a User";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // buttonToggleAccount
            // 
            this.buttonToggleAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonToggleAccount.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToggleAccount.Location = new System.Drawing.Point(3, 56);
            this.buttonToggleAccount.Name = "buttonToggleAccount";
            this.buttonToggleAccount.Size = new System.Drawing.Size(263, 47);
            this.buttonToggleAccount.TabIndex = 4;
            this.buttonToggleAccount.Text = "Enable/Disable account";
            this.buttonToggleAccount.UseVisualStyleBackColor = true;
            this.buttonToggleAccount.Click += new System.EventHandler(this.buttonToggleAccount_Click);
            // 
            // getUserMFA
            // 
            this.getUserMFA.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getUserMFA.Location = new System.Drawing.Point(272, 3);
            this.getUserMFA.Name = "getUserMFA";
            this.getUserMFA.Size = new System.Drawing.Size(263, 47);
            this.getUserMFA.TabIndex = 1;
            this.getUserMFA.Text = "Get User Auth Methods";
            this.getUserMFA.UseVisualStyleBackColor = true;
            this.getUserMFA.Click += new System.EventHandler(this.getUserMFA_Click);
            // 
            // updateImmutableId
            // 
            this.updateImmutableId.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateImmutableId.Location = new System.Drawing.Point(541, 3);
            this.updateImmutableId.Name = "updateImmutableId";
            this.updateImmutableId.Size = new System.Drawing.Size(263, 47);
            this.updateImmutableId.TabIndex = 2;
            this.updateImmutableId.Text = "Update ImmutableID";
            this.updateImmutableId.UseVisualStyleBackColor = true;
            this.updateImmutableId.Click += new System.EventHandler(this.updateImmutableId_Click);
            // 
            // buttonResetPassword
            // 
            this.buttonResetPassword.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetPassword.Location = new System.Drawing.Point(810, 3);
            this.buttonResetPassword.Name = "buttonResetPassword";
            this.buttonResetPassword.Size = new System.Drawing.Size(263, 47);
            this.buttonResetPassword.TabIndex = 3;
            this.buttonResetPassword.Text = "Reset Password";
            this.buttonResetPassword.UseVisualStyleBackColor = true;
            this.buttonResetPassword.Click += new System.EventHandler(this.buttonResetPassword_Click);
            // 
            // getAUser
            // 
            this.getAUser.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getAUser.Location = new System.Drawing.Point(3, 3);
            this.getAUser.Name = "getAUser";
            this.getAUser.Size = new System.Drawing.Size(263, 47);
            this.getAUser.TabIndex = 0;
            this.getAUser.Text = "Get a User";
            this.getAUser.UseVisualStyleBackColor = true;
            this.getAUser.Click += new System.EventHandler(this.getAUser_Click);
            // 
            // displayBox
            // 
            this.displayBox.BackColor = System.Drawing.Color.Black;
            this.displayBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayBox.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayBox.ForeColor = System.Drawing.Color.Lime;
            this.displayBox.Location = new System.Drawing.Point(0, 0);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(1079, 314);
            this.displayBox.TabIndex = 2;
            this.displayBox.Text = "Just for reference";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 567);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signin);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "User Security Actions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button signin;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button getAUser;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonToggleAccount;
        private System.Windows.Forms.Button buttonResetPassword;
        private System.Windows.Forms.Button updateImmutableId;
        private System.Windows.Forms.Button getUserMFA;
        private System.Windows.Forms.Label labelSelectedUser;
        private System.Windows.Forms.RichTextBox displayBox;
    }
}

