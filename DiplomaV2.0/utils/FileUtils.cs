using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomaV2._0.utils
{
    class FileUtils
    {
        public static void writeInPropertyFile()
        {
            StreamWriter streamWriter = File.CreateText(Properties.directoryOfApp + Properties.currentNamePropertyFile);
            streamWriter.WriteLine("decimalSeparator=" + Properties.currentDecimalSeparator + "");
            streamWriter.WriteLine("pathToFile=" + Properties.currentPathToFile + "");
            streamWriter.WriteLine("calculationMethod=" + Properties.currentCalculateMethod + "");
            streamWriter.Close();
        }

        public static void readFromPropertyFile()
        {
            try
            {
                StreamReader streamReader = new StreamReader(Properties.currentNamePropertyFile);
                string str;
                string[] comms;
                while (!streamReader.EndOfStream)
                {
                    str = streamReader.ReadLine();
                    comms = str.Split('=');
                    switch (comms[0])
                    {
                        case "decimalSeparator":
                            {
                                Properties.currentDecimalSeparator = comms[1];
                                break;
                            }
                        case "pathToFile":
                            {
                                if (comms[1] != "-")
                                {
                                    Properties.currentPathToFile = comms[1];
                                    parseFileName();
                                }
                                break;
                            }
                        case "calculationMethod":
                            {
                                try
                                {
                                    Properties.currentCalculateMethod = (Utils.Calcs)Enum.Parse(typeof(Utils.Calcs), comms[1], true);
                                }
                                catch (ArgumentException ex)
                                {
                                    Properties.currentCalculateMethod = Utils.Calcs.LAGRANGE;
                                }
                                break;
                            }
                    }
                }
                streamReader.Close();
            }
            catch (FileNotFoundException ex)
            {
                writeInPropertyFile();
            }
        }

        public static void writeInFile(DataGridView dataA, DataGridView dataB)
        {
            StreamWriter streamwriter = File.CreateText(Properties.currentPathToFile);
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

        public static void readFromFile(DataGridView dataA, DataGridView dataB)
        {
            dataA.Rows.Clear();
            dataB.Rows.Clear();
            if (Properties.currentPathToFile != "-")
            {
                try
                {
                    StreamReader streamReader = new StreamReader(Properties.currentPathToFile);
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
                    Properties.currentFileName = "-";
                    Properties.currentPathToFile = "-";
                    Properties.currentDirectory = "-";
                }
            }
        }

        public static void parseFileName() 
        {
            string path = Properties.currentPathToFile;
            int index = path.Length - 1;
            while ((path[index] != '\\') && (index > 0))
                index--;
            Properties.currentFileName = path.Substring(index + 1);
            Properties.currentDirectory = path.Substring(0, index);
        }
    }
}
