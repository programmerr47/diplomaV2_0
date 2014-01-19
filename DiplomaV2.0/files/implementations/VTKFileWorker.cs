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
            public double x;
            public double y;
            public double z;
        }

        private Number[, ,] result;
        private Number[, ,] oneSeqRectangle; 

        public VTKFileWorker(Form1 pf) : base(pf) {}

        public override void writeInFile()
        {
            DataGridView dataA = parentForm.getDatabaseA();
            DataGridView dataB = parentForm.getDatabaseB();

            result = copyFromDataGridToNet(dataA, dataB);
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

            copyDataGridToNet(dataA, resultArray);
            copyDataGridToNet(dataA, resultArray);

            int p = resultArray.Length;

            return resultArray;
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
                    result[x, y, z] = new Number();
                }
                result[x, y, z].x = Convert.ToDouble(data.Rows[i].Cells[3].Value.ToString());
                result[x, y, z].y = Convert.ToDouble(data.Rows[i].Cells[4].Value.ToString());
                result[x, y, z].z = Convert.ToDouble(data.Rows[i].Cells[5].Value.ToString());
            }
        }

        public override void readFromFile()
        {
            throw new NotImplementedException();
        }
    }
}
