using System.Threading;
using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomaV2._0.files
{
    class CSVFileWorker : AbstractFileWorker
    {
        public CSVFileWorker(Form1 pf) : base(pf) {}

        public override void writeInFile(int[] parameters)
        {
            DataGridView dataA = parentForm.getDatabaseA();
            DataGridView dataB = parentForm.getDatabaseB();

            StreamWriter streamwriter = File.CreateText(utils.Properties.currentPathToFile);
            string line;
            for (int i = 0; i < dataA.RowCount - 1; i++)
            {
                line = "";
                for (int j = 0; j < dataA.ColumnCount; j++)
                {
                    line += dataA.Rows[i].Cells[j].Value.ToString();
                    if (j != dataA.ColumnCount - 1) line += ";";
                }
                streamwriter.WriteLine(line);
            }
            streamwriter.WriteLine(Constants.tableSeparateLine);
            for (int i = 0; i < dataB.RowCount - 1; i++)
            {
                line = "";
                for (int j = 0; j < dataB.ColumnCount; j++)
                {
                    line += dataB.Rows[i].Cells[j].Value.ToString();
                    if (j != dataB.ColumnCount - 1) line += ";";
                }
                streamwriter.WriteLine(line);
            }
            streamwriter.Close();
        }

        public override void readFromFile()
        {
            parentForm.Invoke(new ThreadStart(delegate
            {
                parentForm.showLoadingBar();
            }));

            DataGridView dataA = parentForm.getDatabaseA();
            DataGridView dataB = parentForm.getDatabaseB();
            bool firstOffsetX = true;
            bool firstOffsetY = true;
            bool firstOffsetZ = true;

            parentForm.Invoke(new ThreadStart(delegate
            {
                dataA.Rows.Clear();
                dataB.Rows.Clear();
            }));
            if ((utils.Properties.currentPathToFile != "-") && (Utils.getExtension(utils.Properties.currentPathToFile) != null) && (Utils.getExtension(utils.Properties.currentPathToFile).ToLower().Equals("csv")))
            {
                try
                {
                    StreamReader streamReader = new StreamReader(utils.Properties.currentPathToFile);
                    string str;
                    string[] values;
                    int i = 0;
                    bool boolA = true;
                    while (!streamReader.EndOfStream)
                    {
                        str = streamReader.ReadLine();
                        if (!str.Equals(Constants.tableSeparateLine))
                        {
                            values = str.Split(';');
                            if (boolA)
                            {
                                if (dataA.Rows.Count <= i + 1)
                                {
                                    parentForm.Invoke(new ThreadStart(delegate
                                    {
                                        dataA.Rows.Add(); 
                                    }));
                                }
                                for (int j = 0; j < values.Length; j++)
                                {
                                    parentForm.Invoke(new ThreadStart(delegate
                                    {
                                        dataA.Rows[i].Cells[j].Value = values[j];
                                    }));
                                    if (j < 3)
                                    {
                                        int value = Int32.Parse(values[j]);
                                        if (j == 0)
                                        {
                                            if (value > parentForm.sizeX)
                                            {
                                                parentForm.sizeX = value;
                                            }
                                            if (firstOffsetX || parentForm.offsetX > value)
                                            {
                                                parentForm.offsetX = value;
                                                firstOffsetX = false;
                                            }
                                        }
                                        else if (j == 1)
                                        {
                                            if (value > parentForm.sizeY)
                                            {
                                                parentForm.sizeY = value;
                                            }
                                            if (firstOffsetY || parentForm.offsetY > value)
                                            {
                                                parentForm.offsetY = value;
                                                firstOffsetY = false;
                                            }
                                        }
                                        else if (j == 2)
                                        {
                                            if (value > parentForm.sizeZ)
                                            {
                                                parentForm.sizeZ = value;
                                            }
                                            if (firstOffsetZ || parentForm.offsetZ > value)
                                            {
                                                parentForm.offsetZ = value;
                                                firstOffsetZ = false;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (dataB.Rows.Count == i + 1)
                                {
                                    parentForm.Invoke(new ThreadStart(delegate
                                    {
                                        dataB.Rows.Add();
                                    }));
                                }
                                for (int j = 0; j < values.Length; j++)
                                {
                                    parentForm.Invoke(new ThreadStart(delegate
                                    {
                                        dataB.Rows[i].Cells[j].Value = values[j];
                                    }));
                                    if (j < 3)
                                    {
                                        int value = Int32.Parse(values[j]);
                                        if (j == 0)
                                        {
                                            if (value > parentForm.sizeX)
                                            {
                                                parentForm.sizeX = value;
                                            }
                                            if (firstOffsetX || parentForm.offsetX > value)
                                            {
                                                parentForm.offsetX = value;
                                                firstOffsetX = false;
                                            }
                                        }
                                        else if (j == 1)
                                        {
                                            if (value > parentForm.sizeY)
                                            {
                                                parentForm.sizeY = value;
                                            }
                                            if (firstOffsetY || parentForm.offsetY > value)
                                            {
                                                parentForm.offsetY = value;
                                                firstOffsetY = false;
                                            }
                                        }
                                        else if (j == 2)
                                        {
                                            if (value > parentForm.sizeZ)
                                            {
                                                parentForm.sizeZ = value;
                                            }
                                            if (firstOffsetZ || parentForm.offsetZ > value)
                                            {
                                                parentForm.offsetZ = value;
                                                firstOffsetZ = false;
                                            }
                                        }
                                    }
                                }
                            }

                            i++;
                        }
                        else
                        {
                            i = 0;
                            boolA = false;
                        }
                    }
                    streamReader.Close();
                }
                catch (IOException ex)
                {
                    writeErrorMessage();
                }
            }
            else
            {
                writeErrorMessage();
            }

            parentForm.Invoke(new ThreadStart(delegate
            {
                parentForm.hideLoadingBar();
                DialogResult d = MessageBox.Show("Загрузка данных завершена.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }

        private void writeErrorMessage()
        {
            MessageBox.Show("Последний используемый программой проект не найден. Создан новый проект", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            utils.Properties.currentFileName = "-";
            utils.Properties.currentPathToFile = "-";
            utils.Properties.currentDirectory = "-";
        }
    }
}
