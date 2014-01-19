using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.calculations.implementations
{
    abstract class DiffPointsCalc : ICalculation
    {
        public abstract void calculate();

        protected double[,] checkDiffPointsInSource(double[,] source) {
            return source;
        }
    }
}
