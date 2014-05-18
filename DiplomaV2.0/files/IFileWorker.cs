using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.files
{
    public interface IFileWorker
    {
        void parseFileName();
        void writeInFile();
        void readFromFile();
        void readFromFileAsync(OnOperationCompletedListener listener);
        void writeInFileAsync(OnOperationCompletedListener listener);
        void setParameters(int[] parameters);
    }
}
