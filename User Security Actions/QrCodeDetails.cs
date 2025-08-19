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
    public partial class QrCodeDetails : UserControl
    {
        public QrCodeDetails()
        {
            InitializeComponent();
        }
        public QrCodeDetails(GraphCalls.QrCode qrCode)
        {
            InitializeComponent();
            this.labelidDisplay.Text = qrCode.id;
            this.labelCreatedDateTimeDisplay.Text = 
                string.Format("{0:MMM d, yyyy at hh:mm}", qrCode.createdDateTime.ToString());
            this.labelStartDateTimeDisplay.Text =
                string.Format("{0:MMM d, yyyy at hh:mm}", qrCode.startDateTime.ToString());

        }

        private void buttonDelCode_Click(object sender, EventArgs e)
        {

        }
    }
}
