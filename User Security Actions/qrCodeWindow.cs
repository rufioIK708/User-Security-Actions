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
using Microsoft.Graph.Beta.Models;
namespace User_Security_Actions
{
    public partial class qrCodeWindow : Form
    {
        QrCodePinAuthenticationMethodConfiguration qrPolicy;

        public qrCodeWindow()
        {
            InitializeComponent();
        }

        public qrCodeWindow(GraphCalls.QrCodePinAuthenticationMethod qrCodeMethod,
            QrCodePinAuthenticationMethodConfiguration qrPolicy)
        {
            InitializeComponent();

            this.qrPolicy = qrPolicy;

            if(null == qrCodeMethod || null == qrCodeMethod.Pin)
            {
                
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
                    this.panelStdCode.Controls.Clear();
                    StdCreateQRCode stdPane = new StdCreateQRCode(true, qrPolicy);
                    stdPane.Dock = DockStyle.Fill;
                    this.panelStdCode.Controls.Add(stdPane);
                }
                else 
                {
                    //create the details pane
                    this.panelStdCode.Controls.Clear();
                    QrCodeDetails qrCodeDetails = new QrCodeDetails(qrCodeMethod.StandardQRCode, true, qrPolicy);
                    qrCodeDetails.Dock = DockStyle.Fill;
                    qrCodeDetails.Name = "panelStdDetails";
                    //add it to the window
                    this.panelStdCode.Controls.Add(qrCodeDetails);
                }

                //For the TmpPane, check if the temporary code is null
                if(null == qrCodeMethod.TemporaryQRCode)
                {
                    //add the create method pane
                    this.panelTmpCode.Controls.Clear();
                    TmpCreateQRCode tmpPane = new TmpCreateQRCode(qrPolicy);
                    tmpPane.Dock = DockStyle.Fill;
                    
                    this.panelTmpCode.Controls.Add(tmpPane);
                }
                else
                {
                    //create the details pane
                    this.panelTmpCode.Controls.Clear();
                    QrCodeDetails qrCodeDetails = new QrCodeDetails(qrCodeMethod.TemporaryQRCode, false, qrPolicy);
                    qrCodeDetails.Dock = DockStyle.Fill;
                    qrCodeDetails.Name = "panelTmpDetails";
                    //add it to the window
                    this.panelTmpCode.Controls.Add(qrCodeDetails);
                }
                
            }

            this.Validate();
        }
    }
}
