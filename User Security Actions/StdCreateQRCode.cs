using Microsoft.Graph.Beta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Security_Actions
{
    public partial class StdCreateQRCode : UserControl
    {
        QrCodePinAuthenticationMethodConfiguration qrPolicyPass;
        public StdCreateQRCode()
        {
            InitializeComponent();

            qrDatePicker.Value = DateTime.Now.AddDays(365);
        }

        public StdCreateQRCode(Boolean HasPin, QrCodePinAuthenticationMethodConfiguration qrPolicy)
        {
            InitializeComponent();

            this.qrPolicyPass = qrPolicy;

            qrDatePicker.Value = DateTime.Now.AddDays((double)qrPolicy.StandardQRCodeLifetimeInDays);
            qrDatePicker.MaxDate = DateTime.Now.AddDays(395);
            //qrTimePicker.MaxDate = DateTime.Now.AddDays(395);
            qrDatePicker.MinDate = DateTime.Now.AddDays(1);
            qrActLaterDatePicker.Value = DateTime.Now;
            qrActLaterTimePicker.Value = DateTime.Now;
            

            if (HasPin)
            {
                tableLayoutPanel1.Controls.Remove(labelEnterPin);
                tableLayoutPanel1.Controls.Remove(maskedTextBoxPin);
                labelEnterPin.Dispose();
                maskedTextBoxPin.Dispose();
                System.Windows.Forms.Label pinMessage = new();
                pinMessage.Text = "This user has a PIN configured. You can RESET it in the PIN Details tab if needed.";
                pinMessage.Dock = DockStyle.Fill;
                
                tableLayoutPanel1.Controls.Add(pinMessage,1, 4);
            }

        }
        private void checkBoxActLater_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxActLater.Checked)
            {
                labelStdActLater.Visible = true;
                qrActLaterDatePicker.Visible = true;
                qrActLaterTimePicker.Visible = true;
            }
            else
            {
                labelStdActLater.Visible = false;
                qrActLaterDatePicker.Visible = false;
                qrActLaterTimePicker.Visible = false;
            }

        }

        private async void buttonCreateQrCode_Click(object sender, EventArgs e)
        {
           
            GraphCalls.QrCode newCode = new();

            //gather values set by the user

            //set the expiration date
            newCode.ExpireDateTime = qrDatePicker.Value.Add(qrTimePicker.Value.TimeOfDay);

            //check if the user wants to specify the start time
            if(checkBoxActLater.Checked)
            {
                //yes, get the start time from the pickers
                newCode.StartDateTime = qrActLaterDatePicker.Value.Add(qrActLaterTimePicker.Value.TimeOfDay);
            }
            else
            {
                //no, start now
                newCode.StartDateTime = DateTimeOffset.Now;
            }


            if (tableLayoutPanel1.Controls.Contains(maskedTextBoxPin))
            {
                //pin box is visible so we need to get the pin and send a new qrcodepinauthenticationmethod
                GraphCalls.QrCodePinAuthenticationMethod newMethod = new();
                newMethod.StandardQRCode = newCode;

                GraphCalls.QrPin newPin = new();
                newPin.Code = maskedTextBoxPin.Text;
                newMethod.Pin = newPin;

                try
                {
                    GraphCalls.QrCodePinAuthenticationMethod returnedMethod = await GraphCalls.CreateQrCodeMethod(newMethod);
                    
                    QrCodePinAuthenticationMethodConfiguration qrPolicy = (QrCodePinAuthenticationMethodConfiguration)
                        await Program.graphClient.Policies.AuthenticationMethodsPolicy
                        .AuthenticationMethodConfigurations["QrCodePin"].GetAsync();

                    this.ParentForm.Dispose();

                    new qrCodeWindow(returnedMethod, qrPolicy).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //pin box is not visible, so we just create a new qrcode
                try
                {
                    GraphCalls.QrCode returnedMethod = await GraphCalls.CreateStandardQrCode(newCode);

                    Control parent = this.Parent;
                    parent.Controls.Clear();
                    QrCodeDetails pane = new QrCodeDetails(returnedMethod, true, qrPolicyPass);
                    pane.Dock = DockStyle.Fill;
                    parent.Controls.Add(pane);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            
        }
    }
}
