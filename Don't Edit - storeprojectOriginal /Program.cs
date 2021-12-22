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
            //Get/Greet user
            Console.Clear();
            newUser user = new newUser();
            
            Console.WriteLine("Do you have an account? y/n");
            string? input1 = Console.ReadLine();
            
            // Serialization
            if(input1 == "y")
            {
                Console.WriteLine("Name?");
                string? userName = Console.ReadLine();
                try 
                {
                    user = user.LoadFromFile($"{userName}Records.xml");
                } 
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("First exception caught.", e);
                }
            }
            else 
            {
                Console.WriteLine("Name?");
                string? userName = Console.ReadLine();
                
                if(userName != null)
                {
                    user.Name = userName;
                }
                else
                {
                userName = "Customer";
                }
            }

            Console.Clear();
            user.checkAssets();
            Console.ReadLine();
            Console.Clear();

            string connectionString = File.ReadAllText("./connString.txt");
            IRepository repository = new SqlRepository(connectionString);

            //Shopping Phase - Create new Stores
            Store GeneralSupply = new Store("GeneralSupply", repository);
            GeneralSupply.addProduct("Shirt", 5);
            GeneralSupply.addProduct("Pants", 10);
            GeneralSupply.addProduct("Shoes", 15);
            try 
            {
                GeneralSupply = GeneralSupply.LoadFromFile("GeneralSupplyRecords.xml");
            } 
            catch (FileNotFoundException e)
            {
                Console.WriteLine("First exception caught.", e);
            }
            
            Store WallyMart = new Store("WallyMart", repository);
            WallyMart.addProduct("Hat", 5);
            WallyMart.addProduct("Gloves", 10);
            WallyMart.addProduct("Boots", 15);
            try 
            {
                WallyMart = WallyMart.LoadFromFile("WallyMartRecords.xml");
            } 
            catch (FileNotFoundException e)
            {
                Console.WriteLine("First exception caught.", e);
            }
            Store Bodega = new Store("Bodega", repository);
            Bodega.addProduct("Fruit", 5);
            Bodega.addProduct("Vegi", 10);
            Bodega.addProduct("Meat", 15);
            try 
            {
                Bodega = Bodega.LoadFromFile("BodegaRecords.xml");
            } 
            catch (FileNotFoundException e)
            {
                Console.WriteLine("First exception caught.", e);
            }

            bool shopping = true;
            while (shopping)
            {

                DisplayStores();
                int chooseStore;
                bool tryChoice = int.TryParse(Console.ReadLine(), out chooseStore);
                int[] StorePurchase = {0,0,0,};

                Console.WriteLine("which Store?");
                switch (chooseStore)
                {
                    case 1:
                        StorePurchase = GeneralSupply.placeOrder(user.Name, user.Cash);
                        user.updateCash(StorePurchase);
                        user.updateItems(StorePurchase);
                        break;
                    case 2:
                        StorePurchase = WallyMart.placeOrder(user.Name, user.Cash);
                        user.updateCash(StorePurchase);
                        user.updateItems(StorePurchase);
                        break;
                    case 3:
                        StorePurchase = Bodega.placeOrder(user.Name, user.Cash);
                        user.updateCash(StorePurchase);
                        user.updateItems(StorePurchase);
                        break;
                    case 4:
                        user.checkAssets();
                        break;
                    default:
                        shopping = false;
                        break;
                }

                //XML
                GeneralSupply.Save("GeneralSupplyRecords.xml");
                WallyMart.Save("WallyMartRecords.xml");
                Bodega.Save("BodegaRecords.xml");
                user.Save($"{user.Name}Records.xml");

                //SQL
            }
        }

        public static void DisplayStores()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("Store Locations");
            Console.WriteLine("GeneralSupply            local A");
            Console.WriteLine("WallyMart                local B");
            Console.WriteLine("Bodega                   local C");
            Console.WriteLine("=======================");
            Console.WriteLine("press 4 to see your Assets\nPress any other key to exit.");

        }
    }
}

