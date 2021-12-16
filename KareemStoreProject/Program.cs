using System;
using System.IO;
using System.Collections.Generic;

namespace storeApp {
    class Project{
        //should i be using static objects - becasue i only
        //want these instances of store and when customer objects
        //interact wth them they can only use the values in these
        //objects ???????
        

        public static void Main(string[] args)
        {
            //try catch ------ Enumeration?
            store store1 = new store();
            store1 = store1.LoadFromFile("store1Records.xml");
            store store2 = new store();
            store2 = store2.LoadFromFile("store2Records.xml");
            store store3 = new store();
            store3 = store3.LoadFromFile("store3Records.xml");

            chooseStore();
            Console.WriteLine("");
            int choice;
            bool tryChoice = int.TryParse(Console.ReadLine(), out choice);
            bool shopping = true;

            while(shopping)
            {
                switch (choice) 
                {
                case 1:
                    store1.placeOrder();
                    break;
                case 2:
                    store2.placeOrder();
                    break;
                case 3:
                    store3.placeOrder();
                    break;
                }
                Console.WriteLine("Continue Shpping...y/n?");
                string? input = Console.ReadLine();
                if(input != "y")
                {
                    store1.Save("store1Records.xml");
                    store2.Save("store2Records.xml");
                    store3.Save("store3Records.xml");
                    break;
                }

            }
        }

        public static void chooseStore() {
            Console.Clear();
            Console.WriteLine("\t\t\t\t+=======================+");
            Console.WriteLine("\t\t\t\t         Store Locations            ");
            Console.WriteLine("\t\t\t\t store1          ");
            Console.WriteLine("\t\t\t\t store2          ");
            Console.WriteLine("\t\t\t\t store3          ");
            Console.WriteLine("\t\t\t\t+=======================+");
        }
    }  
} 