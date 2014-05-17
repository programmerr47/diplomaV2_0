using System.Threading;
using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.files
{
    public abstract class AbstractFileWorker : IFileWorker
    {
        protected Form1 parentForm;

        public AbstractFileWorker(Form1 parentForm)
        {
            this.parentForm = parentForm;
        }


        public void parseFileName()
        {
            string path = utils.Properties.currentPathToFile;
            int index = path.Length - 1;
            while ((path[index] != '\\') && (index > 0))
                index--;
            if ((Utils.getExtension(path) != null) && (Utils.getExtension(path).ToLower().Equals("csv")))
            {
                utils.Properties.currentFileName = path.Substring(index + 1);
            }
            utils.Properties.currentDirectory = path.Substring(0, index);
        }

        public abstract void writeInFile(int[] parameters);
        public abstract void readFromFile();
        public void readFromFileAsync()
        {
            Thread t1 = new Thread(readFromFile);
            t1.Start();
        }
    }
}
