using DiplomaV2._0.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.exportCalculations.implementations
{
    class Lagrange : IExportCalculation
    {
        protected Dictionary<int, Number> listOfKnown = new Dictionary<int, Number>();

        protected void fillKnownList(Number[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != null)
                {
                    listOfKnown.Add(i, source[i]);
                }
            }
        }

        public Number[] fillValues(Number[] source)
        {
            fillKnownList(source);

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == null)
                {
                    source[i] = getInterpolatedValue(i, source.Length);
                }
            }

            return source;
        }

        protected virtual Number getInterpolatedValue(int i, int dimension) 
        {
            return new Number(getInterpolatedProjection(i, 0, dimension), getInterpolatedProjection(i, 1, dimension), getInterpolatedProjection(i, 2, dimension));
        }

        protected double getInterpolatedProjection(int i, int coord, int dimension)
        {
            double result = 0.0;

            foreach (KeyValuePair<int, Number> num in listOfKnown)
            {
                result += num.Value.getCoord(coord) * getInterpolatedProjectionPart(i, num.Key);
            }

            return result;
        }

        protected double getInterpolatedProjectionPart(int i, int coordOfNum)
        {
            double result = 1.0;

            foreach (KeyValuePair<int, Number> num in listOfKnown)
            {
                if (num.Key != coordOfNum)
                {
                    result *= (i - num.Key) * 1.0 / (1.0 * coordOfNum - num.Key);
                }
            }

            return result;
        }
    }
}
