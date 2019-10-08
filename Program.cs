using System;

namespace hoja_talet
{
    class Program
    {
        static string player1;
        static string player2;
        // Variabler för PlayTheGame()
        static int number = 0;
        static int acceptedNumber;
        static int countForPlayerTurn = 1;
        //variabel för WannaPlayAgain()-metoden
        static bool playAgain = true;
        //Metod som sparar ner användarnas namn      
        static string PlayerNames()
        {
            Console.Write("Namn: ");
            string player = Console.ReadLine();
            return player;
        }
        //Själva spelet
        static void PlayTheGame()
        {
            while (number < 21)
            {
                try
                {
                    Console.WriteLine("Väljer du: " + (number + 1) + ", " + (number + 2) + " eller " + (number + 3));
                    Console.Write(KeepTrackOfWhosTurn() + ": ");
                    acceptedNumber = Convert.ToInt32(Console.ReadLine());

                    if (acceptedNumber > (number + 3) || acceptedNumber <= number || acceptedNumber > 21)
                    {
                        Console.WriteLine("I detta spelet får man inte fuska! Lägg ner det, det finns ändå inga pengar att vinna.");
                        Console.ReadLine();
                    }
                    else if (acceptedNumber == 21)
                    {
                        number = acceptedNumber;
                        Console.WriteLine(KeepTrackOfWhosTurn() + " har förlorat!\n");
                        Console.ReadKey();
                        countForPlayerTurn++;
                        Console.WriteLine("Grattis till segern " + KeepTrackOfWhosTurn() + "!!!!!!11one");
                        Console.ReadKey();
                    }
                    else
                    {
                        countForPlayerTurn++;
                        number = acceptedNumber;
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Bara siffror");
                    Console.ReadLine();
                }
            }
        }
        //Håll koll på om det är spelare 1 eller 2s tur genom att kolla om countForFlayerTurn är jämt eller udda
        static string KeepTrackOfWhosTurn()
        {
            if (countForPlayerTurn % 2 == 0)
            {
                return player2;
            }
            else
            {
                return player1;
            }
        }
        //Metod ifall man vill spela igen
        static void WannaPlayAgain()
        {
            Console.WriteLine("Vill ni spela igen?");
            Console.Write("Ja/Nej: ");
            string yesOrNo = Console.ReadLine().ToUpper();

            if (yesOrNo[0] == 'N')
            {
                playAgain = false;
                Console.WriteLine("Vad tråkigt att ni inte vill fortsätta spela!");
                Console.WriteLine("Men det är fullt förståeligt...");
            }
            else if (yesOrNo[0] == 'J')
            {
                number = 0;
                playAgain = true;
                Console.WriteLine("Kul att ni vill spela igen!");
            }
            else
            {
                Console.WriteLine("Svara bara [Ja/Nej]");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("||------------------------------------------------------||");
            Console.WriteLine("Välkommen till spelet 21. Nej vi pratar inte om BlackJack. \nDetta spelet är mycket tråkigare. Nej man kan inte vinna några pengar här!");
            Console.WriteLine("Den som tvingas skriva 21 har förlorat!");
            Console.WriteLine("||------------------------------------------------------||");
            Console.ReadLine();
            Console.WriteLine("Vad heter spelare 1?");
            player1 = PlayerNames();
            Console.WriteLine("Vad heter spelare 2?");
            player2 = PlayerNames();

            do
            {
                PlayTheGame();
                WannaPlayAgain();
            }
            while (playAgain);

            Console.WriteLine("Tack för att ni spelat. Hoppas ni hade lite kul även om det inte var Blackjack!");
        }
    }
}

