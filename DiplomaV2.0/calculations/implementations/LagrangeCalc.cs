using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiplomaV2._0.utils;

namespace DiplomaV2._0.calculations.implementations
{
    class LagrangeCalc : ICalculation
    {
        private double[,] aPoints;
        private double[,] bPoints;

        public LagrangeCalc() {}

        public void calculate()
        {
            aPoints = Database.getINSTANCE().getAPoints();
            bPoints = Database.getINSTANCE().getBPointsCoord();
            double[,] result = new double[bPoints.GetLength(0), 3];

            double progressStep = 25.0 / bPoints.GetLength(0);
            Stopwatch sw = new Stopwatch();

            for (int bIndex = 0; bIndex < bPoints.GetLength(0); bIndex++)
            {
                sw.Start();
                //x
                result[bIndex, Constants.X] = calculateInduction(Constants.X, bPoints[bIndex, Constants.X]);

                //y
                result[bIndex, Constants.Y] = calculateInduction(Constants.Y, bPoints[bIndex, Constants.Y]);

                //z
                result[bIndex, Constants.Z] = calculateInduction(Constants.Z, bPoints[bIndex, Constants.Z]);
                while (sw.ElapsedMilliseconds < (20.0 * progressStep)) { }
                sw.Reset();

                Progress.getINSTANCE().addToProgress(progressStep);
            }

            Database.getINSTANCE().setBPointsInd(result);
        }

        private double calculateInduction(int coord, double value)
        {
            double result = 0.0;

            for (int i = 0; i < aPoints.GetLength(0); i++)
            {
                result += aPoints[i, coord + 3] * calculatePartInduction(coord, i, value);
            }

            return Math.Round(result, 3);
        }

        private double calculatePartInduction(int coord, int i, double value)
        {
            double result = 1.0;

            for (int j = 0; j < aPoints.GetLength(0); j++)
            {
                if (i != j)
                    result *= (value - aPoints[j, coord]) / (aPoints[i, coord] - aPoints[j, coord]);
            }
            
            return result;
        }
    }
}
