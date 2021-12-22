using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Data.SqlClient;


namespace StoreApp
{

    public interface IRepository
    {
        IEnumerable<Transaction> GetAllTransactions(string name);
        IEnumerable<Transaction> GetOrderDetails(string name);
        void AddNewUser(string user);
        void AddNewTransaction(string orderID, string buyer, string item, string store);
        int getInventory(string item);
        void setInventory(string item, int numLeft);
        void AddNewTransaction(string orderID, string buyer, string storeName, int total);
    }
}