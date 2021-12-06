using System;

namespace AbstractClassesChallenge
{
    public class Triangle : Shape
    {
            public double a,b,c;
        public new string Name = "Triangle";
        public new int NumSides = 3;

        //Create constructor
        public Triangle(string Name, int NumSides, double a, double b, double c)
        {
            //Create instance variables
            this.Name = Name;
            this.NumSides = NumSides;
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public Triangle( double a, double b, double c)
        {
            //Create instance variables
            
            this.a = a;
            this.b = b;
        }


        public override void GetInfo()
        {
            System.Console.WriteLine($"This {this.Name} has {this.NumSides} sides and an area of {this.Area}");
        }

        public override double GetArea()
        {
            
            return this.a * this.a;
            
        }
    }
}
