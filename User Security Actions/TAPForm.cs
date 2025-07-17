using Microsoft.Graph.Beta.Models;
using Microsoft.Graph.Beta.Models.Ediscovery;
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
            
            this.tapDatePicker.Enabled = false;
            this.tapTimePicker.Enabled = false;

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
            //1. Get the TAP method policy
            //2. Modify the form to show the options
            //3. Get the input from the user
            //4. Generate the request from the input
            //5. Submit the request
            //6. Display the result


            TemporaryAccessPassAuthenticationMethod requestBody;
            this.Cursor = Cursors.WaitCursor;

            //3. Copy the input from the user/form

            DateTime tapStartDate = tapDatePicker.Value.Date;
            TimeSpan tapStartTime = tapTimePicker.Value.TimeOfDay;
            int tapDurationInMinutes = (int)numericUpDownMinutes.Value;
            bool tapIsUsableOnce = checkBoxReUse.Checked;

            //4. Generate the request from the input

            if (checkBoxPresentOrFurtureTAP.Checked)
            {
                //if the checkbox is checked, we are creating a future TAP
                //so enable the date and time pickers
                requestBody = new TemporaryAccessPassAuthenticationMethod
                {
                    //trying with a fixed start date/time as a test, still getting error
                    // related to the start date/time being in the past
                    StartDateTime = tapStartDate.Add(tapStartTime).ToUniversalTime(),
                    //StartDateTime = DateTimeOffset.Parse("2025-07-19T12:40:00.000Z"),
                    LifetimeInMinutes = tapDurationInMinutes,
                    IsUsableOnce = tapIsUsableOnce,
                };
            }
            else
            {
                //creating a tap for now, StartDateTime is optional so we can leave it out
                requestBody = new TemporaryAccessPassAuthenticationMethod
                { 
                    LifetimeInMinutes = tapDurationInMinutes,
                    IsUsableOnce = tapIsUsableOnce,
                };
            }

            //5. Submit the request
            TemporaryAccessPassAuthenticationMethod tapResult = new();

            //5.a - check the start date/time of the TAP request
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

            string month;

            switch (tapResult.StartDateTime.Value.Month)
            {
                case 1: month = "January"; break;
                case 2: month = "February"; break;
                case 3: month = "March"; break;
                case 4: month = "April"; break;
                case 5: month = "May"; break;
                case 6: month = "June"; break;
                case 7: month = "July"; break;
                case 8: month = "August"; break;
                case 9: month = "September"; break;
                case 10: month = "October"; break;
                case 11: month = "November"; break;
                case 12: month = "December"; break;
                default: month = ""; break;
            }

            //set up the strings for the message box. Use the values from the TAP result
            string mainLabel = $"You can use the TAP below starting from\n" +
                $"{month} {tapResult.StartDateTime.Value.Day} at " +
                $"{tapResult.StartDateTime.Value.Hour}:{tapResult.StartDateTime.Value.Minute}.\n" +
                $"It will be usable for {tapResult.LifetimeInMinutes} minutes";

            string title = "TAP Creation Result";

            new textInput(mainLabel, title, tapResult.TemporaryAccessPass).ShowDialog();

            this.Close();

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

        private void tapTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //set the label to show the selected time
            labelTimeCheck.Text = $"Selected time: {
                tapDatePicker.Value.Add(tapTimePicker.Value.TimeOfDay).ToUniversalTime()
                    .ToString()}";
        }
    }
}
