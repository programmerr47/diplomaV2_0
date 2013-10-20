using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static Utils.Calcs currentCalculateMethod = Utils.Calcs.LAGRANGE;
    }
}
