using System.Windows.Forms;
using System.Drawing;

namespace User_Security_Actions
{
    partial class QrCodeDetails : UserControl
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
            this.labelExpDateTimeDisplay = new System.Windows.Forms.Label();
            this.labelExpDateTime = new System.Windows.Forms.Label();
            this.labelLastUsedDisplay = new System.Windows.Forms.Label();
            this.labelLastUsed = new System.Windows.Forms.Label();
            this.labelStartDateTimeDisplay = new System.Windows.Forms.Label();
            this.labelStartDateTime = new System.Windows.Forms.Label();
            this.labelCreatedDateTimeDisplay = new System.Windows.Forms.Label();
            this.labelCreatedDateTime = new System.Windows.Forms.Label();
            this.labelidDisplay = new System.Windows.Forms.Label();
            this.labelid = new System.Windows.Forms.Label();
            this.labelDetailsTitle = new System.Windows.Forms.Label();
            this.pictureBoxQrCode = new System.Windows.Forms.PictureBox();
            this.buttonChangeExpDate = new System.Windows.Forms.Button();
            this.buttonDelCode = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.labelExpDateTimeDisplay, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelExpDateTime, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelLastUsedDisplay, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelLastUsed, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelStartDateTimeDisplay, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelStartDateTime, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelCreatedDateTimeDisplay, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCreatedDateTime, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelidDisplay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDetailsTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxQrCode, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonChangeExpDate, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelCode, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 222);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelExpDateTimeDisplay
            // 
            this.labelExpDateTimeDisplay.AutoSize = true;
            this.labelExpDateTimeDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExpDateTimeDisplay.Location = new System.Drawing.Point(117, 155);
            this.labelExpDateTimeDisplay.Name = "labelExpDateTimeDisplay";
            this.labelExpDateTimeDisplay.Size = new System.Drawing.Size(177, 31);
            this.labelExpDateTimeDisplay.TabIndex = 17;
            this.labelExpDateTimeDisplay.Text = "Expiration Date/Time goes here";
            this.labelExpDateTimeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelExpDateTime
            // 
            this.labelExpDateTime.AutoSize = true;
            this.labelExpDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExpDateTime.Location = new System.Drawing.Point(3, 155);
            this.labelExpDateTime.Name = "labelExpDateTime";
            this.labelExpDateTime.Size = new System.Drawing.Size(108, 31);
            this.labelExpDateTime.TabIndex = 16;
            this.labelExpDateTime.Text = "Expiration Date/Time";
            this.labelExpDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLastUsedDisplay
            // 
            this.labelLastUsedDisplay.AutoSize = true;
            this.labelLastUsedDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLastUsedDisplay.Location = new System.Drawing.Point(117, 124);
            this.labelLastUsedDisplay.Name = "labelLastUsedDisplay";
            this.labelLastUsedDisplay.Size = new System.Drawing.Size(177, 31);
            this.labelLastUsedDisplay.TabIndex = 13;
            this.labelLastUsedDisplay.Text = "Last Used Date/Time goes here";
            this.labelLastUsedDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLastUsed
            // 
            this.labelLastUsed.AutoSize = true;
            this.labelLastUsed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLastUsed.Location = new System.Drawing.Point(3, 124);
            this.labelLastUsed.Name = "labelLastUsed";
            this.labelLastUsed.Size = new System.Drawing.Size(108, 31);
            this.labelLastUsed.TabIndex = 12;
            this.labelLastUsed.Text = "Last Used Date/Time";
            this.labelLastUsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStartDateTimeDisplay
            // 
            this.labelStartDateTimeDisplay.AutoSize = true;
            this.labelStartDateTimeDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStartDateTimeDisplay.Location = new System.Drawing.Point(117, 93);
            this.labelStartDateTimeDisplay.Name = "labelStartDateTimeDisplay";
            this.labelStartDateTimeDisplay.Size = new System.Drawing.Size(177, 31);
            this.labelStartDateTimeDisplay.TabIndex = 10;
            this.labelStartDateTimeDisplay.Text = "Start Date/Time goes here";
            this.labelStartDateTimeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStartDateTime
            // 
            this.labelStartDateTime.AutoSize = true;
            this.labelStartDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStartDateTime.Location = new System.Drawing.Point(3, 93);
            this.labelStartDateTime.Name = "labelStartDateTime";
            this.labelStartDateTime.Size = new System.Drawing.Size(108, 31);
            this.labelStartDateTime.TabIndex = 9;
            this.labelStartDateTime.Text = "Started Date/Time";
            this.labelStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCreatedDateTimeDisplay
            // 
            this.labelCreatedDateTimeDisplay.AutoSize = true;
            this.labelCreatedDateTimeDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCreatedDateTimeDisplay.Location = new System.Drawing.Point(117, 62);
            this.labelCreatedDateTimeDisplay.Name = "labelCreatedDateTimeDisplay";
            this.labelCreatedDateTimeDisplay.Size = new System.Drawing.Size(177, 31);
            this.labelCreatedDateTimeDisplay.TabIndex = 7;
            this.labelCreatedDateTimeDisplay.Text = "Created Date/Time goes here";
            this.labelCreatedDateTimeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCreatedDateTime
            // 
            this.labelCreatedDateTime.AutoSize = true;
            this.labelCreatedDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCreatedDateTime.Location = new System.Drawing.Point(3, 62);
            this.labelCreatedDateTime.Name = "labelCreatedDateTime";
            this.labelCreatedDateTime.Size = new System.Drawing.Size(108, 31);
            this.labelCreatedDateTime.TabIndex = 6;
            this.labelCreatedDateTime.Text = "Created Date/Time :";
            this.labelCreatedDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelidDisplay
            // 
            this.labelidDisplay.AutoSize = true;
            this.labelidDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelidDisplay.Location = new System.Drawing.Point(117, 31);
            this.labelidDisplay.Name = "labelidDisplay";
            this.labelidDisplay.Size = new System.Drawing.Size(177, 31);
            this.labelidDisplay.TabIndex = 4;
            this.labelidDisplay.Text = "ID goes here";
            this.labelidDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelid
            // 
            this.labelid.AutoSize = true;
            this.labelid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelid.Location = new System.Drawing.Point(3, 31);
            this.labelid.Name = "labelid";
            this.labelid.Size = new System.Drawing.Size(108, 31);
            this.labelid.TabIndex = 3;
            this.labelid.Text = "ID :";
            this.labelid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDetailsTitle
            // 
            this.labelDetailsTitle.AutoSize = true;
            this.labelDetailsTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDetailsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetailsTitle.Location = new System.Drawing.Point(117, 0);
            this.labelDetailsTitle.Name = "labelDetailsTitle";
            this.labelDetailsTitle.Size = new System.Drawing.Size(177, 31);
            this.labelDetailsTitle.TabIndex = 0;
            this.labelDetailsTitle.Text = "Details Title";
            this.labelDetailsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxQrCode
            // 
            this.pictureBoxQrCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxQrCode.Location = new System.Drawing.Point(300, 3);
            this.pictureBoxQrCode.Name = "pictureBoxQrCode";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBoxQrCode, 5);
            this.pictureBoxQrCode.Size = new System.Drawing.Size(155, 149);
            this.pictureBoxQrCode.TabIndex = 14;
            this.pictureBoxQrCode.TabStop = false;
            // 
            // buttonChangeExpDate
            // 
            this.buttonChangeExpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonChangeExpDate.Location = new System.Drawing.Point(300, 158);
            this.buttonChangeExpDate.Name = "buttonChangeExpDate";
            this.buttonChangeExpDate.Size = new System.Drawing.Size(155, 25);
            this.buttonChangeExpDate.TabIndex = 18;
            this.buttonChangeExpDate.Text = "Change Expiration Date";
            this.buttonChangeExpDate.UseVisualStyleBackColor = true;
            // 
            // buttonDelCode
            // 
            this.buttonDelCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelCode.Location = new System.Drawing.Point(117, 189);
            this.buttonDelCode.Name = "buttonDelCode";
            this.buttonDelCode.Size = new System.Drawing.Size(177, 30);
            this.buttonDelCode.TabIndex = 19;
            this.buttonDelCode.Text = "Delete Code";
            this.buttonDelCode.UseVisualStyleBackColor = true;
            this.buttonDelCode.Click += new System.EventHandler(this.buttonDelCode_Click);
            // 
            // QrCodeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QrCodeDetails";
            this.Size = new System.Drawing.Size(458, 222);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQrCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelDetailsTitle;
        private Label labelLastUsedDisplay;
        private Label labelLastUsed;
        private Label labelStartDateTimeDisplay;
        private Label labelStartDateTime;
        private Label labelCreatedDateTimeDisplay;
        private Label labelCreatedDateTime;
        private Label labelidDisplay;
        private Label labelid;
        private PictureBox pictureBoxQrCode;
        private Label labelExpDateTimeDisplay;
        private Label labelExpDateTime;
        private Button buttonChangeExpDate;
        private Button buttonDelCode;
    }
}
