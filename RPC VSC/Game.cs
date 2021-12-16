namespace RockPaperScissorsApp.App
{
    public class Game
    {
        private readonly Random rnd = new Random();
        int w = 0;
        int l = 0;
        string[] RPC = { "Exit", "Rock", "Paper", "Scissors"};
        
        public void PlayRound()
        {
            // userChoice choice
            int userChoice=0;
            bool valid;

            // use array to imput strings, so that u can take numbers as an index - smartstuff
            do 
            { 
                // userChoice = Convert.ToInt32
                Console.WriteLine("Enter choice: \nRock: 1\nPaper: 2\nScissors: 3");

                //try parse method that updates output same time
                valid = int.TryParse(Console.ReadLine(), out userChoice);
                if( valid == false) Console.WriteLine("Not a valid choice.");
               
            }while( (userChoice != 1 && userChoice != 2 && userChoice != 3) || valid != true );
            
            // comp choice
            int num = rnd.Next(1,4);
            Console.WriteLine("You : " + RPC[userChoice]);
            Console.WriteLine("My Choice: " + RPC[num]);

            // win/loss logic //1-r,2-p,3-s
            if(userChoice == 1 && num == 2){
                Console.WriteLine("You Lose!");
                l++;
            } else if(userChoice == 1 && num == 3){
                Console.WriteLine("You Win!");
                w++;
            } else if(userChoice == 2 && num == 1){
                Console.WriteLine("You Lose!");
                l++;
            } else if(userChoice == 2 && num == 3){
                Console.WriteLine("You Win!");
                w++;
            } else if(userChoice == 3 && num == 1){
                Console.WriteLine("You Lose!");
                l++;
            } else if(userChoice == 3 && num == 2){
                Console.WriteLine("You Win!");
                w++;
            } else {
                Console.WriteLine("Draw!");
            }
            Console.WriteLine("userChoice: " + w + " - Computer: " + l);
        }

        public string Summary
        {
            get
            {
                return "(not implemented yet)";
            }
        }
    }

    
}
