using Microsoft.Graph.Beta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace User_Security_Actions
{

    public partial class textInput: Form
    {
        public textInput(string label, string title, string password)
        {
            InitializeComponent();
            inputPurpose.Text = label;
            this.Text = title;
            //hide the split container, as we are not using it
            splitContainer1.Hide();
            labelMethodMessage.Text = "The new password is: ";
            input1.Text = password;
            input1.BackColor = System.Drawing.SystemColors.Control;
            input1.ReadOnly = true;
            input1.BorderStyle = BorderStyle.None;
            input1.MouseUp += new MouseEventHandler(
                          delegate (object sender, MouseEventArgs e)
                          { HideCaret((sender as Control).Handle); });

            [DllImport("User32.dll")]
            static extern Boolean HideCaret(IntPtr hWnd);
        }
        public textInput(string label, string title, bool mfa)
        {
            InitializeComponent();
            inputPurpose.Text = label;
            this.Text = title;

            if (mfa)
            {
                splitContainer1.Show();
                radioButtonAltMobile.Hide();
                radioButtonMobile.Hide();
                radioButtonOffice.Hide();
                labelMethodMessage.Hide();
            }
            else
            {
                splitContainer1.Hide();
                labelMethodMessage.Hide();
            }
        }

        private void textInput_Load(object sender, EventArgs e)
        {

        }

        private void accept_Click(object sender, EventArgs e)
        {
            //clear text first, this ensures we don't get stuck with previous input.
            Program.input = "";
            //get the input  string
            Program.input = input1.Text;


            //if the this is not for MFA, ignor the other buttons
            if (!splitContainer1.Visible)
            {
                this.Close();
                return;
            }
            //if the user is using the MFA form, we need to store the method details
            else if (radioButtonPhoneMethod.Checked)
            {
                //not used now, but could be later, mostly included for completeness
                Program.methodType = MethodType.Phone;

                //store the state of method selected.
                if (radioButtonMobile.Checked)
                    Program.phoneOptions = PhoneOption.Mobile;
                else if (radioButtonOffice.Checked)
                    Program.phoneOptions = PhoneOption.Office;
                else if (radioButtonAltMobile.Checked)
                    Program.phoneOptions = PhoneOption.AlternateMobile;
                else
                {
                    MessageBox.Show("Please select a phone method type.");
                    return;
                }
            }
            else if (radioButtonEmailMethod.Checked)
            {
                Program.methodType = MethodType.Email;
            }
            else
            {
                MessageBox.Show("Please select a method type.");
                return;
            }


            //close the form
            this.Close();
        }
            
        

        private void radioButtonMobileMethod_CheckedChanged(object sender, EventArgs e)
        {
            //show and modify the label
            labelMethodMessage.Show();
            labelMethodMessage.Text = "Please enter the phone number as +1 1234567890";
            
            //show the rest of the buttons
            radioButtonOffice.Show();
            radioButtonAltMobile.Show();
            radioButtonMobile.Show();

            
            textInput_Load(sender, e);
        }

        private void radioButtonEmailMethod_CheckedChanged(object sender, EventArgs e)
        {
            //show and modify the label
            labelMethodMessage.Show();
            labelMethodMessage.Text = "Enter the alternate e-mail for : " + Program.user.DisplayName;
            
            //disable the buttons, in case they were already showing
            radioButtonOffice.Hide();
            radioButtonAltMobile.Hide();
            radioButtonMobile.Hide();

            //reload the form
            textInput_Load(sender, e);
        }
    }
}
