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
            if(null != pin.id)
                labelPinIdDisplay.Text = pin.id;
            if(pin.createdDateTime.HasValue)
                labelPinCreatedDisplay.Text = pin.createdDateTime.Value.ToLocalTime().ToString();
            if (pin.updatedDateTime.HasValue)
                labelPinUpdatedDisplay.Text = pin.updatedDateTime.Value.ToLocalTime().ToString();
            if (pin.forceChangePinNextSignIn.HasValue)
                labelPinForceChangeDisplay.Text = pin.forceChangePinNextSignIn.ToString();
            if (null != pin.code)
                labelPinNewPinDisplay.Text = pin.code;
        }

        private void buttonResetPin_Click(object sender, EventArgs e)
        {
           
        }
    }
}
