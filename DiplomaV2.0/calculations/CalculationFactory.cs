using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiplomaV2._0.utils;
using DiplomaV2._0.calculations.implementations;

namespace DiplomaV2._0.calculations
{
    class CalculationFactory
    {
        public static ICalculation createCalculation(Utils.Calcs calc)
        {
            switch(calc) 
            {
                case Utils.Calcs.LAGRANGE :
                    return new LagrangeCalc(); 

                case Utils.Calcs.LINEAR :
                    return new LinearCalc();

                default :
                    return null;
            }
        }
    }
}
