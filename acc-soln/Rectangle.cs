using System;

namespace AbstractClassesChallenge
{
    public class Rectangle : Shape
    {
        // Implement your Rectangle class here.
        public double length, width;
        public new string Name = "Rectangle";
        public new int NumSides = 4;

        //Create constructor
        public Rectangle(){

        }
        public Rectangle(string Name, int NumSides, double length, double width)
        {
            //Create instance variables
            this.Name = Name;
            this.NumSides = NumSides;
            this.length = length;
            this.width = width;
        }
        public Rectangle( double length, double width)
        {
            //Create instance variables
            
            this.length = length;
            this.width = width;
        }


        public override void GetInfo()
        {
            System.Console.WriteLine($"This {this.Name} has {this.NumSides} sides and an area of {this.Area}");
        }

        public override double GetArea()
        {
            
            return this.length * this.width;
            
        }
        // public override SetArea()
        // {
        //     this.Area = this.length * this.width;
        //     return;
        // }
    }
}
