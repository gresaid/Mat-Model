using System;

namespace lab3
{
    internal class Program
    {

        //y` =y -y^2*cos(x)
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

        public static void new_euler(double a, double b, double s, double eps_)
        {
            double y = 0;
            double eps;
            int n = 0;
            double y_c = 0;
            while (n != 10000)
            {
                n += 1;
                eps = eps_;

                double x0 = a;
                double y0 = b;
                double h = (b - a) / n;
                double temp_y = y0 + (h / 2) * function(x0, y0);
                double yi = y0 + h * function(x0 + (h / 2), temp_y);
                double xi = x0;
                for (int i = 0; i < n; i++)
                {
                    double dy = h * function(xi, yi);
                    xi += h;
                    y = dy + yi;
                    yi = y;
                }
                if (epsilonGet(yi, y_c, eps))
                    break;
                y_c = y;
            }

            if (n != 10000)
            {
                Console.WriteLine("Колл итераций");
                Console.WriteLine(n);
                Console.WriteLine(Math.Round(y, enumZero(eps_)));
            }
            else
                Console.WriteLine(Math.Round(y, enumZero(eps_)));
        }
        static void Main(string[] args)
        {

            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double s = Convert.ToDouble(Console.ReadLine());
            double eps = Convert.ToDouble(Console.ReadLine());
            new_euler(a, b, s, eps);
        }
    }
}
