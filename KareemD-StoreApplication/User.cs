using System;
using System.IO;
using System.Xml.Serialization;

public class newUser
{
    public string Name { get; set; } = "Customer";

    public newUser() { }

    public newUser(string name)
    {
        this.Name = name;
    }

    public void displayPurchases(string name)
    {
        // List<Transactions> result = new(string name);
        // using SqlConnection connection = new(_connectionString);
        // connection.Open();
        // using SqlCommand cmd = new(
        // @"SELECT * FROM shop.Orders 
        // WHERE orderName = @userName;",
        //     connection);

        // cmd.Parameters.AddWithValue("@userName", name);

        // using SqlDataReader reader = cmd.ExecuteReader();

        // // get trx from db
        // while (reader.Read())
        // {
        //     // DateTimeOffset timestamp = reader.GetDateTimeOffset(0);
        //     // var move1 = (Move)Enum.Parse(typeof(Move), reader.GetString(3));
        //     // var move2 = (Move)Enum.Parse(typeof(Move), reader.GetString(4));
        //     // result.Add(new(timestamp, name, item));
        // }
        // connection.Close();
        // return result;
    }
}
