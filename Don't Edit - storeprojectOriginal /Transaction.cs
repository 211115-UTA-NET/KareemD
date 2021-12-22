using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace StoreApp
{
    public class Transaction
    {

        // ex: [ 10/7 Computer: Rock VS You: Paper => You Win! ]
        public DateTimeOffset Date { get; }
        public string? Buyer { get; set; }
        public string? Item { get; set; }

        // constructor
        public Transaction(DateTimeOffset date, string? buyer, string? item)
        {
            Date = date;
            Buyer = buyer;
            Item = item;
        }
    }
}