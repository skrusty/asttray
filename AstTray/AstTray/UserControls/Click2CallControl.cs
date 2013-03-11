using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstTray.UserControls
{
    public partial class Click2CallControl : UserControl
    {
        public delegate void CallEventHandler(string numberToCall);
        public event CallEventHandler Call;

        public Click2CallControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Call != null)
                Call(this.comboBox1.Text);

            // Add to call history
            this.comboBox1.Items.Add(this.comboBox1.Text);
        }
    }

}
