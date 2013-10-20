using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomaV2._0
{
    public partial class PropertiesForm : Form
    {
        public PropertiesForm()
        {
            InitializeComponent();
        }

        private void PropertiesForm_Load(object sender, EventArgs e)
        {
            decimalSeparatorTextBox.Text = utils.Properties.currentDecimalSeparator;
        }

        private void PropertiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var res = MessageBox.Show("Вы хотите сохранить данные перед выходом?", "Вопрос", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    utils.Properties.currentDecimalSeparator = decimalSeparatorTextBox.Text;
                }
                else if (res == DialogResult.Cancel) e.Cancel = true;
            }
        }
    }
}
