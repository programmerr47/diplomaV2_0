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
        private int originX = 0;
        private int originY = 0;
        private int originZ = 0;
        private int spacingX = 1;
        private int spacingY = 1;
        private int spacingZ = 1;

        public VTKFileWorker(Form1 pf) : base(pf) {}

        public override void writeInFile(int[] parameters)
        {
            //analyse parameters
            DataGridView dataA = parentForm.getDatabaseA();
            DataGridView dataB = parentForm.getDatabaseB();

            generateSeqs();
            result = copyFromDataGridToNet(dataA, dataB, parameters);
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

                                    result[x, y, index] = new Number(ax * k2 + bx * k1,
                                                                     ay * k2 + by * k1,
                                                                     az * k2 + bz * k1);
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

                                    result[x, index, z] = new Number(ax * k2 + bx * k1,
                                                                     ay * k2 + by * k1,
                                                                     az * k2 + bz * k1);
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

                                    result[index, y, z] = new Number(ax * k2 + bx * k1,
                                                                     ay * k2 + by * k1,
                                                                     az * k2 + bz * k1);
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

        private Number[,,] copyFromDataGridToNet(DataGridView dataA, DataGridView dataB, int[] parameters) 
        {
            int maxX = 0;
            int maxY = 0;
            int maxZ = 0;

            int minX = Int32.MaxValue;
            int minY = Int32.MaxValue;
            int minZ = Int32.MaxValue;

            maxX = getMaxFromDataGrid(dataA, maxX, 0);
            maxX = getMaxFromDataGrid(dataB, maxX, 0);

            maxY = getMaxFromDataGrid(dataA, maxY, 1);
            maxY = getMaxFromDataGrid(dataB, maxY, 1);

            maxZ = getMaxFromDataGrid(dataA, maxZ, 2);
            maxZ = getMaxFromDataGrid(dataB, maxZ, 2);

            minX = getMinFromDataGrid(dataA, minX, 0);
            minX = getMinFromDataGrid(dataB, minX, 0);

            minY = getMinFromDataGrid(dataA, minY, 1);
            minY = getMinFromDataGrid(dataB, minY, 1);

            minZ = getMinFromDataGrid(dataA, minZ, 2);
            minZ = getMinFromDataGrid(dataB, minZ, 2);

            originX = minX;
            originY = minY;
            originZ = minZ;

            if (parameters != null)
            {
                maxX = parameters[0] - 1 + parameters[3];
                maxY = parameters[1] - 1 + parameters[4];
                maxZ = parameters[2] - 1 + parameters[5];
                originX = parameters[3];
                originY = parameters[4];
                originZ = parameters[5];
                spacingX = parameters[6];
                spacingY = parameters[7];
                spacingZ = parameters[8];
            }

            int remainX = (((maxX + 1 - originX) % spacingX) == 0) ? 0 : 1;
            int remainY = (((maxY + 1 - originY) % spacingY) == 0) ? 0 : 1;
            int remainZ = (((maxZ + 1 - originZ) % spacingZ) == 0) ? 0 : 1;
            Number[, ,] resultArray = new Number[(maxX + 1 - originX) / spacingX + remainX, (maxY + 1 - originY) / spacingY + remainY, (maxZ + 1 - originZ) / spacingZ + remainZ];

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
            streamwriter.WriteLine("ORIGIN " + originX + " " + originY + " " + originZ);
            streamwriter.WriteLine("SPACING " + spacingX + " " + spacingY + " " + spacingZ);
            streamwriter.WriteLine("POINT_DATA " + result.Length);
            streamwriter.WriteLine("VECTORS vectors double");

            int column = 0;
            string line = "";
            for (int z = 0; z < result.GetLength(2); z++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    for (int x = 0; x < result.GetLength(0); x++)
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

        private int getMinFromDataGrid(DataGridView data, int currentMin, int coord)
        {
            int currentElement;
            for (int i = 0; i < data.RowCount - 1; i++)
            {
                currentElement = Int32.Parse(data.Rows[i].Cells[coord].Value.ToString());
                if (currentElement < currentMin)
                {
                    currentMin = currentElement;
                }
            }

            return currentMin;
        }

        private void copyDataGridToNet(DataGridView data, Number[, ,] result)
        {
            int x;
            int y;
            int z;
            for (int i = 0; i < data.RowCount - 1; i++)
            {
                x = Int32.Parse(data.Rows[i].Cells[0].Value.ToString()) - originX;
                y = Int32.Parse(data.Rows[i].Cells[1].Value.ToString()) - originY;
                z = Int32.Parse(data.Rows[i].Cells[2].Value.ToString()) - originZ;

                int p = data.Rows[i].Cells.Count;

                if (x % spacingX == 0)
                {
                    x = x / spacingX;
                }
                else
                {
                    break;
                }

                if (y % spacingY == 0)
                {
                    y = y / spacingY;
                }
                else
                {
                    break;
                }

                if (z % spacingZ == 0)
                {
                    z = z / spacingZ;
                }
                else
                {
                    break;
                }

                if ((x >= result.GetLength(0)) ||
                    (y >= result.GetLength(1)) ||
                    (z >= result.GetLength(2)))
                {
                    break;
                }

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
