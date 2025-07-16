using Microsoft.Graph.Beta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Security_Actions
{
    public partial class TAPForm: Form
    {
        public TAPForm(int? minimumLifetimeInMinutes, int? maximumLifetimeInMinutes,
            int? defaultLifetimeInMinutes, bool? isUsableOnce)
        {
            InitializeComponent();

            //set the values for the date/time pickers and lifetime controls
            this.numericUpDownMinutes.Minimum = (decimal)minimumLifetimeInMinutes;
            this.numericUpDownMinutes.Maximum = (decimal)maximumLifetimeInMinutes;
            this.numericUpDownMinutes.Value = (decimal)defaultLifetimeInMinutes;
            this.tapDatePicker.MinDate = DateTime.Now;
            this.tapTimePicker.Value = DateTime.Now;

            //check if the TAP is usable once
            if ((bool)isUsableOnce)
            {
                //policy states that TAPs are not reusable,
                //so disable the checkbox and set it to false
                this.checkBoxReUse.Enabled = false;
                this.checkBoxReUse.Checked = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            TemporaryAccessPassAuthenticationMethod requestBody;
            this.Cursor = Cursors.WaitCursor;

            //1. Copy the input from the user


            DateTime tapStartDate = tapDatePicker.Value.Date;
            TimeSpan tapStartTime = tapTimePicker.Value.TimeOfDay;
            int tapDurationInMinutes = (int)numericUpDownMinutes.Value;
            bool tapIsUsableOnce = checkBoxReUse.Checked;

            //2. Generate the request from the input

            if (checkBoxPresentOrFurtureTAP.Checked)
            {
                //if the checkbox is checked, we are creating a future TAP
                //so enable the date and time pickers
                requestBody = new TemporaryAccessPassAuthenticationMethod
                {
                    StartDateTime = (tapStartDate.Add(tapStartTime)).ToUniversalTime(),
                    LifetimeInMinutes = tapDurationInMinutes,
                    IsUsableOnce = tapIsUsableOnce,
                };
            }
            else
            {
                requestBody = new TemporaryAccessPassAuthenticationMethod
                { 
                    LifetimeInMinutes = tapDurationInMinutes,
                    IsUsableOnce = tapIsUsableOnce,
                };
            }
            

            //3. Submit the request
            TemporaryAccessPassAuthenticationMethod tapResult = new();

            //3.a - check the start date/time of the TAP request
            //MessageBox.Show((tapStartDate.Add(tapStartTime).ToUniversalTime()).ToString());
            try
            {
                tapResult = await Program.graphClient.Users[Program.user.Id]
                    .Authentication.TemporaryAccessPassMethods
                    .PostAsync(requestBody);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error creating TAP method. Please try again."
                    + "\n" + err.Message);
                this.Cursor = Cursors.Default;
                return;
            }
            //6. Display the result
            this.Cursor = Cursors.Default;
            this.Close();

            string mainLabel = $"You can use the TAP below starting from\n {tapStartDate.ToLongDateString()} at {tapStartTime}.\n";
            string title = "TAP Creation Result";

            new textInput(mainLabel, title, tapResult.TemporaryAccessPass).ShowDialog();

            

        }

        private void checkBoxPresentOrFurtureTAP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPresentOrFurtureTAP.Checked)
            {
                //if the checkbox is checked, we are creating a future TAP
                //so enable the date and time pickers
                tapDatePicker.Enabled = true;
                tapTimePicker.Enabled = true;
                //labelPresentOrFutureTAP.Text = "Create a future TAP";
            }
            else
            {
                //if the checkbox is unchecked, we are creating a present TAP
                //so disable the date and time pickers
                tapDatePicker.Enabled = false;
                tapTimePicker.Enabled = false;
                //labelPresentOrFutureTAP.Text = "Create a present TAP";
            }
        }
    }
}
