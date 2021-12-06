using System;

namespace AbstractClassesChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Start!");

            Rectangle rec = new Rectangle(2,2);
            rec.GetArea();
            rec.GetInfo();
            Square sqr = new Square(2);
            sqr.GetInfo();
            Triangle tri = new Triangle(4,5,1);
            tri.GetInfo();
        }
    }
}