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

using DiplomaV2._0.calculations;
using DiplomaV2._0.exceptions;
using DiplomaV2._0.utils;
using DiplomaV2._0.files;

namespace DiplomaV2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFile.Filter = Constants.fileFilter;
            openFile.Filter = Constants.fileFilter;
            exportFile.Filter = Constants.exportFileFilter;
            IFileWorker worker;
            worker = FileFactory.createWorker(Utils.Formats.CSV, this);
            worker.readFromFile();
            worker = FileFactory.createWorker(Utils.Formats.PROPERTY, this);
            worker.readFromFile();

            if (utils.Properties.currentCalculateMethod.Equals(Utils.Calcs.LINEAR))
            {
                linearFunctionsToolStripMenuItem.Checked = true;
            }
            else
            {
                lagranghToolStripMenuItem.Checked = true;
            }
            setFormText();
        }

        private void lagranghToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.Properties.currentCalculateMethod = Utils.Calcs.LAGRANGE;
            lagranghToolStripMenuItem.Checked = true;
            linearFunctionsToolStripMenuItem.Checked = false;
        }

        private void linearFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.Properties.currentCalculateMethod = Utils.Calcs.LINEAR;
            lagranghToolStripMenuItem.Checked = false;
            linearFunctionsToolStripMenuItem.Checked = true;
        }

        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateProgressForm cpForm = new CalculateProgressForm(this);
                this.Enabled = false;
                cpForm.Show();
            }
            catch (DataBaseException ex)
            {
                MessageBox.Show(ex.Message, "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataGridView getDatabaseA()
        {
            return dataBaseGridA;
        }

        public DataGridView getDatabaseB()
        {
            return dataBaseGridB;
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesForm pForm = new PropertiesForm();
            pForm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!checkEmptyProject())
                {
                    DialogResult d = MessageBox.Show("Выхотите сохранить таблицу перед выходом?", "Вопрос", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                    if (d == DialogResult.Yes)
                        saveTable();
                    else if (d == DialogResult.Cancel)
                        e.Cancel = true;
                }
            }

            IFileWorker worker;
            worker = FileFactory.createWorker(Utils.Formats.PROPERTY, this);
            worker.writeInFile();
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkEmptyProject())
            {
                DialogResult d = MessageBox.Show("Выхотите сохранить таблицу перед выходом?", "Вопрос", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (d == DialogResult.Yes)
                    saveTable();
                else if (d == DialogResult.Cancel)
                    return;
            }

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(openFile.FileName))
                {
                    utils.Properties.currentPathToFile = openFile.FileName;
                    IFileWorker worker;
                    worker = FileFactory.createWorker(Utils.Formats.CSV, this);
                    worker.parseFileName();
                    worker.readFromFile();
                    setFormText();
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTable();
        }

        private void saveTable()
        {
            try
            {
                Directory.SetCurrentDirectory(utils.Properties.currentDirectory);
            }
            catch (DirectoryNotFoundException ex)
            {
            }
            IFileWorker worker;
            worker = FileFactory.createWorker(Utils.Formats.CSV, this);

            if (utils.Properties.currentPathToFile == "-")
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    utils.Properties.currentPathToFile = saveFile.FileName;
                    worker.parseFileName();
                    setFormText();
                }
            }

            worker.writeInFile();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(utils.Properties.currentDirectory);
            IFileWorker worker;
            worker = FileFactory.createWorker(Utils.Formats.CSV, this);

            if (saveFile.ShowDialog() == DialogResult.OK)    
            {
                utils.Properties.currentPathToFile = saveFile.FileName;
                worker.parseFileName();
                worker.writeInFile();
                setFormText();
            }
        }

        private void setFormText()
        {
            if (utils.Properties.currentFileName == "-")
                this.Text = "Новый документ    -    Программа для расчета индукции";
            else
                this.Text = utils.Properties.currentFileName + "    -    " + "Программа для расчета индукции";
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkEmptyProject())
            {
                DialogResult d = MessageBox.Show("Выхотите сохранить таблицу перед выходом?", "Вопрос", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (d == DialogResult.Yes)
                    saveTable();
                else if (d == DialogResult.Cancel)
                    return;
            }

            dataBaseGridA.Rows.Clear();
            dataBaseGridB.Rows.Clear();
            utils.Properties.currentDirectory = utils.Properties.directoryOfApp;
            utils.Properties.currentFileName = "-";
            utils.Properties.currentPathToFile = "-";
            setFormText();
        }

        private bool checkEmptyProject()
        {
            if ((dataBaseGridB.Rows.Count == 1) &&
                (dataBaseGridB.Rows.Count == 1) &&
                (utils.Properties.currentFileName == "-"))
                return true;
            else
                return false;
        }

        private void saveCalcsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.copyBtoA(dataBaseGridA, dataBaseGridB);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm hForm = new HelpForm();
            hForm.Show();
        }

        private void exportVtkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.SetCurrentDirectory(utils.Properties.currentDirectory);
            }
            catch (Exception ex)
            {
            }
            IFileWorker worker;
            worker = FileFactory.createWorker(Utils.Formats.VTK, this);

            if (exportFile.ShowDialog() == DialogResult.OK)
            {
                utils.Properties.currentPathToFile = exportFile.FileName;
                worker.parseFileName();
                worker.writeInFile();
            }
        }
    }
}
