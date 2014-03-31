using DiplomaV2._0.exportCalculations.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.exportCalculations
{
    class ExportCalculationFactory
    {
        public const int LINEAR_SPLINE = 0;
        public const int LAGRANGE = 1;
        public const int SIMPLE_LAGRANGE = 2;
        public const int CUBIC_SPLINE = 3;

        public static IExportCalculation getCalculation(int method)
        {
            switch (method)
            {
                case LINEAR_SPLINE:
                    return new LinearSpline();

                case LAGRANGE:
                    return new Lagrange();

                case SIMPLE_LAGRANGE:
                    return new SimpleLagrange();

                case CUBIC_SPLINE:
                    return new CubicSpline();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
