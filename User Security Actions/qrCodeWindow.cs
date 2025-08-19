using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Graph.Beta;
namespace User_Security_Actions
{
    public partial class qrCodeWindow : Form
    {
        

        public qrCodeWindow()
        {
            InitializeComponent();
            
        }

        public qrCodeWindow(GraphCalls.QrCodePinAuthenticationMethod qrCodeMethod)
        {
            InitializeComponent();
            
            if(null == qrCodeMethod)
            {
                //do nothing
            }
            else
            {
                PinDetails pinDetails = new PinDetails(qrCodeMethod.pin);
            }
                QrCodeDetails qrCodeDetails = new QrCodeDetails(qrCodeMethod.standardQRCode);
            qrCodeDetails.Dock = DockStyle.Fill;

            this.stdQrCodePage.Controls.Add(qrCodeDetails);
           
            this.Validate();
        }
    }
}
