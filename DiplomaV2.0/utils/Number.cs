using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.utils
{
    class Number
    {
        public Number(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double x;
        public double y;
        public double z;

        public double getCoord(int index) 
        {
            if (index == 0)
            {
                return x;
            }
            else if (index == 1)
            {
                return y;
            }
            else if (index == 2)
            {
                return z;
            }
            else throw new ArgumentOutOfRangeException("index", index, "Should be 0, 1 or 2 for x, y or z");
        }
    }
}
