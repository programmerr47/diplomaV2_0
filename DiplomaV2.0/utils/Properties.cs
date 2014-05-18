using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaV2._0.exportCalculations;

namespace DiplomaV2._0.utils
{
    public class Properties
    {
        public static string currentNamePropertyFile = "properties.dip";
        public static string currentDecimalSeparator = ".";
        public static string currentFileName = "test2.csv";
        public static string directoryOfApp = Directory.GetCurrentDirectory() + "\\";
        public static string currentDirectory = Directory.GetCurrentDirectory() + "\\";
        public static string currentPathToFile = currentDirectory + currentFileName;
        public static int currentCalculateMethod = ExportCalculationFactory.LINEAR_SPLINE;
        public static string currentPathToParaview = "C:\\Program Files\\ParaView 4.0.1\\paraview.exe";
    }
}
