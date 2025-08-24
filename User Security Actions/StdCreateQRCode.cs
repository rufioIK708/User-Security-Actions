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
        

        public StdCreateQRCode()
        {
            InitializeComponent();

            qrDatePicker.Value = DateTime.Now.AddDays(365);
        }

        public StdCreateQRCode(Boolean HasPin)
        {
            string tooltipPinLenth = "Minimum PIN length is : " + Program.qrPolicy.PinLength;

            InitializeComponent();

            QrCodePinAuthenticationMethodConfiguration qrPolicyPass = Program.qrPolicy;

            qrDatePicker.Value = DateTime.Now.AddDays((double)Program.qrPolicy.StandardQRCodeLifetimeInDays);
            qrDatePicker.MaxDate = DateTime.Now.AddDays(395);
            //qrTimePicker.MaxDate = DateTime.Now.AddDays(395);
            qrDatePicker.MinDate = DateTime.Now.AddDays(1);
            qrActLaterDatePicker.Value = DateTime.Now;
            qrActLaterTimePicker.Value = DateTime.Now;

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(textBoxPinEntry, tooltipPinLenth);

            if (HasPin)
            {
                tableLayoutPanel1.Controls.Remove(labelEnterPin);
                tableLayoutPanel1.Controls.Remove(textBoxPinEntry);
                labelEnterPin.Dispose();
                textBoxPinEntry.Dispose();
                System.Windows.Forms.Label pinMessage = new();
                pinMessage.Text = "This user has a PIN configured. You can RESET it in the PIN Details tab if needed.";
                pinMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                pinMessage.Dock = DockStyle.Fill;
                
                tableLayoutPanel1.Controls.Add(pinMessage,1, 4);
            }

            textBoxPinEntry.KeyPress += textBoxPinEntry_KeyPress;
            textBoxPinEntry.TextChanged += textBoxPinEntry_TextChanged;

        }

        private void textBoxPinEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
            }
        }

        private void textBoxPinEntry_TextChanged(object sender, EventArgs e)
        {
            // Trim input if it exceeds 20 characters
            if (textBoxPinEntry.Text.Length > 20)
            {
                textBoxPinEntry.Text = textBoxPinEntry.Text.Substring(0, 20);
                textBoxPinEntry.SelectionStart = textBoxPinEntry.Text.Length; // Keep cursor at end
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
            string messagePinLength = "The PIN must be at minimum " + Program.qrPolicy.PinLength + " digits.";
            
            bool contains = tableLayoutPanel1.Controls.Contains(textBoxPinEntry);
            int length = textBoxPinEntry.Text.Length;
            int pinLength = 8;

            if (null != Program.qrPolicy.PinLength)
                pinLength = (int)Program.qrPolicy.PinLength;

            //if the PinEntry is available but the entry is under PIN length, let the user know and quit.
            if (tableLayoutPanel1.Controls.Contains(textBoxPinEntry) &&
                textBoxPinEntry.Text.Length < Program.qrPolicy.PinLength)
            {
                MessageBox.Show(messagePinLength);

                return;
            }
            else
            {
                //we should be good to continue from here

                GraphCalls.QrCode newCode = new();

                //gather values set by the user

                //set the expiration date
                newCode.ExpireDateTime = qrDatePicker.Value.Add(qrTimePicker.Value.TimeOfDay);

                //check if the user wants to specify the start time
                if (checkBoxActLater.Checked)
                {
                    //yes, get the start time from the pickers
                    newCode.StartDateTime = qrActLaterDatePicker.Value.Add(qrActLaterTimePicker.Value.TimeOfDay);
                }
                else
                {
                    //no, start now
                    newCode.StartDateTime = DateTimeOffset.Now;
                }


                if (tableLayoutPanel1.Controls.Contains(textBoxPinEntry))
                {
                    //pin box is visible so we need to get the pin and send a new qrcodepinauthenticationmethod
                    GraphCalls.QrCodePinAuthenticationMethod newMethod = new();
                    newMethod.StandardQRCode = newCode;

                    GraphCalls.QrPin newPin = new();
                    newPin.Code = textBoxPinEntry.Text;
                    newMethod.Pin = newPin;

                    try
                    {
                        GraphCalls.QrCodePinAuthenticationMethod returnedMethod =
                            await GraphCalls.CreateQrCodeMethod(newMethod);

                        this.ParentForm.Dispose();

                        new qrCodeWindow(returnedMethod).ShowDialog();
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
                        QrCodeDetails pane = new QrCodeDetails(returnedMethod, true);
                        pane.Dock = DockStyle.Fill;
                        parent.Controls.Add(pane);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            
        }
    }
}
