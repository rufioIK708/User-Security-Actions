using Microsoft.Graph.Beta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Security_Actions
{
    public partial class QrCodeDetails : UserControl
    {
        public QrCodeDetails()
        {
            InitializeComponent();
        }
        public QrCodeDetails(GraphCalls.QrCode qrCode, bool isStandard)
        {
            InitializeComponent();

            if (null != qrCode)
            {
                if (null != qrCode.image)
                {
                    byte[] imageBytes = Convert.FromBase64String(qrCode.image.RawContent.ToString());

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBoxQrCode.Image = System.Drawing.Image.FromStream(ms);
                    }
                    
                }
                if (null != qrCode.id)
                    this.labelidDisplay.Text = qrCode.id;
                if (null != qrCode.CreatedDateTime)
                    this.labelCreatedDateTimeDisplay.Text =
                    string.Format("{0:MMM d, yyyy at hh:mm}", qrCode.CreatedDateTime.Value.ToLocalTime().ToString());
                if (null != qrCode.StartDateTime)
                    this.labelStartDateTimeDisplay.Text =
                    string.Format("{0:MMM d, yyyy at hh:mm}", qrCode.StartDateTime.Value.ToLocalTime().ToString());
                if (null != qrCode.LastUsedDateTime)
                    this.labelLastUsedDisplay.Text =
                    string.Format("{0:MMM d, yyyy at hh:mm}", qrCode.LastUsedDateTime.Value.ToLocalTime().ToString());
                if (null != qrCode.ExpireDateTime)
                    this.labelLastUsedDisplay.Text =
                    string.Format("{0:MMM d, yyyy at hh:mm}", qrCode.LastUsedDateTime.Value.ToLocalTime().ToString());
                if (!isStandard)
                    buttonChangeExpDate.Visible = false;
            }
        }

        private void buttonDelCode_Click(object sender, EventArgs e)
        {
            if ("stadardQrCode" == this.Parent.Name)
                MessageBox.Show("delete button pressed from standard tab");
            else
                MessageBox.Show("delete button pressed from temporary tab");
        }
    }
}
