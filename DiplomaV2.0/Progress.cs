using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.utils
{
    class Progress
    {
        private static Progress INSTANCE = new Progress();

        private double progress;

        public Progress()
        {
            progress = 0;
        }

        public static Progress getINSTANCE()
        {
            return INSTANCE;
        }

        public void addToProgress(double progressStep)
        {
            progress += progressStep;
            if (progress > 100) 
                progress = 100;
        }

        public int getGlobalProgress()
        {
            return (int)progress;
        }

        public void clearProgress()
        {
            progress = 0;
        }
    }
}
