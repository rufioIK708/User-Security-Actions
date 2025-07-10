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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddTapMethod = new System.Windows.Forms.Button();
            this.buttonRevokeSessions = new System.Windows.Forms.Button();
            this.labelSelectedUser = new System.Windows.Forms.Label();
            this.buttonRegisterFido2Passkey = new System.Windows.Forms.Button();
            this.buttonToggleAccount = new System.Windows.Forms.Button();
            this.getAUser = new System.Windows.Forms.Button();
            this.buttonAddMethod = new System.Windows.Forms.Button();
            this.getUserMFA = new System.Windows.Forms.Button();
            this.buttonResetMFA = new System.Windows.Forms.Button();
            this.buttonResetPassword = new System.Windows.Forms.Button();
            this.buttonRemoveMethod = new System.Windows.Forms.Button();
            this.updateImmutableId = new System.Windows.Forms.Button();
            this.buttonSignOut = new System.Windows.Forms.Button();
            this.buttonFunctions = new System.Windows.Forms.Button();
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
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.signin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.displayBox);
            this.splitContainer1.Size = new System.Drawing.Size(1079, 567);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.buttonAddTapMethod, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonRevokeSessions, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelSelectedUser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonRegisterFido2Passkey, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonToggleAccount, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.getAUser, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddMethod, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.getUserMFA, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetMFA, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetPassword, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonRemoveMethod, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.updateImmutableId, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSignOut, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonFunctions, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1079, 190);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonAddTapMethod
            // 
            this.buttonAddTapMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddTapMethod.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddTapMethod.Location = new System.Drawing.Point(541, 144);
            this.buttonAddTapMethod.Name = "buttonAddTapMethod";
            this.buttonAddTapMethod.Size = new System.Drawing.Size(263, 43);
            this.buttonAddTapMethod.TabIndex = 10;
            this.buttonAddTapMethod.Text = "Add TAP Method";
            this.buttonAddTapMethod.UseVisualStyleBackColor = true;
            this.buttonAddTapMethod.Visible = false;
            this.buttonAddTapMethod.Click += new System.EventHandler(this.buttonAddTapMethod_Click);
            // 
            // buttonRevokeSessions
            // 
            this.buttonRevokeSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRevokeSessions.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRevokeSessions.Location = new System.Drawing.Point(272, 144);
            this.buttonRevokeSessions.Name = "buttonRevokeSessions";
            this.buttonRevokeSessions.Size = new System.Drawing.Size(263, 43);
            this.buttonRevokeSessions.TabIndex = 9;
            this.buttonRevokeSessions.Text = "Revoke Sign-in Sessions";
            this.buttonRevokeSessions.UseVisualStyleBackColor = true;
            this.buttonRevokeSessions.Visible = false;
            this.buttonRevokeSessions.Click += new System.EventHandler(this.buttonRevokeSessions_Click);
            // 
            // labelSelectedUser
            // 
            this.labelSelectedUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelectedUser.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelSelectedUser, 2);
            this.labelSelectedUser.Location = new System.Drawing.Point(3, 17);
            this.labelSelectedUser.Name = "labelSelectedUser";
            this.labelSelectedUser.Size = new System.Drawing.Size(143, 13);
            this.labelSelectedUser.TabIndex = 10;
            this.labelSelectedUser.Text = "labelSignedInUser";
            // 
            // buttonRegisterFido2Passkey
            // 
            this.buttonRegisterFido2Passkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRegisterFido2Passkey.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegisterFido2Passkey.Location = new System.Drawing.Point(3, 144);
            this.buttonRegisterFido2Passkey.Name = "buttonRegisterFido2Passkey";
            this.buttonRegisterFido2Passkey.Size = new System.Drawing.Size(263, 43);
            this.buttonRegisterFido2Passkey.TabIndex = 8;
            this.buttonRegisterFido2Passkey.Text = "Register Fido2 Passkey";
            this.buttonRegisterFido2Passkey.UseVisualStyleBackColor = true;
            this.buttonRegisterFido2Passkey.Visible = false;
            this.buttonRegisterFido2Passkey.Click += new System.EventHandler(this.buttonRegisterFido2Passkey_Click);
            // 
            // buttonToggleAccount
            // 
            this.buttonToggleAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonToggleAccount.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToggleAccount.Location = new System.Drawing.Point(3, 97);
            this.buttonToggleAccount.Name = "buttonToggleAccount";
            this.buttonToggleAccount.Size = new System.Drawing.Size(263, 41);
            this.buttonToggleAccount.TabIndex = 4;
            this.buttonToggleAccount.Text = "Enable/Disable account";
            this.buttonToggleAccount.UseVisualStyleBackColor = true;
            this.buttonToggleAccount.Visible = false;
            this.buttonToggleAccount.Click += new System.EventHandler(this.buttonToggleAccount_Click);
            // 
            // getAUser
            // 
            this.getAUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getAUser.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getAUser.Location = new System.Drawing.Point(3, 50);
            this.getAUser.Name = "getAUser";
            this.getAUser.Size = new System.Drawing.Size(263, 41);
            this.getAUser.TabIndex = 0;
            this.getAUser.Text = "Get a User";
            this.getAUser.UseVisualStyleBackColor = true;
            this.getAUser.Click += new System.EventHandler(this.getAUser_Click);
            // 
            // buttonAddMethod
            // 
            this.buttonAddMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddMethod.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddMethod.Location = new System.Drawing.Point(272, 97);
            this.buttonAddMethod.Name = "buttonAddMethod";
            this.buttonAddMethod.Size = new System.Drawing.Size(263, 41);
            this.buttonAddMethod.TabIndex = 5;
            this.buttonAddMethod.Text = "Add a Security Method";
            this.buttonAddMethod.UseVisualStyleBackColor = true;
            this.buttonAddMethod.Visible = false;
            this.buttonAddMethod.Click += new System.EventHandler(this.buttonAddMethod_Click);
            // 
            // getUserMFA
            // 
            this.getUserMFA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getUserMFA.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getUserMFA.Location = new System.Drawing.Point(272, 50);
            this.getUserMFA.Name = "getUserMFA";
            this.getUserMFA.Size = new System.Drawing.Size(263, 41);
            this.getUserMFA.TabIndex = 1;
            this.getUserMFA.Text = "Get User Security Methods";
            this.getUserMFA.UseVisualStyleBackColor = true;
            this.getUserMFA.Visible = false;
            this.getUserMFA.Click += new System.EventHandler(this.getUserMFA_Click);
            // 
            // buttonResetMFA
            // 
            this.buttonResetMFA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetMFA.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetMFA.Location = new System.Drawing.Point(541, 97);
            this.buttonResetMFA.Name = "buttonResetMFA";
            this.buttonResetMFA.Size = new System.Drawing.Size(263, 41);
            this.buttonResetMFA.TabIndex = 6;
            this.buttonResetMFA.Text = "Reset/Re-register MFA";
            this.buttonResetMFA.UseVisualStyleBackColor = true;
            this.buttonResetMFA.Visible = false;
            this.buttonResetMFA.Click += new System.EventHandler(this.buttonResetMFA_Click);
            // 
            // buttonResetPassword
            // 
            this.buttonResetPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetPassword.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetPassword.Location = new System.Drawing.Point(541, 50);
            this.buttonResetPassword.Name = "buttonResetPassword";
            this.buttonResetPassword.Size = new System.Drawing.Size(263, 41);
            this.buttonResetPassword.TabIndex = 2;
            this.buttonResetPassword.Text = "Reset Password";
            this.buttonResetPassword.UseVisualStyleBackColor = true;
            this.buttonResetPassword.Visible = false;
            this.buttonResetPassword.Click += new System.EventHandler(this.buttonResetPassword_Click);
            // 
            // buttonRemoveMethod
            // 
            this.buttonRemoveMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveMethod.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveMethod.Location = new System.Drawing.Point(810, 97);
            this.buttonRemoveMethod.Name = "buttonRemoveMethod";
            this.buttonRemoveMethod.Size = new System.Drawing.Size(266, 41);
            this.buttonRemoveMethod.TabIndex = 7;
            this.buttonRemoveMethod.Text = "Remove a Security Method";
            this.buttonRemoveMethod.UseVisualStyleBackColor = true;
            this.buttonRemoveMethod.Visible = false;
            this.buttonRemoveMethod.Click += new System.EventHandler(this.buttonRemoveMethod_Click);
            // 
            // updateImmutableId
            // 
            this.updateImmutableId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateImmutableId.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateImmutableId.Location = new System.Drawing.Point(810, 50);
            this.updateImmutableId.Name = "updateImmutableId";
            this.updateImmutableId.Size = new System.Drawing.Size(266, 41);
            this.updateImmutableId.TabIndex = 3;
            this.updateImmutableId.Text = "Update ImmutableID";
            this.updateImmutableId.UseVisualStyleBackColor = true;
            this.updateImmutableId.Visible = false;
            this.updateImmutableId.Click += new System.EventHandler(this.updateImmutableId_Click);
            // 
            // buttonSignOut
            // 
            this.buttonSignOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSignOut.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSignOut.Location = new System.Drawing.Point(810, 3);
            this.buttonSignOut.Name = "buttonSignOut";
            this.buttonSignOut.Size = new System.Drawing.Size(266, 41);
            this.buttonSignOut.TabIndex = 15;
            this.buttonSignOut.Text = "Sign Out";
            this.buttonSignOut.UseVisualStyleBackColor = true;
            this.buttonSignOut.Click += new System.EventHandler(this.buttonSignOut_Click);
            // 
            // buttonFunctions
            // 
            this.buttonFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFunctions.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFunctions.Location = new System.Drawing.Point(541, 3);
            this.buttonFunctions.Name = "buttonFunctions";
            this.buttonFunctions.Size = new System.Drawing.Size(263, 41);
            this.buttonFunctions.TabIndex = 14;
            this.buttonFunctions.Text = "Test functions";
            this.buttonFunctions.UseVisualStyleBackColor = true;
            this.buttonFunctions.Click += new System.EventHandler(this.buttonFunctions_Click);
            // 
            // displayBox
            // 
            this.displayBox.BackColor = System.Drawing.Color.Black;
            this.displayBox.DetectUrls = false;
            this.displayBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayBox.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayBox.ForeColor = System.Drawing.Color.Lime;
            this.displayBox.Location = new System.Drawing.Point(0, 0);
            this.displayBox.Name = "displayBox";
            this.displayBox.ReadOnly = true;
            this.displayBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.displayBox.Size = new System.Drawing.Size(1079, 373);
            this.displayBox.TabIndex = 2;
            this.displayBox.Text = "Just for reference";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1082, 567);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signin);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1098, 606);
            this.Name = "Form1";
            this.Text = "User Security Actions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button signin;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button getAUser;
        private System.Windows.Forms.Button buttonRemoveMethod;
        private System.Windows.Forms.Button buttonResetMFA;
        private System.Windows.Forms.Button buttonAddMethod;
        private System.Windows.Forms.Button buttonToggleAccount;
        private System.Windows.Forms.Button buttonResetPassword;
        private System.Windows.Forms.Button updateImmutableId;
        private System.Windows.Forms.Button getUserMFA;
        private System.Windows.Forms.RichTextBox displayBox;
        private System.Windows.Forms.Button buttonRegisterFido2Passkey;
        private System.Windows.Forms.Button buttonSignOut;
        private System.Windows.Forms.Label labelSelectedUser;
        private System.Windows.Forms.Button buttonRevokeSessions;
        private System.Windows.Forms.Button buttonAddTapMethod;
        private System.Windows.Forms.Button buttonFunctions;
    }
}

