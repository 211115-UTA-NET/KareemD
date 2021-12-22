using System;
using System.IO;
using System.Xml.Serialization;

public class newUser
        {
            public string Name {get; set;} = "Customer";
            public int Cash {get; set;} = 200;
            public int[] totalItems {get; set;} = {0,0,0};

            public newUser(){}

            public newUser(string name)
            {
                this.Name = name;
            }
            public newUser(string name, int cash)
            {
                this.Name = name;
                this.Cash = cash;
            }

            public int updateCash(int[] storePurchase)
            {
            
            int total = storePurchase[0]*5+storePurchase[1]*10+storePurchase[2]*15;
            this.Cash -= total;
            Console.WriteLine($"your cash {Cash}");
            return Cash;

            }

            public int[] updateItems(int[] storePurchase)
            {
                for(int i = 0; i < totalItems.Length -1; i++){
                    totalItems[i] += storePurchase[i];
                }
                    return totalItems; 
            }

            public void checkAssets()
            {
                Console.Clear();
                Console.WriteLine($"Hi {Name}, you have ${Cash}.\nPress any key to go shopping!");
                Console.WriteLine($"{totalItems[0]} a's");
                Console.WriteLine($"{totalItems[1]} b's");
                Console.WriteLine($"{totalItems[2]} c's");
            }

            //save/load data fro stoers
            public void Save(string fileName)
            {
                //Use this as template code
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    var XML  = new XmlSerializer(typeof(newUser));
                    XML.Serialize(stream, this);
                }
            }
            
            //retirm type is of object (Class1)
            public newUser LoadFromFile(string fileName)
            {
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    var XML  = new XmlSerializer(typeof(newUser));
                    newUser? input = (newUser?)XML.Deserialize(stream);
                    return input!;
                }

            }
        }