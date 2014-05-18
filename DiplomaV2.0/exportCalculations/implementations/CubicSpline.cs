using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.exportCalculations.implementations
{
    class CubicSpline : IExportCalculation
    {
        public struct SplineTuple
        {
            public double a, b, c, d, x;
        }

        // Построение сплайна
        // x - узлы сетки, должны быть упорядочены по возрастанию, кратные узлы запрещены
        // y - значения функции в узлах сетки
        // n - количество узлов сетки
        public SplineTuple[] BuildSpline(double[] x, double[] y, int n)
        {
            // Инициализация массива сплайнов
            SplineTuple[] splines = new SplineTuple[n];
            for (int i = 0; i < n; ++i)
            {
                splines[i].x = x[i];
                splines[i].a = y[i];
            }
            splines[0].c = splines[n - 1].c = 0.0;

            if (n > 1)
            {
                double[] alpha = new double[n - 1];
                double[] beta = new double[n - 1];
                alpha[0] = beta[0] = 0.0;
                for (int i = 1; i < n - 1; ++i)
                {
                    double hi = x[i] - x[i - 1];
                    double hi1 = x[i + 1] - x[i];
                    double A = hi;
                    double C = 2.0 * (hi + hi1);
                    double B = hi1;
                    double F = 6.0 * ((y[i + 1] - y[i]) / hi1 - (y[i] - y[i - 1]) / hi);
                    double z = (A * alpha[i - 1] + C);
                    alpha[i] = -B / z;
                    beta[i] = (F - A * beta[i - 1]) / z;
                }

                for (int i = n - 2; i > 0; --i)
                {
                    splines[i].c = alpha[i] * splines[i + 1].c + beta[i];
                }

                for (int i = n - 1; i > 0; --i)
                {
                    double hi = x[i] - x[i - 1];
                    splines[i].d = (splines[i].c - splines[i - 1].c) / hi;
                    splines[i].b = hi * (2.0 * splines[i].c + splines[i - 1].c) / 6.0 + (y[i] - y[i - 1]) / hi;
                }
            }

            return splines;
        }

        // Вычисление значения интерполированной функции в произвольной точке
        public double Interpolate(double x, SplineTuple[] splines)
        {
            if (splines == null)
            {
                return double.NaN;
            }

            int n = splines.Length;
            SplineTuple s;

            if (x <= splines[0].x)
            {
                s = splines[0];
            }
            else if (x >= splines[n - 1].x)
            {
                s = splines[n - 1];
            }
            else
            {
                int i = 0;
                int j = n - 1;
                while (i + 1 < j)
                {
                    int k = i + (j - i) / 2;
                    if (x <= splines[k].x)
                    {
                        j = k;
                    }
                    else
                    {
                        i = k;
                    }
                }
                s = splines[j];
            }

            double dx = x - s.x;
            return s.a + (s.b + (s.c / 2.0 + s.d * dx / 6.0) * dx) * dx;
        }

        public Number[] fillValues(Number[] source)
        {
            List<double> Bx = new List<double>();
            List<double> By = new List<double>();
            List<double> Bz = new List<double>();
            List<double> x = new List<double>();
            int n;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != null)
                {
                    x.Add(i);
                    Bx.Add(source[i].x);
                    By.Add(source[i].y);
                    Bz.Add(source[i].z);
                }
            }

            n = x.Count();

            SplineTuple[] splinesX = BuildSpline(x.ToArray(), Bx.ToArray(), n);
            SplineTuple[] splinesY = BuildSpline(x.ToArray(), By.ToArray(), n);
            SplineTuple[] splinesZ = BuildSpline(x.ToArray(), Bz.ToArray(), n);

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == null)
                {
                    source[i] = new Number(Interpolate(i, splinesX), Interpolate(i, splinesY), Interpolate(i, splinesZ));
                }
            }

            return source;
        }
    }
}
