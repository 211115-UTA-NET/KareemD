using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StoreApp
{

    public class Product
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int numLeft { get; set; }


        public Product()
        {
            this.Title = "product";
            this.Price = 10;
            this.numLeft = 20;
        }
        public Product(string title)
        {
            this.Title = title;
        }
        public Product(string title, int price)
        {
            this.Title = title;
            this.Price = price;
        }
        public Product(string title, int price, int quantity)
        {
            this.Title = title;
            this.Price = price;
            this.numLeft = quantity;
        }

    }
}

//=====updates amount
//string cmd2Text = @"UPDATE shop.Items
//                                SET Inventory = @newNum";
//using SqlCommand cmd2 = new(cmd2Text, connection);
//cmd2.Parameters.AddWithValue("@newNum", name);

//using SqlDataReader reader2 = cmd2.ExecuteReader();

//reader2.Read();
//return reader2.GetInt32(0);