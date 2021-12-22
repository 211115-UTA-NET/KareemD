using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace StoreApp
{
    public class Store
    {
        public string StoreName { get; set; }
        private readonly IRepository _repository;
        public List<Product> Products = new List<Product>();
        static string orderID;



        // public Store(string StoreName, IRepository repository, List<Product>? Products = null)
        public Store(string name, IRepository repository)
        {
            StoreName = name;
            _repository = repository;
        }


        //Place a order at the
        public int placeOrder(string buyer)
        {
            int total = 0;
            int[] order = { 0, 0, 0 };
            bool stillBuying = true;
            string Rand = Guid.NewGuid().ToString("N").Substring(0, 5);
            orderID = Rand;
            do
            {
                menu();
                getTotal(order);
                stillBuying = Buying(stillBuying, orderID, buyer, order);
            }
            while (stillBuying);
            total = getTotal(order);
            _repository.AddNewTransaction(orderID, buyer, StoreName, total);
            return getTotal(order);
        }

        public void addProduct(string title, int price)
        {
            Products.Add(new Product(title, price));
        }

        

        // Print menu to the screen
        private void menu()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("                Menu                 ");
            Console.WriteLine("Product       Price        Quantity");
            Console.WriteLine($"{Products[0].Title}           $5              {Products[0].numLeft}");
            Console.WriteLine($"{Products[1].Title}           $10             {Products[1].numLeft}");
            Console.WriteLine($"{Products[2].Title}           $15             {Products[2].numLeft}");
            Console.WriteLine("======================================");
        }

        public bool Buying(bool stillBuying, string orderID, string buyer, int[] order )
        {

            _repository.setInventory(Products[0].Title, Products[0].numLeft);
            _repository.setInventory(Products[1].Title, Products[1].numLeft);
            _repository.setInventory(Products[2].Title, Products[2].numLeft);
            Console.WriteLine("What would you like to buy? \n" +
                "Press 4 to see store's order history.\nPress 0 to exit.");
            int choice;
            bool tryChoice = int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    
                    if (Products[0].numLeft == 0)
                    {
                        Console.WriteLine("I can't fill that");
                        return stillBuying;
                    }
                    order[0]++;
                    Products[0].numLeft--;
                    AddRecord(orderID, buyer, Products[0].Title, StoreName);
                    return stillBuying;
                case 2:
                    if (Products[1].numLeft == 0){
                        Console.WriteLine("I can't fill that");
                        return stillBuying;
                    }
                    order[1]++;
                    Products[1].numLeft--;
                    AddRecord(orderID, buyer, Products[1].Title, StoreName);
                    return stillBuying;
                case 3:
                    if (Products[2].numLeft == 0)
                    {
                        Console.WriteLine("I can't fill that");
                        return stillBuying;
                    }
                    order[2]++;
                    Products[2].numLeft--;
                    AddRecord(orderID, buyer, Products[2].Title, StoreName);
                    return stillBuying;
                case 4:
                    Console.Clear();
                    _repository.GetOrderDetails(StoreName);
                    Console.ReadLine();
                    return !stillBuying;
                default:
                    return !stillBuying;


            }
            
            
        }



        private int getTotal(int[] purchasing)
        {
            int cost = 0;
            cost += purchasing[0] * 5 + purchasing[1] * 10 + purchasing[2] * 15;
            Console.WriteLine($"Your total is: ${cost}");
            return cost;
        }
        

       

        //================
        //================
        //================
        //================
        //================

        private void AddRecord(string orderID, string buyer, string item, string store)
        {
           
            var record = new Transaction(orderID, buyer, item, store);
            _repository.AddNewTransaction(orderID, buyer, item, store);
            Console.WriteLine($"You have a {record.Item}!");
            
        }

        //public string Summary()
        //{
        //    IEnumerable<Transaction> allTransactions = _repository.GetAllTransactions(StoreName);
        //    var summary = new StringBuilder();
        //    summary.AppendLine($"Date\t\t\tComputer\t{StoreName}\t\tResult");
        //    summary.AppendLine("---------------------------------------------------------------");
        //    foreach (var record in allTransactions)
        //    {
        //        summary.AppendLine($"{record.orderID}\t\t\t{record.Buyer}\t\t{record.Item}");
        //        Console.WriteLine(record.Buyer + record.Item);
        //    }
        //    summary.AppendLine("---------------------------------------------------------------");
        //    Console.ReadLine();
        //    return summary.ToString();
        //}


    }


}
