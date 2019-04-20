using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA_laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;double b = 1;
            int interval = 10;
            

        }
        public static double Func(double x)
        {
            return 0.37 * Math.Pow(Math.E, Math.Sin(x));
        }

        #region Вычисление погрешности
        public static List<double> calc(int InitialInterval, double epsilon, double a, double b)
        {
            List<double> num = new List<double>();// буддут храниться все значения интеграла при разном количестве интервалов
            num.Add(Integral_left(InitialInterval, a, b));
            num.Add(Integral_left(InitialInterval * 2, a, b));
            double E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
            int c = 3;
            while (E > epsilon)
            {
                num.Add(Integral_left(InitialInterval * c, a, b));
                E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
                c++;
            }
            return num;
        }
        #endregion
        #region Вычисление интегралов
        public static double Integral_left(int interval, double a, double b)
        {
            double h = (b - a) / interval;
            double sum = 0;
            for (int i = 0; i < interval - 1; i++)
            {
                double xi = a + i * h;
                sum += Func(xi);
            }
            return sum * h;
        }
        public static double Inegral_right(int interval, double a, double b)
        {
            double h = (b - a) / interval;
            double sum = 0;
            for (int i = 1; i < interval; i++)
            {
                double xi = a + i * h;
                sum += Func(xi);
            }
            return sum * h;
        }
        public static double Integral_aver(int interval, double a, double b)
        {
            double h = (b - a) / interval;
            double sum = 0;
            for (int i = 0; i < interval - 1; i++)
            {
                double xi = (a + (i + 1) * h - (a + i * h)) / 2;
                sum += Func(xi);
            }
            return sum * h;
        }
        public static double Integral_trapezium(int interval, double a, double b)
        {
            double h = (b - a) / interval;
            double sum = 0;
            for (int i = 1; i < interval - 1; i++)
            {
                double xi = a + i * h;
                sum += Func(xi);
            }
            sum = 2 * sum + Func(a) + Func(b);
            return sum * h / 2;
        }
        public static double Integral_Simpson(int interval, double a, double b)
        {

        }
        #endregion
    }
}
