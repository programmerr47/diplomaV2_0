using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.exportCalculations.implementations
{
    class SimpleLagrange : Lagrange
    {
        private int numCountingPoints = 3;

        private Dictionary<int, Number> getAroundValues(int i, int dimension)
        {
            Dictionary<int, Number> result = new Dictionary<int, Number>();
            int leftNum = numCountingPoints / 2;
            int rightNum = numCountingPoints - leftNum;

            int index = i - 1;
            while ((index > -1) && (leftNum > 0))
            {
                if (listOfKnown.ContainsKey(index))
                {
                    result.Add(index, listOfKnown[index]);
                    leftNum--;
                }
                index--;
            }

            int lastLeftIndex = index;
            rightNum += leftNum;

            index = i + 1;
            while ((index < dimension) && (rightNum > 0))
            {
                if (listOfKnown.ContainsKey(index))
                {
                    result.Add(index, listOfKnown[index]);
                    rightNum--;
                }
                index++;
            }

            if ((rightNum > 0) && (leftNum == 0))
            {
                leftNum = rightNum;
                index = lastLeftIndex;

                while ((index > -1) && (leftNum > 0))
                {
                    if (listOfKnown.ContainsKey(index))
                    {
                        result.Add(index, listOfKnown[index]);
                        leftNum--;
                    }
                    index--;
                }
            }

            return result;
        }

        protected override Number getInterpolatedValue(int i, int dimension)
        {
            Dictionary<int, Number> aroundListOfKnown = getAroundValues(i, dimension);
            return new Number(getInterpolatedProjection(i, 0, aroundListOfKnown), getInterpolatedProjection(i, 1, aroundListOfKnown), getInterpolatedProjection(i, 2, aroundListOfKnown));
        }

        protected double getInterpolatedProjection(int i, int coord, Dictionary<int, Number> aroundListOfKnown)
        {
            double result = 0.0;

            foreach (KeyValuePair<int, Number> num in aroundListOfKnown)
            {
                result += num.Value.getCoord(coord) * getInterpolatedProjectionPart(i, num.Key, aroundListOfKnown);
            }

            return result;
        }

        protected double getInterpolatedProjectionPart(int i, int coordOfNum, Dictionary<int, Number> aroundListOfKnown)
        {
            double result = 1.0;

            foreach (KeyValuePair<int, Number> num in aroundListOfKnown)
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
