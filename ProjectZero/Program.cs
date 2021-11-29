using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            int num1 = 0;
            int num2 = 0;
            bool running = true;


            Console.WriteLine("Type a number, and then press Enter");
            num1 = Convert.ToInt32(Console.ReadLine());


        
            do{
            Console.WriteLine("Type another number, and then press Enter");
            num2 = Convert.ToInt32(Console.ReadLine());

           
            num1 = doMath(num1, num2);
            }while(running == true);


        

        int doMath(int num1, int num2){

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
                    Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
                    num1 = num1 / num2;
                    break;
                case "c":
                    Console.WriteLine("Type a number, and then press Enter");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    break;
                case "x":
                    running = false;
                    break;

            }
            return num1;


        }
        }
    }
}