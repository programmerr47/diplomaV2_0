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
        public int sizeX = 0;
        public int sizeY = 0;
        public int sizeZ = 0;
        public int offsetX = 0;

        public int offsetY = 0;
        public int offsetZ = 0;

        public Form1()
        {
            InitializeComponent();
            saveFile.Filter = Constants.fileFilter;
            openFile.Filter = Constants.fileFilter;
            exportFile.Filter = Constants.exportFileFilter;
            IFileWorker worker;
            worker = FileFactory.createWorker(Utils.Formats.PROPERTY, this);
            worker.readFromFile();
            this.Text = "Новый документ    -    Программа для расчета индукции";
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            openFile.InitialDirectory = Directory.GetCurrentDirectory();
            saveFile.InitialDirectory = Directory.GetCurrentDirectory();
            exportFile.InitialDirectory = Directory.GetCurrentDirectory();
            loadingIndicator.Image = Properties.Resources.LoadingImage;
            loadingIndicator.Visible = false;
            loadingLabel.Visible = false;

            if (utils.Properties.currentCalculateMethod.Equals(Utils.Calcs.LINEAR))
            {
                linearFunctionsToolStripMenuItem.Checked = true;
            }
            else
            {
                lagranghToolStripMenuItem.Checked = true;
            }

            if (!File.Exists(utils.Properties.currentPathToParaview))
            {
                DialogResult d = MessageBox.Show("Хотите ли вы указать путь до Paraview?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (d == DialogResult.Yes)
                {
                    openFile.Filter = null;
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(openFile.FileName))
                        {
                            utils.Properties.currentPathToParaview = openFile.FileName;
                        }
                    }
                    openFile.Filter = Constants.fileFilter;
                }
                else if (d == DialogResult.No)
                {
                    return;
                }
            }
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
            if (dataBaseGridB.Rows.Count <= 1)
            {
                MessageBox.Show(
                    "Нечего вычислять. Для начала введите координаты интересующих вас точек в таблицу справа.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
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
            worker.writeInFile(null);
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

            openFile.FileName = null;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(openFile.FileName))
                {
                    utils.Properties.currentPathToFile = openFile.FileName;
                    IFileWorker worker;
                    worker = FileFactory.createWorker(Utils.Formats.CSV, this);
                    worker.parseFileName();
                    worker.readFromFileAsync();
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

            worker.writeInFile(null);
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
                worker.writeInFile(null);
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

            if (exportFile.ShowDialog() == DialogResult.OK)
            {
                IFileWorker worker = FileFactory.createWorker(Utils.Formats.VTK, this);
                IFileWorker propertyWorker = FileFactory.createWorker(Utils.Formats.PROPERTY, this);
                utils.Properties.currentPathToFile = exportFile.FileName;
                ExportForm exportForm = new ExportForm(worker, propertyWorker, this);
                exportForm.Show();
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            calcToolStripMenuItem_Click(sender, e);
        }

        public void showLoadingBar()
        {
            loadingIndicator.Visible = true;
            loadingLabel.Visible = true;
        }

        public void hideLoadingBar()
        {
            loadingIndicator.Visible = false;
            loadingLabel.Visible = false;
        }

        private void keepResultsButton_Click(object sender, EventArgs e)
        {
            Utils.copyBtoA(dataBaseGridA, dataBaseGridB);
        }

        /*private void Form1_SizeChanged(object sender, EventArgs e)
        {
            const int FUCKIN_CONST = 30;
            const int INDENT = 3;
            int height = this.Size.Height;
            int width = this.Size.Width;
            int bottomBarHeight = (keepResultsButton.Size.Height > calculateButton.Size.Height) ? keepResultsButton.Size.Height : calculateButton.Size.Height;

            keepResultsButton.Location = new Point(width / 2, height - FUCKIN_CONST - keepResultsButton.Size.Height - INDENT);
            calculateButton.Location = new Point(width / 2 - calculateButton.Size.Width, height - FUCKIN_CONST - calculateButton.Size.Height - INDENT);
            hintLabel1.Location = new Point(width / 2, hintLabel1.Location.Y);

            Size dataBaseGridSize = new Size(width / 2 - 2 * INDENT, height - FUCKIN_CONST - 45 - 2 * INDENT - bottomBarHeight);
            dataBaseGridA.Size = dataBaseGridSize;
            dataBaseGridB.Size = dataBaseGridSize;
            dataBaseGridB.Location = new Point(width / 2 - 2 * INDENT, dataBaseGridB.Location.Y);

            resizeColumns(dataBaseGridB, "Bz");
            resizeColumns(dataBaseGridA, "Az");
        }

        private void resizeColumns(DataGridView dataBaseGrid, String dividerColumn)
        {
            DataGridViewColumnCollection columns = dataBaseGrid.Columns;
            int columnWidth = columns.GetFirstColumn(DataGridViewElementStates.Displayed).Width;
            foreach (DataGridViewColumn column in columns)
            {
                column.Width = (dataBaseGridB.Width - 45 - 20) / 6;
                if (column.HeaderText.Equals(dividerColumn))
                {
                    column.Width += 20;
                }
            }
        }*/
    }
}
