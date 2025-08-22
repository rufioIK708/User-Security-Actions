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
    public partial class TmpCreateQRCode : UserControl
    {
        int tmpMinLifetime = 1;
        int tmpMaxLifetime = 12;
        int tmpDefaultLifetime = 3;
        QrCodePinAuthenticationMethodConfiguration qrPolicyPass;

        public TmpCreateQRCode(QrCodePinAuthenticationMethodConfiguration qrPolicy)
        {
            InitializeComponent();
            numericUpDownLifetime.Value = tmpDefaultLifetime;
            numericUpDownLifetime.Maximum = tmpMaxLifetime;
            numericUpDownLifetime.Minimum = tmpMinLifetime;
            qrActLaterDatePicker.Value = DateTime.Now;
            qrActLaterTimePicker.Value = DateTime.Now;
            this.qrPolicyPass = qrPolicy;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxActLater.Checked)
            {
                labelTmpActLater.Visible = true;
                qrActLaterDatePicker.Visible = true;
                qrActLaterTimePicker.Visible = true;
            }
            else
            {
                labelTmpActLater.Visible = false;
                qrActLaterDatePicker.Visible = false;
                qrActLaterTimePicker.Visible = false;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            GraphCalls.QrCode newCode = new();
            //set the start time to now, if the user wants to start later, we will get it.
            DateTimeOffset startDateTime = DateTimeOffset.Now;
            //gather values set by the user

            //check if the user wants to specify the start time
            if (checkBoxActLater.Checked)
            {
                //yes, get the start time from the pickers
                startDateTime = qrActLaterDatePicker.Value.Add(qrActLaterTimePicker.Value.TimeOfDay);
            }

            //set the start time
            newCode.StartDateTime = startDateTime;

            //set the expiration date, based on start datetime
            newCode.ExpireDateTime = startDateTime.AddHours((int)numericUpDownLifetime.Value);


            try
            {
                //create the new code
                GraphCalls.QrCode returnedMethod = await GraphCalls.CreateTemporaryQrCode(newCode);
                //clear and redraw the pane
                Control parent = this.Parent;
                parent.Controls.Clear();
                QrCodeDetails pane = new QrCodeDetails(returnedMethod, false, qrPolicyPass);
                pane.Dock = DockStyle.Fill;
                parent.Controls.Add(pane);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
