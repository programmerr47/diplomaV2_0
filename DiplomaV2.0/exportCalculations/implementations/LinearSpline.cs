using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.exportCalculations.implementations
{
    class LinearSpline : IExportCalculation
    {

        public Number[] fillValues(Number[] source)
        {
            int last = -1;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != null)
                {
                    if (last == -1)
                    {
                        for (int index = 0; index < i; index++)
                        {
                            source[index] = new Number(source[i].x, source[i].y, source[i].z);
                        }
                    }
                    else
                    {
                        double ax = source[last].x;
                        double bx = source[i].x;
                        double ay = source[last].y;
                        double by = source[i].y;
                        double az = source[last].z;
                        double bz = source[i].z;
                        for (int index = last + 1; index < i; index++)
                        {
                            double k1 = (1.0 * index - last) / (i - last);
                            double k2 = (i - 1.0 * index) / (i - last);

                            source[index] = new Number(ax * k2 + bx * k1,
                                                             ay * k2 + by * k1,
                                                             az * k2 + bz * k1);
                        }
                    }

                    last = i;
                }
            }

            if (last != -1)
            {
                for (int index = last; index < source.Length; index++)
                {
                    source[index] = new Number(source[last].x, source[last].y, source[last].z);
                }
            }

            return source;
        }
    }
}
