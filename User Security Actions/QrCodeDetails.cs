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
using Svg;
using Svg.Transforms;

namespace User_Security_Actions
{
    public partial class QrCodeDetails : UserControl
    {
        QrCodePinAuthenticationMethodConfiguration qrPolicyPass;

        public QrCodeDetails()
        {
            InitializeComponent();
        }
        public QrCodeDetails(GraphCalls.QrCode qrCode, bool isStandard,
            QrCodePinAuthenticationMethodConfiguration qrPolicy)
        {
            InitializeComponent();

            this.qrPolicyPass = qrPolicy;

            if (null != qrCode)
            {
                if (null != qrCode.image)
                {
                    System.Drawing.Image image = ConvetSvgToImage(qrCode.image.BinaryValue);
                    pictureBoxQrCode.Image = image;
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
                    this.labelExpDateTimeDisplay.Text =
                    string.Format("{0:MMM d, yyyy at hh:mm}", qrCode.ExpireDateTime.Value.ToLocalTime().ToString());
                if (!isStandard)
                    buttonChangeExpDate.Visible = false;
            }
        }

        private System.Drawing.Image ConvetSvgToImage(byte[] source)
        {
            // Convert the SVG string to a stream
            string svgContent = Encoding.UTF8.GetString(source);

            // Load the SVG document
            SvgDocument svgDoc;
            using (var reader = new StringReader(svgContent))
            {
                svgDoc = SvgDocument.FromSvg<SvgDocument>(svgContent);
            }

            // Optional: Set custom size if needed
            svgDoc.Width = 200;
            svgDoc.Height = 200;

            // Render to System.Drawing.Bitmap
            System.Drawing.Image image = svgDoc.Draw();

            // Return as Image
            return image;
        }
        private async void buttonDelCode_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;

            if ("panelStdCode" == this.Parent.Name)
            {
                //delete the standard code and redraw the window with create options
                try
                {
                    
                    await GraphCalls.DeleteStandardQrCode();
                    Control parent = this.Parent; 
                    parent.Controls.Clear();
                    StdCreateQRCode pane = new StdCreateQRCode(true, qrPolicyPass);
                    pane.Dock = DockStyle.Fill;
                    parent.Controls.Add(pane);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                
                
            }
            else
            {
                //delete the temporary code and redraw the window with create options
                try
                {
                    
                    await GraphCalls.DeleteTemporaryQrCode();
                    Control parent = this.Parent;
                    parent.Controls.Clear();
                    TmpCreateQRCode pane = new TmpCreateQRCode(qrPolicyPass);
                    pane.Dock = DockStyle.Fill;
                    parent.Controls.Add(pane);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

            this.UseWaitCursor = false;
        }
    }
}
