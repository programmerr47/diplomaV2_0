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
            if ((getExtension(path) != null) && (!getExtension(path).ToLower().Equals("vtk")))
            {
                utils.Properties.currentFileName = path.Substring(index + 1);
            }
            utils.Properties.currentDirectory = path.Substring(0, index);
        }

        private string getExtension(string path) 
        {
            if (path.LastIndexOf(".") != -1)
            {
                return path.Substring(path.LastIndexOf(".") + 1);
            }
            else
            {
                return null;
            }
        }

        public abstract void writeInFile(int[] parameters);
        public abstract void readFromFile();
    }
}
