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
            //qrCodeMethod is not null
            else
            {
                //PIN has to be populated at minimum if qrCode is not null
                this.panelPin.Controls.Clear();
                PinDetails pinDetails = new PinDetails(qrCodeMethod.Pin);
                pinDetails.Dock = DockStyle.Fill;
                this.panelPin.Controls.Add(pinDetails);

                //For the StdPane, check if the standard code is null
                if (null == qrCodeMethod.StandardQRCode)
                {
                    //add the create method pane
                    StdCreateQRCode stdPane = new StdCreateQRCode(true);
                    stdPane.Dock = DockStyle.Fill;
                    this.panelStdCode.Controls.Add(stdPane);
                }
                else 
                {
                    //create the details pane
                    QrCodeDetails qrCodeDetails = new QrCodeDetails(qrCodeMethod.StandardQRCode, true);
                    qrCodeDetails.Dock = DockStyle.Fill;
                    //add it to the window
                    this.panelStdCode.Controls.Add(qrCodeDetails);
                }

                //For the TmpPane, check if the temporary code is null
                if(null == qrCodeMethod.TemporaryQRCode)
                {
                    //add the create method pane
                }
                else
                {
                    //create the details pane
                    QrCodeDetails qrCodeDetails = new QrCodeDetails(qrCodeMethod.TemporaryQRCode, false);
                    qrCodeDetails.Dock = DockStyle.Fill;
                    //add it to the window
                    this.panelTmpCode.Controls.Add(qrCodeDetails);
                }
                
            }
                
            
           
            this.Validate();
        }
    }
}
