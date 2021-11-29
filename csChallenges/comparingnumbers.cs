using System;
					
public class Program
{
	public static void Main()
	{
		int X = Convert.ToInt32(Console.ReadLine());
		int Y = Convert.ToInt32(Console.ReadLine());
        if (X>Y) {
            Console.WriteLine("X is greater than Y");
        }
        else if (X<Y){
            Console.WriteLine("X is less than Y");
        }
        else if (X==Y) {
            Console.WriteLine("X is equal to Y");
        }
	}
}