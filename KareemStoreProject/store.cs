using System.Xml.Serialization;
namespace storeApp
{
    public class store
    {

        //get inventory

        //details
        string? name {get; set; }
        string? location {get; set; }

        //inventory
        int a = 100;
        int b = 100;
        int c = 100;

        public static void menu() {
            Console.Clear();
            Console.WriteLine("\t\t\t\t+=======================+");
            Console.WriteLine("\t\t\t\t         Menu            ");
            Console.WriteLine("\t\t\t\t itemA           $5");
            Console.WriteLine("\t\t\t\t itemB           $10");
            Console.WriteLine("\t\t\t\t itemC           $15");
            Console.WriteLine("\t\t\t\t+=======================+");

        }

        public void placeOrder() 
        {
            menu();
            


            //save inventory

        }
        



        public void displayInventory()
        {
            Console.WriteLine($"a = {a}b = {b}c = {b}");
        }
        
        public void buyA(int quantity){
            a -= quantity;
            displayInventory();
        }
        public void buyB(int quantity){
            b -= quantity;
            displayInventory();
        }
        public void buyC(int quantity){
            c -= quantity;
            displayInventory();
        }

        public void Save(string fileName)
        {
            //Use this as template code
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var XML  = new XmlSerializer(typeof(store));
                XML.Serialize(stream, this);
            }
        }
        
        //retirm type is of object (Class1)
        public store LoadFromFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML  = new XmlSerializer(typeof(store));
                store? input = (store?)XML.Deserialize(stream);
                return input!;
            }

        }

        //return recipt method that saves all order details adn prints it back out to main - this can aslo be appended to total orders for the store and used to update the store records??

        //just implement a read/write at beginning of class so that when its instantiated it will have the proper inventory levels from where we ended alst time???????

        

    }

    
    
}


// public void fillOrder(string item, int quantity)
//         {
//             Console.WriteLine($"a = {a}b = {b}c = {b}");
//         }