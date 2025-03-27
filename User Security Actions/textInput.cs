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
    public partial class textInput: Form
    {
        public textInput(string label, string title)
        {
            InitializeComponent();
            inputPurpose.Text = label;
            this.Text = title;
        }

        private void accept_Click(object sender, EventArgs e)
        {
            Program.input = input1.Text;
            this.Close();
        }
    }
}
