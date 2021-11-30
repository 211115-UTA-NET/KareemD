using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            double num1 = 0;
            double num2 = 0;
            bool running = true;


            Console.WriteLine("Type a number, and then press Enter");
            num1 = Convert.ToDouble(Console.ReadLine());


        
            do{
            Console.WriteLine("Type another number, and then press Enter");
            num2 = Convert.ToDouble(Console.ReadLine());
            

           
            num1 = doMath(num1, num2);
            }while(running == true);


        

        double doMath(double num1, double num2){

            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\tc - Clear memory");
            Console.WriteLine("\tx - Close the Calculator app...");
            Console.Write("Your option? ");

            //Operations
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                    num1 = num1 + num2;
                    break;
                case "s":
                    Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
                    num1 = num1 - num2;
                    break;
                case "m":
                    Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
                    num1 = num1 * num2;
                    break;
                case "d":
                if(num2 == 0){
                Console.WriteLine("Error: Dividing by zero. Choose another number");
                num2 = Convert.ToDouble(Console.ReadLine());
            }
                    Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
                    num1 = num1 / num2;
                    break;
                case "c":
                    Console.WriteLine("Type a number, and then press Enter");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    break;
                case "x":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Operation! Choose again!");
                    doMath(num1, num2);
                    break;

            }
            return num1;


        }
        }
    }
}