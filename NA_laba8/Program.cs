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
            //double epsilon = Math.Pow(Math.E, -3);
            double epsilon = Math.Pow(10, -3);
            Console.WriteLine("Left\n"+Output(calc_left(interval, epsilon, a, b), interval));
            Console.WriteLine("Right\n" + Output(calc_right(interval, epsilon, a, b), interval));
            Console.WriteLine("Average\n" + Output(calc_aver(interval, epsilon, a, b), interval));
            Console.WriteLine("Trapzium\n" + Output(calc_trapezium(interval, epsilon, a, b), interval));
            Console.WriteLine("Simpson\n" + Output(calc_Simpson(interval, epsilon, a, b), interval));
            Console.ReadLine();
        }
        public static double Func(double x)
        {
             //return x * Math.Pow(Math.E, x);
             return 0.37 * Math.Pow(Math.E, Math.Sin(x));
        }
        public static string Output(List<double> ls, int interval)
        {
            string s = "";
            for(int i = 0; i < ls.Count; i++)
            {
                s += (i+1).ToString()+"\t"+ interval.ToString() + "\t" + ls[i] + "\n";
                interval *= 2;
            }
            return s;
        }
        #region Вычисление погрешности
        public static List<double> calc_left(int InitialInterval, double epsilon, double a, double b)
        {
            List<double> num = new List<double>();// буддут храниться все значения интеграла при разном количестве интервалов
            num.Add(Integral_left(InitialInterval, a, b));
            InitialInterval *= 2;
            num.Add(Integral_left(InitialInterval, a, b));
            double E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
            while (E > epsilon)
            {
                InitialInterval *= 2;
                num.Add(Integral_left(InitialInterval, a, b));
                E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
            }
            return num;
        }
        public static List<double> calc_right(int InitialInterval, double epsilon, double a, double b)
        {
            List<double> num = new List<double>();// буддут храниться все значения интеграла при разном количестве интервалов
            num.Add(Integral_right(InitialInterval, a, b));
            InitialInterval *= 2;
            num.Add(Integral_right(InitialInterval, a, b));
            double E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
            while (E > epsilon)
            {
                InitialInterval *= 2;
                num.Add(Integral_right(InitialInterval, a, b));
                E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
            }
            return num;
        }
        public static List<double> calc_aver(int InitialInterval, double epsilon, double a, double b)
        {
            List<double> num = new List<double>();// буддут храниться все значения интеграла при разном количестве интервалов
            num.Add(Integral_aver(InitialInterval, a, b));
            InitialInterval *= 2;
            num.Add(Integral_aver(InitialInterval , a, b));
            double E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
            while (E > epsilon)
            {
                InitialInterval *= 2;
                num.Add(Integral_aver(InitialInterval , a, b));
                E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
            }
            return num;
        }
        public static List<double> calc_trapezium(int InitialInterval, double epsilon, double a, double b)
        {
            List<double> num = new List<double>();// буддут храниться все значения интеграла при разном количестве интервалов
            num.Add(Integral_trapezium(InitialInterval, a, b));
            InitialInterval *= 2;
            num.Add(Integral_trapezium(InitialInterval, a, b));
            double E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
            while (E > epsilon)
            {
                InitialInterval *= 2;
                num.Add(Integral_trapezium(InitialInterval, a, b));
                E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
              }
            return num;
        }
        public static List<double> calc_Simpson(int InitialInterval, double epsilon, double a, double b)
        {
            List<double> num = new List<double>();// буддут храниться все значения интеграла при разном количестве интервалов
            num.Add(Integral_Simpson(InitialInterval, a, b));
            InitialInterval *= 2;
            num.Add(Integral_Simpson(InitialInterval , a, b));
            double E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
         
            while (E > epsilon)
            {
                InitialInterval *= 2;
                num.Add(Integral_Simpson(InitialInterval , a, b));
                E = Math.Abs(num[num.Count - 1] - num[num.Count - 2]);
            }
            return num;
        }
        #endregion
        #region Вычисление интегралов
        public static double Integral_left(int interval, double a, double b)
        {
            double h = (b - a) / interval;
            double sum = 0;
            for (int i = 0; i < interval; i++)
            {
                double xi = a + i * h;
                sum += Func(xi);
            }
            return sum * h;
        }
        public static double Integral_right(int interval, double a, double b)
        {
            double h = (b - a) / interval;
            double sum = 0;
            for (int i = 1; i < interval+1; i++)
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
            for (int i = 0; i < interval ; i++)
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
            for (int i = 1; i < interval; i++)
            {
                double xi = a + i * h;
                sum += Func(xi);
            }
            sum = 2 * sum + Func(a) + Func(b);
            return sum * h / 2;
        }
        public static double Integral_Simpson(int interval, double a, double b)
        {
            double h = (b - a) / interval;
            int k = interval / 2;
            double sum = 0;
            for (int i = 0; i < k ; i++)
            {
                double xi = a + (2*i+1) * h;
                sum += Func(xi);
            }
            double sum2 = 0;
            for(int i = 1; i < k ; i++)
            {
                double xi = a + 2 * i * h;
                sum2 += Func(xi);
            }
            sum = sum * 4 + sum2 * 2 + Func(a) + Func(b);
            return sum * h / 3;
        }
        #endregion
    }
}
