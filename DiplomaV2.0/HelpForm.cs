using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomaV2._0
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader("docums\\about.txt", Encoding.GetEncoding(1251));
            string line;
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                aboutTextBox.Text += line + Environment.NewLine;
            }
            streamReader.Close();
            streamReader = new StreamReader("docums\\files.txt", Encoding.GetEncoding(1251));
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                filesTextBox.Text += line + Environment.NewLine;
            }
            streamReader.Close();
            streamReader = new StreamReader("docums\\calcs.txt", Encoding.GetEncoding(1251));
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                calcsTextBox.Text += line + Environment.NewLine;
            }
            streamReader.Close();
        }
    }
}
