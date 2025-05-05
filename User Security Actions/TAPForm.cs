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
        public TAPForm(int minimumLifetimeInMinutes, int maximumLifetimeInMinutes, int defaultLifetimeInMinutes)
        {
            InitializeComponent();
            this.numericUpDownMinutes.Minimum = minimumLifetimeInMinutes;
            this.numericUpDownMinutes.Maximum = maximumLifetimeInMinutes;
            this.numericUpDownMinutes.Value = defaultLifetimeInMinutes;
            this.tapDatePicker.MinDate = DateTime.Now;
            this.tapTimePicker.Value = DateTime.Now;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //3. Get the input from the user
            DateTime tapStartDate = tapDatePicker.Value.Date;
            TimeSpan tapStartTime = tapTimePicker.Value.TimeOfDay;
            

            Program.tapDurationInMinutes = (int)numericUpDownMinutes.Value;
            Program.tapReusable = checkBoxReUse.Checked;

            this.Cursor = Cursors.WaitCursor;


            //4. Generate the request from the input
            var requestBody = new TemporaryAccessPassAuthenticationMethod
            {
                StartDateTime = tapStartDate.Add(tapStartTime).ToUniversalTime(),
                LifetimeInMinutes = Program.tapDurationInMinutes,
                IsUsableOnce = Program.tapReusable,
            };
            //5. Submit the request
            TemporaryAccessPassAuthenticationMethod tapResult = new();

            //5.a - check the start date/time of the TAP request
            MessageBox.Show((tapStartDate.Add(tapStartTime).ToUniversalTime()).ToString());
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
            new textInput($"You can use the TAP below starting from\n {tapStartDate.ToLongDateString()} at {tapStartTime}.\n",
                        "TAP Creation Result", tapResult.TemporaryAccessPass).ShowDialog();

        }


    }
}
