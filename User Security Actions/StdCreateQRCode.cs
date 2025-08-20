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
        }

        public StdCreateQRCode(Boolean HasPin)
        {
            InitializeComponent();

            if (HasPin)
            {
                labelEnterPin.Dispose();
                textBoxPin.Dispose();
                
                Label pinMessage = new Label();
                pinMessage.Text = "This user has a PIN configured. You can RESET it in the PIN Details tab if needed.";
                tableLayoutPanel1.Controls.Add(pinMessage,tableLayoutPanel1.ColumnCount - 1, tableLayoutPanel1.RowCount - 1);
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
    }
}
