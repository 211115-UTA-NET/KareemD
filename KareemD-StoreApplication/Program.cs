using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StoreApp
{
    class Project
    {

        public static void Main(string[] args)
        {

            string connectionString = File.ReadAllText("../../../ConnectionString.txt");
            IRepository repository = new SqlRepository(connectionString);
            // ==========| User Phase|=============
            Console.Clear();
            newUser user = new newUser();
            Console.WriteLine("Welcome to Shopping App");
            string name = null;
            while (name == null || name.Length <= 0)
            {
                Console.Write("Enter an valid username: ");
                name = Console.ReadLine();
            }
            user.Name = name;
            repository.AddNewUser(user.Name);
            
            
            //============| Store phase |=============

            Console.Clear();
            //Shopping Phase - Create new Stores - w/ Products
            Store GeneralSupply = new Store("GeneralSupply", repository);
            GeneralSupply.addProduct("Shirt", 5);
            GeneralSupply.Products[0].numLeft = repository.getInventory("Shirt");
            GeneralSupply.addProduct("Pants", 10);
            GeneralSupply.Products[1].numLeft = repository.getInventory("Pants");
            GeneralSupply.addProduct("Shoes", 15);
            GeneralSupply.Products[2].numLeft = repository.getInventory("Shoes");

            Store ProShop = new Store("ProShop", repository);
            ProShop.addProduct("Hat", 5);
            ProShop.Products[0].numLeft = repository.getInventory("Hat");
            ProShop.addProduct("Gloves", 10);
            ProShop.Products[1].numLeft = repository.getInventory("Gloves");
            ProShop.addProduct("Boots", 15);
            ProShop.Products[2].numLeft = repository.getInventory("Boots");



            Store QuikMart = new Store("QuikMart", repository);
            QuikMart.addProduct("Fruit", 5);
            QuikMart.Products[0].numLeft = repository.getInventory("Fruit");
            QuikMart.addProduct("Vegi", 10);
            QuikMart.Products[1].numLeft = repository.getInventory("Vegi");
            QuikMart.addProduct("Meat", 15);
            QuikMart.Products[2].numLeft = repository.getInventory("Meat");


            bool shopping = true;
            while (shopping)
            {
                displayStores();
                int chooseStore;
                

                
                do
                {
                    bool tryChoice = int.TryParse(Console.ReadLine(), out chooseStore);

                }while(chooseStore != 1 && chooseStore != 2 &&
                        chooseStore != 3 && chooseStore != 4 &&
                        chooseStore != 9 && chooseStore != 0 && chooseStore != 5);

                switch (chooseStore)
                {
                    case 1:
                        GeneralSupply.placeOrder(user.Name);
                        break;
                    case 2:
                        ProShop.placeOrder(user.Name);
                        break;
                    case 3:
                        QuikMart.placeOrder(user.Name);
                        break;
                    case 4:
                        repository.GetAllTransactions(user.Name);
                        string bin = Console.ReadLine();
                        break;
                    case 5:
                        repository.GetOrderDetails(user.Name);
                        string btin = Console.ReadLine();
                        break;
                    case 9:
                        displayStores();
                        GeneralSupply.Products[0].numLeft +=5;
                        GeneralSupply.Products[1].numLeft += 5;
                        GeneralSupply.Products[2].numLeft += 5;
                        ProShop.Products[0].numLeft += 5;
                        ProShop.Products[1].numLeft += 5;
                        ProShop.Products[2].numLeft += 5;
                        QuikMart.Products[0].numLeft += 5;
                        QuikMart.Products[1].numLeft += 5;
                        QuikMart.Products[2].numLeft += 5;
                        Console.WriteLine("Stores are restocked!");
                        string non = Console.ReadLine();
                        break;
                    case 0:
                        shopping = false;
                        break;
                    default:
                        shopping = false;
                        break;
                }

            }
            Environment.Exit(-1);
        }

        public static void displayStores()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("                                ");
            Console.WriteLine("General Supply           Press 1");
            Console.WriteLine("ProShop                  Press 2");
            Console.WriteLine("QuikMart                 Press 3");
            Console.WriteLine("================================");
            Console.WriteLine("Choose a store to shop in!\n" +
                                "Press 4 to see your items.\n" +
                                "Press 5 to see recent orders\n" +
                                "\nPress 0 to end program.\n");

        }



        
    }
}
