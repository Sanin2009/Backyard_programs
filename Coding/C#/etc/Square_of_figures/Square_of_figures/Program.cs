using System;

// Задача - написать функцию, определяющую площадь круга по радиусу
// и площадь треугольника по трём сторонам 

namespace Square_of_figures
{


    internal class Program
    {
        const double PI = 3.1415926;
        static double Square(double x1) { return (x1 * x1 * PI); }
        static double Square(double x1, double x2, double x3)
        {
            if (x1 > (x2 + x3) || (x2 > x1 + x3) || (x3 > x2 + x1)) return -1;
            double p = (x1 + x2 + x3) / 2;
            return Math.Sqrt(p*(p-x1)*(p-x2)*(p-x3));
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Square(3));
            Console.WriteLine(Square(5,4,3));
            Console.WriteLine(Square(1,2,3));
            Console.WriteLine(Square(100,22,8));
        }
    }
}
