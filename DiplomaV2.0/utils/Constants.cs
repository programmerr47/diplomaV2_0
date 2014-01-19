using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.utils
{
    public class Constants
    {
        public const int X = 0;
        public const int Y = 1;
        public const int Z = 2;
        public const int B_X = 3;
        public const int B_Y = 4;
        public const int B_Z = 5;
        public const string fileFilter = "Tables(*.csv)|*.csv";
        public const string exportFileFilter = "Paraview(*.vtk)|*.vtk";
        public const string tableSeparateLine = "NEXT";

        public static string DECIMAL_SEPARATOR = NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
    }
}
