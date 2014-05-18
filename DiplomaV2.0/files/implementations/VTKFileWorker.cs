using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using DiplomaV2._0.utils;
using System.Collections;
using DiplomaV2._0.exportCalculations;

namespace DiplomaV2._0.files
{
    class VTKFileWorker : AbstractFileWorker
    {

        private Number[, ,] result;
        private static int originX = 0;
        private static int originY = 0;
        private static int originZ = 0;
        private static int spacingX = 1;
        private static int spacingY = 1;
        private static int spacingZ = 1;
        private static int method = ExportCalculationFactory.LINEAR_SPLINE;

        public VTKFileWorker(Form1 pf) : base(pf) {}

        public override void writeInFile()
        {
            String loadingText = parentForm.getLoadingLabel().Text;
            parentForm.Invoke(new ThreadStart(delegate
            {
                parentForm.getLoadingLabel().Text = "Данные экспортируются";
                parentForm.showLoadingBar();
            }));

            //analyse parameters
            DataGridView dataA = parentForm.getDatabaseA();
            DataGridView dataB = parentForm.getDatabaseB();

            result = copyFromDataGridToNet(dataA, dataB, parameters);
            waveForThirdCoordinate(result, method);
            waveForSecondCoordinate(result, method);
            waveForFirstCoordinate(result, method);
            fillAnother(result);
            writeArrayInFile(result);

            parentForm.Invoke(new ThreadStart(delegate
            {
                parentForm.hideLoadingBar();
                parentForm.getLoadingLabel().Text = loadingText;
                if (listener != null)
                {
                    listener.onComplete();
                }
            }));
        }

        public static Number[,,] iterpolate(DataGridView dataA, int method)
        {
            Number[,,] net = copyFromDataGridToNet(dataA, null, new []{method});

            waveForThirdCoordinate(net, method);
            waveForSecondCoordinate(net, method);
            waveForFirstCoordinate(net, method);
            fillAnother(net);

            return net;
        }

        public static int getOriginX()
        {
            return originX;
        }

        public static int getOriginY()
        {
            return originY;
        }

        public static int getOriginZ()
        {
            return originZ;
        }

        private static Number[,,] fillAnother(Number[,,] net)
        {
            for (int x = 0; x < net.GetLength(0); x++)
            {
                for (int y = 0; y < net.GetLength(1); y++)
                {
                    for (int z = 0; z < net.GetLength(2); z++)
                    {
                        if (net[x, y, z] == null)
                        {
                            net[x, y, z] = new Number(0, 0, 0);
                        }
                    }
                }
            }

            return net;
        }

        private static Number[,,] waveForThirdCoordinate(Number[,,] net, int interpolateMethod)
        {
            for (int x = 0; x < net.GetLength(0); x++)
            {
                for (int y = 0; y < net.GetLength(1); y++)
                {
                    Number[] row = new Number[net.GetLength(2)];
                    bool hasNumbers = false;
                    for (int i = 0; i < net.GetLength(2); i++)
                    {
                        row[i] = net[x, y, i];
                        hasNumbers = hasNumbers || (net[x, y, i] != null);
                    }

                    if (hasNumbers)
                    {
                        IExportCalculation calculation = ExportCalculationFactory.getCalculation(interpolateMethod);
                        row = calculation.fillValues(row);
                    }

                    for (int i = 0; i < net.GetLength(2); i++)
                    {
                        net[x, y, i] = row[i];
                    }
                }
            }

            return net;
        }

        private static Number[, ,] waveForSecondCoordinate(Number[, ,] net, int interpolateMethod)
        {
            for (int x = 0; x < net.GetLength(0); x++)
            {
                for (int z = 0; z < net.GetLength(2); z++)
                {
                    Number[] row = new Number[net.GetLength(1)];
                    bool hasNumbers = false;
                    for (int i = 0; i < net.GetLength(1); i++)
                    {
                        row[i] = net[x, i, z];
                        hasNumbers = hasNumbers || (net[x, i, z] != null);
                    }

                    if (hasNumbers)
                    {
                        IExportCalculation calculation = ExportCalculationFactory.getCalculation(interpolateMethod);
                        row = calculation.fillValues(row);
                    }

                    for (int i = 0; i < net.GetLength(1); i++)
                    {
                        net[x, i, z] = row[i];
                    }
                }
            }

            return net;
        }

        private static Number[,,] waveForFirstCoordinate(Number[, ,] net, int interpolateMethod)
        {
            for (int z = 0; z < net.GetLength(2); z++)
            {
                for (int y = 0; y < net.GetLength(1); y++)
                {
                    Number[] row = new Number[net.GetLength(0)];
                    bool hasNumbers = false;
                    for (int i = 0; i < net.GetLength(0); i++)
                    {
                        row[i] = net[i, y, z];
                        hasNumbers = hasNumbers || (net[i, y, z] != null);
                    }

                    if (hasNumbers)
                    {
                        IExportCalculation calculation = ExportCalculationFactory.getCalculation(interpolateMethod);
                        row = calculation.fillValues(row);
                    }

                    for (int i = 0; i < net.GetLength(0); i++)
                    {
                        net[i, y, z] = row[i];
                    }
                }
            }

            return net;
        }

        private static Number[,,] copyFromDataGridToNet(DataGridView dataA, DataGridView dataB, int[] parameters) 
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
                if (parameters.Length > 1)
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
                    method = parameters[9];
                }
                else
                {
                    method = parameters[0];
                }
            }

            int remainX = (((maxX + 1 - originX) % spacingX) == 0) ? 0 : 1;
            int remainY = (((maxY + 1 - originY) % spacingY) == 0) ? 0 : 1;
            int remainZ = (((maxZ + 1 - originZ) % spacingZ) == 0) ? 0 : 1;
            Number[, ,] resultArray = new Number[(maxX + 1 - originX) / spacingX + remainX, (maxY + 1 - originY) / spacingY + remainY, (maxZ + 1 - originZ) / spacingZ + remainZ];

            copyDataGridToNet(dataA, resultArray);
            copyDataGridToNet(dataB, resultArray);

            return resultArray;
        }

        public static void writeArrayInFile(Number[,,] net)
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
            streamwriter.WriteLine("DIMENSIONS " + net.GetLength(0) + " " + net.GetLength(1) + " " + net.GetLength(2));
            streamwriter.WriteLine("ORIGIN " + originX + " " + originY + " " + originZ);
            streamwriter.WriteLine("SPACING " + spacingX + " " + spacingY + " " + spacingZ);
            streamwriter.WriteLine("POINT_DATA " + net.Length);
            streamwriter.WriteLine("VECTORS vectors double");

            int column = 0;
            string line = "";
            for (int z = 0; z < net.GetLength(2); z++)
            {
                for (int y = 0; y < net.GetLength(1); y++)
                {
                    for (int x = 0; x < net.GetLength(0); x++)
                    {
                        line += net[x, y, z].x.ToString().Replace(Constants.DECIMAL_SEPARATOR, ".") + 
                                " " +
                                net[x, y, z].y.ToString().Replace(Constants.DECIMAL_SEPARATOR, ".") + 
                                " " +
                                net[x, y, z].z.ToString().Replace(Constants.DECIMAL_SEPARATOR, ".");
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

        private static int getMaxFromDataGrid(DataGridView data, int currentMax, int coord)
        {
            if (data != null)
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
            }

            return currentMax;
        }

        private static int getMinFromDataGrid(DataGridView data, int currentMin, int coord)
        {
            if (data != null)
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
            }

            return currentMin;
        }

        private static void copyDataGridToNet(DataGridView data, Number[, ,] result)
        {
            if (data != null)
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

                    try
                    {
                        result[x, y, z].x =
                            Convert.ToDouble(
                                data.Rows[i].Cells[3].Value.ToString()
                                    .Replace(DiplomaV2._0.utils.Properties.currentDecimalSeparator,
                                        Constants.DECIMAL_SEPARATOR));
                        result[x, y, z].y =
                            Convert.ToDouble(
                                data.Rows[i].Cells[4].Value.ToString()
                                    .Replace(DiplomaV2._0.utils.Properties.currentDecimalSeparator,
                                        Constants.DECIMAL_SEPARATOR));
                        result[x, y, z].z =
                            Convert.ToDouble(
                                data.Rows[i].Cells[5].Value.ToString()
                                    .Replace(DiplomaV2._0.utils.Properties.currentDecimalSeparator,
                                        Constants.DECIMAL_SEPARATOR));
                    }
                    catch (NullReferenceException e)
                    {
                        //ignored
                    }
                }
            }
        }

        public override void readFromFile()
        {
            throw new NotImplementedException();
        }
    }
}
