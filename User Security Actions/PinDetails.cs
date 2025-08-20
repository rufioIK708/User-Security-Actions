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
    public partial class PinDetails : UserControl
    {
        public PinDetails()
        {
            InitializeComponent();
        }

        public PinDetails(GraphCalls.QrPin pin)
        {
            InitializeComponent();
            if (null == pin.Id)
                labelPinIdDisplay.Text = "NULL";
            else
                labelPinIdDisplay.Text = pin.Id;

            if(pin.CreatedDateTime.HasValue)
                labelPinCreatedDisplay.Text = pin.CreatedDateTime.Value.ToLocalTime().ToString();

            if (pin.UpdatedDateTime.HasValue)
                labelPinUpdatedDisplay.Text = pin.UpdatedDateTime.Value.ToLocalTime().ToString();

            if (pin.ForceChangePinNextSignIn.HasValue)
                labelPinForceChangeDisplay.Text = pin.ForceChangePinNextSignIn.ToString();

            if (null == pin.Code)
                labelPinNewPinDisplay.Text = "N/A";
            else
                labelPinNewPinDisplay.Text = pin.Code;
        }

        private void buttonResetPin_Click(object sender, EventArgs e)
        {
            
        }
    }
}
