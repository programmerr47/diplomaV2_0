using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.exportCalculations
{
    interface IExportCalculation
    {
        Number[] fillValues(Number[] source);
    }
}
