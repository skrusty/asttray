using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstTray
{
    public partial class FrmDirectoryEditor : Form
    {

        public string Name {get;set;}
        public string Number { get; set; }

        public FrmDirectoryEditor()
        {
            InitializeComponent();
        }

        private void FrmDirectoryEditor_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Name))
                this.nameTxt.Text = this.Name;
            if (!string.IsNullOrEmpty(this.Number))
                this.numberTxt.Text = this.Number;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.Name = this.nameTxt.Text;
            this.Number = this.numberTxt.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
