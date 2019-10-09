using System;

namespace hoja_talet
{
    class Player
    {
        int     ID    = 0;
        private string  name  = "";
        public  string  Name { get{ return name; }}

        private bool    isWinner = true;
        public  bool    IsWinner { set { isWinner = value; }}

        private string  chosenNumbers = " | ";

        public Player(int playerID)
        {
            this.ID     = playerID;
            this.name   = SetPlayerName();
        }

        private string SetPlayerName()
        {
            Console.Write("Spelare {0}, vad önskas för namn: ", (ID+1));
            return Console.ReadLine();
        }

        public void PrintEndMessage()
        {  
            if (isWinner) {
                Console.WriteLine("Vinnare: {0}, GRATTIS!!", name);
                Console.WriteLine("Du valde följande nummer:");
                Console.WriteLine(chosenNumbers + "\n");
            }
            // else {
            //     Console.WriteLine("Förlorare: {0} (L2P!)", name);
            // }
        }

        public void AddChosenNumber(int number)
        {
            chosenNumbers += (number + " | ");
        }

    }
}
