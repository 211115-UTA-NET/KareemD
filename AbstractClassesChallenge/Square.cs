using System;

namespace AbstractClassesChallenge
{
    public class Square : Rectangle
    {
        public new double length;
        public new string Name = "square";
        public new int NumSides = 4;

        //Create constructor
        public Square(){}
        public Square(string Name, int NumSides, double length)
        {
            //Create instance variables
            this.Name = Name;
            this.NumSides = NumSides;
            this.length = length;
        }
        public Square( double length)
        {
            //Create instance variables
            
            this.length = length;
            
        }


        public override void GetInfo()
        {
            System.Console.WriteLine($"This {this.Name} has {this.NumSides} sides and an area of {this.GetArea()}");
        }

        public override double GetArea()
        {
            
            return this.length * this.length;
            
        }
    }
}
