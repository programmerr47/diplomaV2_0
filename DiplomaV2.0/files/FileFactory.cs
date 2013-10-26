using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.files
{
    class FileFactory
    {
        public static IFileWorker createWorker(Utils.Formats calc, Form1 parentForm)
        {
            switch (calc)
            {
                case Utils.Formats.CSV:
                    return new CSVFileWorker(parentForm);

                case Utils.Formats.PROPERTY:
                    return new PropertyFileWorker(parentForm);

                case Utils.Formats.VTK:
                    return new VTKFileWorker(parentForm);

                default:
                    return null;
            }
        }
    }
}
