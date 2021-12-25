using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
    {
        public static double function(double x, double y)
        {
            return y - ((y * y) * Math.Cos(x));
        }
        public static double abs(double i)
        {
            return i < 0.0 ? -i : i;
        }
        public static int enumZero(double e)
        {
            int n = 0;
            double temp = e;
            while (temp <= 1)
            {
                temp += temp * 10;
                n++;
            }
            return n;
        }
        public static bool epsilonGet(double yi, double back_y, double epsilon)
        {
            return abs(yi - back_y) < epsilon;
        }

        public static void solveApp(double a, double b,double s,double eps) {
            int n = 0;
            double eps_ = eps;
            double h = (b - a) / n;
            double x = a;
            double y = s;
            while (Math.Pow(h, 4) >= eps_)
            {
                n += 1;
                h = (b - a) / n;
            }
            for (int i=0; i < n; i++)
            {
                double k1 = h * function(x, y);
                double k2 = h * function(x + (h / 2), y + (k1 / 2));
                double k3 = h * function(x + h, y + (k2 / 2));
                double k4 = h * function(x + h, y + k3);
                double dy = (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                y += dy;
                x += h;
            }
            Console.WriteLine(n);
            Console.WriteLine(Math.Round(y, enumZero(eps_)));
        }

        static void Main(string[] args)
        {
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double s = Convert.ToDouble(Console.ReadLine());
            double eps = Convert.ToDouble(Console.ReadLine());
            solveApp(a, b, s, eps);
        }
    }
}
    