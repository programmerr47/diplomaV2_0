using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DiplomaV2._0.utils;

namespace DiplomaV2._0.calculations.implementations
{
    class LinearCalc : DiffPointsCalc
    {
        double[,] aPoints;
        double[,] bPoints;

        public LinearCalc() {}

        public double calculateInduction(int coord, double bCoord) 
        {
            double minmax = aPoints[0, coord];
            double maxmin = aPoints[0, coord];
            int minmaxIndex = 0;
            int maxminIndex = 0;

            for (int i = 1; i < aPoints.GetLength(0); i++)
            {
                if (maxmin < aPoints[i, coord])
                {
                    maxmin = aPoints[i, coord];
                    maxminIndex = i;
                }
                else if (minmax > aPoints[i, coord])
                {
                    minmax = aPoints[i, coord];
                    minmaxIndex = i;
                }
            }

            if (maxmin == minmax)
            {
                double result = 0;
                for (int i = 0; i < aPoints.GetLength(0); i++)
                    result += aPoints[i, coord];

                return Math.Round(result / aPoints.GetLength(0), 3);
            }
            else
            {
                if ((bCoord < maxmin) && (bCoord > minmax))
                {
                    for (int i = 0; i < aPoints.GetLength(0); i++)
                    {
                        if ((aPoints[i, coord] >= bCoord) && (aPoints[i, coord] < maxmin))
                        {
                            maxmin = aPoints[i, coord];
                            maxminIndex = i;
                        }
                        else if ((aPoints[i, coord] <= bCoord) && (aPoints[i, coord] > minmax))
                        {
                            minmax = aPoints[i, coord];
                            minmaxIndex = i;
                        }
                    }
                }
                else if (bCoord > maxmin)
                {
                    for (int i = 0; i < aPoints.GetLength(0); i++)
                    {
                        if ((minmax <= aPoints[i, coord]) && (aPoints[i, coord] < maxmin))
                        {
                            minmax = aPoints[i, coord];
                            minmaxIndex = i;
                        }
                    }
                }
                else if (bCoord < minmax)
                {
                    for (int i = 0; i < aPoints.GetLength(0); i++)
                    {
                        if ((maxmin >= aPoints[i, coord]) && (minmax < aPoints[i, coord]))
                        {
                            maxmin = aPoints[i, coord];
                            maxminIndex = i;
                        }
                    }
                }

                double result = ((bCoord - minmax)/(maxmin - minmax))*(aPoints[maxminIndex, coord + 3] - aPoints[minmaxIndex, coord + 3]) + aPoints[minmaxIndex, coord + 3];
                return Math.Round(result, 3);
            }
        }

        public override void calculate()
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
    }
}
