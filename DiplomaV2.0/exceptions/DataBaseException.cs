using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.exceptions
{
    public class DataBaseException : Exception
    {
        public DataBaseException(string message) : base(message)
        {
        }


    }
}
