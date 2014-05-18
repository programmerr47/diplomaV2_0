using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

using DiplomaV2._0.exceptions;

namespace DiplomaV2._0.utils
{
    public class Utils
    {
        public enum Calcs { LAGRANGE, LINEAR }
        public enum Formats { VTK, CSV, PROPERTY}


        public static string getExtension(string path)
        {
            if (path.LastIndexOf(".") != -1)
            {
                return path.Substring(path.LastIndexOf(".") + 1);
            }
            else
            {
                return null;
            }
        }

        public static double[,] parseStrings(DataGridView dataBase, int start, int end)
        {
            double[,] result = new double[dataBase.RowCount - 1, end - start];
            bool nullCellsException = false;

            Stopwatch sw = new Stopwatch();
            double smallStep = 25.0 / (dataBase.RowCount - 1);

            for (int i = 0; i < dataBase.RowCount - 1; i++)
            {
                sw.Start();

                try
                {
                    for (int j = 0; j < (end - start); j++)
                    {
                        if (dataBase.Rows[i].Cells[j].Value != null)
                            if (dataBase.Rows[i].Cells[j].Value.ToString() == "NULL")
                                nullCellsException = true;
                            else
                                if (dataBase.Rows[i].Cells[j].Value.ToString().Contains(Constants.DECIMAL_SEPARATOR)
                                    && !Properties.currentDecimalSeparator.Equals(Constants.DECIMAL_SEPARATOR))
                                    throw(new Exception("Входная строка имела неверный формат."));
                                else
                                    result[i, j] = Convert.ToDouble(dataBase.Rows[i].Cells[j].Value.ToString().Replace(Properties.currentDecimalSeparator, Constants.DECIMAL_SEPARATOR));
                        else
                        {
                            dataBase.Rows[i].Cells[j].Value = "NULL";
                            nullCellsException = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                while (sw.ElapsedMilliseconds < (20.0 * smallStep)) { }
                sw.Reset();

                Progress.getINSTANCE().addToProgress(smallStep);
            }
            if (nullCellsException) throw (new DataBaseException("Таблица содержит пустые ячейки. \n Сейчас они помечены как NULL. \n Пожалуйста, откорректируйте их для корректной работы приложения."));

            return result;
        }

        public static void toStrings(DataGridView database, double[,] array)
        {
            Stopwatch sw = new Stopwatch();
            double smallStep = 25.0 / array.GetLength(0);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                sw.Start();


                for (int j = 0; j < array.GetLength(1); j++)
                {
                    database.Rows[i].Cells[j + 3].Value = array[i, j].ToString().Replace(Constants.DECIMAL_SEPARATOR, Properties.currentDecimalSeparator);
                }

                sw.Reset();

                Progress.getINSTANCE().addToProgress(smallStep);
            }
        }

        public static void copyBtoA(DataGridView a, DataGridView b)
        {
            int aIndex = a.Rows.Count - 1;

            for (int i = 0; i < b.Rows.Count - 1; i++)
            {
                a.Rows.Add();
                for (int j = 0; j < b.ColumnCount; j++)
                {
                    a.Rows[aIndex + i].Cells[j].Value = b.Rows[i].Cells[j].Value;
                }
            }

            b.Rows.Clear();
        }

        public static void writeInterpolatedDataToB(Number[,,] data, DataGridView table, int originX, int originY, int originZ, Form callForm)
        {
            for (int i = 0; i < table.Rows.Count - 1; i++)
            {
                int x = Convert.ToInt32(table.Rows[i].Cells[0].Value) - originX;
                int y = Convert.ToInt32(table.Rows[i].Cells[1].Value) - originY;
                int z = Convert.ToInt32(table.Rows[i].Cells[2].Value) - originZ;
                if ((x >= data.GetLength(0)) || (y >= data.GetLength(1)) || (z >= data.GetLength(2))
                    || (x < 0) || (y < 0) || (z < 0))
                {
                    callForm.Invoke(new ThreadStart(delegate
                    {
                        table.Rows[i].Cells[3].Value = "#Index out of bounds";
                        table.Rows[i].Cells[4].Value = "#Index out of bounds";
                        table.Rows[i].Cells[5].Value = "#Index out of bounds";
                    }));
                }
                else
                {
                    callForm.Invoke(new ThreadStart(delegate
                    {
                        table.Rows[i].Cells[3].Value = data[x, y, z].x;
                        table.Rows[i].Cells[4].Value = data[x, y, z].y;
                        table.Rows[i].Cells[5].Value = data[x, y, z].z;
                    }));
                }
            }
        }
    }
}
