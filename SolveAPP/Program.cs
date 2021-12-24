using System;

namespace SolveAPP
{
    internal class Program
    {
        //y` =y -y^2*cos(x)

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
        public static bool epsilonGet(double back_y, double yi, double epsilon)
        {
            return abs(yi - back_y) < epsilon;
        }
        public static void solveFunc(double x0, double b, double y0, double eps_)
        {
            double h, yb=0, eps;
            int n = 1;
            double y = 0;
            eps = eps_;
            while (n != 10000)
            {
                n++;
                double yi = y0;
                double xi = x0;
                h = (b - x0) / n;
                double dy;
               for (int n_ = 1; n_ <= n; n_++)
                {
                    xi += h;
                    dy = h * (yi - yi * yi * Math.Cos(xi));
                    y = Convert.ToDouble(yi + dy);
                    yi = y;
                }
                if (epsilonGet(y, yb, eps)) break;
                yb = y;
            }
            if (n == 10000)
            {
                Console.WriteLine("Ошибка, точность не достигнута");
                Console.WriteLine(Math.Round(y, enumZero(eps)));
            }
            else
            {
                Console.WriteLine("приближенное значение ");
                Console.WriteLine(Math.Round(y, enumZero(eps)));
                Console.WriteLine(n);
            }
        }
        static void Main(string[] args)
        {
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double s = Convert.ToDouble(Console.ReadLine());
            double eps = Convert.ToDouble(Console.ReadLine());
            solveFunc(a, b, s, eps);
        }
    }
}
