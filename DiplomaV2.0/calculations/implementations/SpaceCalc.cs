using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.calculations.implementations
{
    class SpaceCalc : ICalculation
    {
        double[,] aPoints;
        double[,] bPoints;

        public SpaceCalc() { }

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

        private double calculateInduction(int coord, double bCoord)
        {
            return 0;
        }
    }
}
