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

            DateTimeOffset tapStartDate = tapDatePicker.Value.Date;
            TimeSpan tapStartTime = tapTimePicker.Value.TimeOfDay;
            int tapDurationInMinutes = (int)numericUpDownMinutes.Value;
            bool tapIsUsableOnce = checkBoxReUse.Checked;
            var startDateTime = tapStartDate.Add(tapStartTime);
            startDateTime = startDateTime.ToUniversalTime();
            
            //4. Generate the request from the input

            if (checkBoxPresentOrFurtureTAP.Checked)
            {
                //if the checkbox is checked, we are creating a future TAP
                //so enable the date and time pickers
                requestBody = new TemporaryAccessPassAuthenticationMethod
                {
                    //trying with a fixed start date/time as a test, still getting error
                    // related to the start date/time being in the past
                    StartDateTime = startDateTime,
                    //StartDateTime = DateTimeOffset.Parse("2025-07-19T17:50:00.000Z"),
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
            TemporaryAccessPassAuthenticationMethod tapResult;

            //5.a - check the start date/time of the TAP request
            //MessageBox.Show((tapStartDate.Add(tapStartTime).ToUniversalTime()).ToString());
            try
            {
                tapResult = await GraphCalls.CreateTapMethod(requestBody);
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

            //set up the strings for the message box. Use the values from the TAP result
            string mainLabel = $"You can use the TAP below starting from\n" +
                $"{tapResult.StartDateTime.Value.LocalDateTime.ToString()}.\n" +
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
            var startTime = tapDatePicker.Value.Date.Add(tapTimePicker.Value.TimeOfDay).ToUniversalTime();

            //set the label to show the selected time
            labelTimeCheck.Text = $"Selected time: {startTime.ToString()}";
        }
    }
}
