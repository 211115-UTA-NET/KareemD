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

        //details
        public string? StoreName { get; set; }
        private readonly IRepository _repository;
        public List<Product> Products = new List<Product>();
            
        public void addProduct( string title, int price)
        {
            Products.Add( new Product(title, price));

        }
        

        // int a { get; set; } = 100;
        // int b { get; set; } = 100;
        // int c { get; set; } = 100;

        
        // public Store(string StoreName, IRepository repository, List<Product>? Products = null)
        public Store(string name, IRepository repository)
        {
            // if(Products !=null)
            // {
            //     this.Products = Products;
            // }
            StoreName = name;
            _repository = repository;
        }


        //Place a order at the
        public int[] placeOrder(string buyer, int userCash)
        {
            int total = 0;
            int[] order = {0,0,0};
            bool stillBuying = true;
            

            while (stillBuying)
            {
                menu();
                Console.WriteLine("What would you like to buy? \nPress 0 to exit.");
                int choice;
                bool tryChoice = int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        order[0]++;
                        checkTotal(order, userCash);
                        Products[0].numLeft--;
                        AddRecord(buyer, Products[0].Title);

                        break;
                    case 2:
                        order[1]++;
                        checkTotal(order, userCash);
                        Products[1].numLeft--;
                        AddRecord(buyer, Products[1].Title);
                        break;
                    case 3:
                        order[2]++;
                        checkTotal(order, userCash);
                        Products[1].numLeft--;
                        AddRecord(buyer, Products[2].Title);
                        break;
                    default:
                        stillBuying = false;
                        break;
                }
                
            }
                
                total += order[0]*5+order[1]*10+order[0]*15;
                if (total <= userCash){ return order; } 
                else { 
                    Array.Clear(order, 0, order.Length);
                    return order; }
            //save inventory
        }

        // fill the current order
        public int[] fillOrder(int[] order)
        {
            return order;
        }

        // Print menu to the screen
        public void menu()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("                Menu                 ");
            Console.WriteLine("Product       Price        Quantity");
            Console.WriteLine($"{Products[0].Title}           $5              {Products[0].numLeft}");
            Console.WriteLine($"{Products[1].Title}           $10             {Products[1].numLeft}");
            Console.WriteLine($"{Products[2].Title}           $15             {Products[2].numLeft}");
            Console.WriteLine("======================================");
            foreach (var Product in Products)
            {
                Console.WriteLine(Products[0].Title);

            }

        }

        // check the order total
         public int checkTotal(int[] purchasing, int userCash)
        {
            int cost = 0;
            cost += purchasing[0]*5+purchasing[1]*10+purchasing[0]*15;
            Console.WriteLine($"Your total is: ${cost}");

            if (cost > userCash){
                Console.WriteLine("not enough cash!");
            }
            return cost;
            
        }

        //save/load data fro stoers
         public void Save(string fileName)
        {
            //Use this as template code
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var XML  = new XmlSerializer(typeof(Store));
                // XML.Serialize(stream, this);
                XML.Serialize(stream, this);
            }
        }
        
        //retirm type is of object (Class1)
        public Store LoadFromFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML  = new XmlSerializer(typeof(Store));
                Store? input = (Store?)XML.Deserialize(stream);
                return input!;
            }

        }




        //================
        //================
        //================
        //================
        //================

        private void AddRecord(string buyer, string? item)
        {
            var record = new Transaction(DateTimeOffset.Now, buyer, item);
            _repository.AddNewTransaction(buyer, item);
            Console.WriteLine($"You have a {record.Item}!");
        }

        public string Summary()
        {
            IEnumerable<Transaction> allTransactions = _repository.GetAllTransactions(StoreName);
            var summary = new StringBuilder();
            summary.AppendLine($"Date\t\t\tComputer\t{StoreName}\t\tResult");
            summary.AppendLine("---------------------------------------------------------------");
            foreach (var record in allTransactions)
            {
                summary.AppendLine($"{record.Date}\t{record.Buyer}\t\t{record.Item}");
            }
            summary.AppendLine("---------------------------------------------------------------");

            return summary.ToString();
        }
    }
}
