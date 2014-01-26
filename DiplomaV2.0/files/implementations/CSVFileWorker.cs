﻿using DiplomaV2._0.utils;
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

        public override void writeInFile()
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
            DataGridView dataA = parentForm.getDatabaseA();
            DataGridView dataB = parentForm.getDatabaseB();

            dataA.Rows.Clear();
            dataB.Rows.Clear();
            if (utils.Properties.currentPathToFile != "-")
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
                                    dataA.Rows.Add();
                                for (int j = 0; j < values.Length; j++)
                                    dataA.Rows[i].Cells[j].Value = values[j];
                            }
                            else
                            {
                                if (dataB.Rows.Count == i + 1)
                                    dataB.Rows.Add();
                                for (int j = 0; j < values.Length; j++)
                                    dataB.Rows[i].Cells[j].Value = values[j];
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
                catch (Exception ex)
                {
                    MessageBox.Show("Последний используемый программой проект не найден. Создан новый проект", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    utils.Properties.currentFileName = "-";
                    utils.Properties.currentPathToFile = "-";
                    utils.Properties.currentDirectory = "-";
                }
            }
        }
    }
}