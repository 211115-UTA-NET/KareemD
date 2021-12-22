
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace StoreApp
{

    public class Product
    {
        public string? Title {get; set;}
        public int Price{get; set;}
        public int numLeft=20;

        public Product()
        {
            this.Title = "product";
            this.Price = 10;
            this.numLeft = 20;
        }
        public Product( string title)
        {
            this.Title = title;
        }
        public Product( string title, int price)
        {
            this.Title = title;
            this.Price = price;
        }
        public Product( string title, int price, int quantity)
        {
            this.Title = title;
            this.Price = price;
            this.numLeft = quantity;
        }

    }
}