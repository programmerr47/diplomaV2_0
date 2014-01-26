using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DiplomaV2._0.utils;
using System.Collections;

namespace DiplomaV2._0.files
{
    class VTKFileWorker : AbstractFileWorker
    {
        private class Number
        {
            public Number(double x, double y, double z) 
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public double x;
            public double y;
            public double z;
        }

        private Number[, ,] result;
        private Number[, ,] oneSeqRectangle;
        private ArrayList seqs;

        public VTKFileWorker(Form1 pf) : base(pf) {}

        public override void writeInFile()
        {
            DataGridView dataA = parentForm.getDatabaseA();
            DataGridView dataB = parentForm.getDatabaseB();

            generateSeqs();
            result = copyFromDataGridToNet(dataA, dataB);
            waveForThirdCoordinate();
            waveForSecondCoordinate();
            waveForFirstCoordinate();
            fillAnother();
            writeArrayInFile();
        }

        private void fillAnother()
        {
            for (int x = 0; x < result.GetLength(0); x++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    for (int z = 0; z < result.GetLength(2); z++)
                    {
                        if (result[x, y, z] == null)
                        {
                            result[x, y, z] = new Number(0, 0, 0);
                        }
                    }
                }
            }
        }

        private void generateSeqs()
        {
            seqs = new ArrayList();
            seqs.Add(new int[] { 1, 2, 3});
        }

        private void waveForThirdCoordinate()
        {
            for (int x = 0; x < result.GetLength(0); x++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    int last = -1;
                    for (int z = 0; z < result.GetLength(2); z++)
                    {
                        if (result[x, y, z] != null)
                        {
                            if (last == -1)
                            {
                                for (int index = 0; index < z; index++)
                                {
                                    result[x, y, index] = new Number(result[x, y, z].x, result[x, y, z].y, result[x, y, z].z);
                                }
                            }
                            else
                            {
                                double ax = result[x, y, last].x;
                                double bx = result[x, y, z].x;
                                double ay = result[x, y, last].y;
                                double by = result[x, y, z].y;
                                double az = result[x, y, last].z;
                                double bz = result[x, y, z].z;
                                for (int index = last + 1; index < z; index++)
                                {
                                    double k1 = (1.0 * index - last) / (z - last);
                                    double k2 = (z - 1.0 * index) / (z - last);

                                    result[x, y, index] = new Number(ax * k1 + bx * k2,
                                                                     ay * k1 + by * k2,
                                                                     az * k1 + bz * k2);
                                }
                            }

                            last = z;
                        }
                    }

                    if (last != -1)
                    {
                        for (int index = last; index < result.GetLength(2); index++)
                        {
                            result[x, y, index] = new Number(result[x, y, last].x, result[x, y, last].y, result[x, y, last].z);
                        }
                    }
                }
            }
        }

        private void waveForSecondCoordinate()
        {
            for (int x = 0; x < result.GetLength(0); x++)
            {
                for (int z = 0; z < result.GetLength(2); z++)
                {
                    int last = -1;
                    for (int y = 0; y < result.GetLength(1); y++)
                    {
                        if (result[x, y, z] != null)
                        {
                            if (last == -1)
                            {
                                for (int index = 0; index < y; index++)
                                {
                                    result[x, index, z] = new Number(result[x, y, z].x, result[x, y, z].y, result[x, y, z].z);
                                }
                            }
                            else
                            {
                                double ax = result[x, last, z].x;
                                double bx = result[x, y, z].x;
                                double ay = result[x, last, z].y;
                                double by = result[x, y, z].y;
                                double az = result[x, last, z].z;
                                double bz = result[x, y, z].z;
                                for (int index = last + 1; index < y; index++)
                                {
                                    double k1 = (1.0 * index - last) / (y - last);
                                    double k2 = (y - 1.0 * index) / (y - last);

                                    result[x, index, z] = new Number(ax * k1 + bx * k2,
                                                                     ay * k1 + by * k2,
                                                                     az * k1 + bz * k2);
                                }
                            }

                            last = y;
                        }
                    }

                    if (last != -1)
                    {
                        for (int index = last; index < result.GetLength(1); index++)
                        {
                            result[x, index, z] = new Number(result[x, last, z].x, result[x, last, z].y, result[x, last, z].z);
                        }
                    }
                }
            }
        }

        private void waveForFirstCoordinate()
        {
            for (int z = 0; z < result.GetLength(2); z++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    int last = -1;
                    for (int x = 0; x < result.GetLength(0); x++)
                    {
                        if (result[x, y, z] != null)
                        {
                            if (last == -1)
                            {
                                for (int index = 0; index < x; index++)
                                {
                                    result[index, y, z] = new Number(result[x, y, z].x, result[x, y, z].y, result[x, y, z].z);
                                }
                            }
                            else
                            {
                                double ax = result[last, y, z].x;
                                double bx = result[x, y, z].x;
                                double ay = result[last, y, z].y;
                                double by = result[x, y, z].y;
                                double az = result[last, y, z].z;
                                double bz = result[x, y, z].z;
                                for (int index = last + 1; index < x; index++)
                                {
                                    double k1 = (1.0 * index - last) / (x - last);
                                    double k2 = (x - 1.0 * index) / (x - last);

                                    result[index, y, z] = new Number(ax * k1 + bx * k2,
                                                                     ay * k1 + by * k2,
                                                                     az * k1 + bz * k2);
                                }
                            }

                            last = x;
                        }
                    }

                    if (last != -1)
                    {
                        for (int index = last; index < result.GetLength(0); index++)
                        {
                            result[index, y, z] = new Number(result[last, y, z].x, result[last, y, z].y, result[last, y, z].z);
                        }
                    }
                }
            }
        }

        private Number[,,] copyFromDataGridToNet(DataGridView dataA, DataGridView dataB) 
        {
            int maxX = 0;
            int maxY = 0;
            int maxZ = 0;

            maxX = getMaxFromDataGrid(dataA, maxX, 0);
            maxX = getMaxFromDataGrid(dataB, maxX, 0);

            maxY = getMaxFromDataGrid(dataA, maxY, 1);
            maxY = getMaxFromDataGrid(dataB, maxY, 1);

            maxZ = getMaxFromDataGrid(dataA, maxZ, 2);
            maxZ = getMaxFromDataGrid(dataB, maxZ, 2);

            Number[, ,] resultArray = new Number[maxX + 1, maxY + 1, maxZ + 1];

            //for (int x = 0; x < resultArray.GetLength(0); x++)
            //{
            //    for (int y = 0; y < resultArray.GetLength(1); y++)
            //    {
            //        for (int z = 0; z < resultArray.GetLength(2); z++)
            //        {
            //            resultArray[x, y, z] = new Number(0, 0, 0);
            //        }
            //    }
            //}

            copyDataGridToNet(dataA, resultArray);
            copyDataGridToNet(dataA, resultArray);

            return resultArray;
        }

        private void writeArrayInFile()
        {
            StreamWriter streamwriter = File.CreateText(utils.Properties.currentPathToFile);
//# vtk DataFile Version 2.0
//Cube example
//ASCII
//DATASET STRUCTURED_POINTS
//DIMENSIONS 100 100 100
//ORIGIN 0 0 0
//SPACING 4 4 4
//POINT_DATA 1000000
            //VECTORS vectors double
            streamwriter.WriteLine("# vtk DataFile Version 2.0");
            streamwriter.WriteLine("Cube example");
            streamwriter.WriteLine("ASCII");
            streamwriter.WriteLine("DATASET STRUCTURED_POINTS");
            streamwriter.WriteLine("DIMENSIONS " + result.GetLength(0) + " " + result.GetLength(1) + " " + result.GetLength(2));
            streamwriter.WriteLine("ORIGIN 0 0 0");
            streamwriter.WriteLine("SPACING 4 4 4");
            streamwriter.WriteLine("POINT_DATA " + result.Length);
            streamwriter.WriteLine("VECTORS vectors double");

            int column = 0;
            string line = "";
            for (int x = 0; x < result.GetLength(0); x++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    for (int z = 0; z < result.GetLength(2); z++)
                    {
                        line += result[x, y, z].x.ToString().Replace(Constants.DECIMAL_SEPARATOR, ".") + 
                                " " +
                                result[x, y, z].y.ToString().Replace(Constants.DECIMAL_SEPARATOR, ".") + 
                                " " +
                                result[x, y, z].z.ToString().Replace(Constants.DECIMAL_SEPARATOR, ".");
                        column++;
                        if (column >= 5)
                        {
                            streamwriter.WriteLine(line);
                            line = "";
                            column = 0;
                        }
                        else
                        {
                            line += " ";
                        }
                    }
                }
            }

            if (line != "")
            {
                streamwriter.WriteLine(line);
            }

            streamwriter.Close();
        }

        private int getMaxFromDataGrid(DataGridView data, int currentMax, int coord)
        {
            int currentElement;
            for (int i = 0; i < data.RowCount - 1; i++)
            {
                currentElement = Int32.Parse(data.Rows[i].Cells[coord].Value.ToString());
                if (currentElement > currentMax)
                {
                    currentMax = currentElement;
                }
            }

            return currentMax;
        }

        private void copyDataGridToNet(DataGridView data, Number[, ,] result)
        {
            int x;
            int y;
            int z;
            for (int i = 0; i < data.RowCount - 1; i++)
            {
                x = Int32.Parse(data.Rows[i].Cells[0].Value.ToString());
                y = Int32.Parse(data.Rows[i].Cells[1].Value.ToString());
                z = Int32.Parse(data.Rows[i].Cells[2].Value.ToString());

                int p = data.Rows[i].Cells.Count;
                //double k = Convert.ToDouble(data.Rows[i].Cells[3].Value.ToString());

                if (result[x, y, z] == null)
                {
                    result[x, y, z] = new Number(0, 0, 0);
                }
                result[x, y, z].x = Convert.ToDouble(data.Rows[i].Cells[3].Value.ToString().Replace(DiplomaV2._0.utils.Properties.currentDecimalSeparator, Constants.DECIMAL_SEPARATOR));
                result[x, y, z].y = Convert.ToDouble(data.Rows[i].Cells[4].Value.ToString().Replace(DiplomaV2._0.utils.Properties.currentDecimalSeparator, Constants.DECIMAL_SEPARATOR));
                result[x, y, z].z = Convert.ToDouble(data.Rows[i].Cells[5].Value.ToString().Replace(DiplomaV2._0.utils.Properties.currentDecimalSeparator, Constants.DECIMAL_SEPARATOR));
            }
        }

        public override void readFromFile()
        {
            throw new NotImplementedException();
        }
    }
}
