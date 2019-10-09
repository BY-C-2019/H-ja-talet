using System;
using System.Collections.Generic;

namespace hoja_talet
{
    class HigherNumberGame
    {
        int maxValue            = 21;
        int numberInterval      = 0; 

        // Variable to calculate playerturn. Set to playercount at setup
        int turnCounter = 0;

        List<Player> players    = new List<Player>();
        int currentValue        = 0;

        public HigherNumberGame(int nrOfPlayers, int numberInterval, int losingNumber)
        {
            Console.Clear();
            Console.WriteLine("Hej och välkommen till spelet 'Höj Talet'.");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("[RULES] \nNi kommer få turas om att välja ett värde som skrivs ut i listan. \nDen som väljer {0} förlorar!", losingNumber);
            Console.WriteLine("----------------------------------------------");

            // Instansiate players to the game
            for (int i = 0; i < nrOfPlayers; i++)
            {
                Player newPlayer = new Player(players.Count);
                players.Add(newPlayer);
            }

            // Set to playercount to not start on 0
            turnCounter     = players.Count;

            // Set how many numbers to print each turn
            this.numberInterval = numberInterval;

            // Set loosing condition value
            maxValue = losingNumber;
        }

        public void StartGame()
        {
            int currentPlayer = 0;
           
            while (currentValue != maxValue) 
            {
                // Calculate whose turn it is
                currentPlayer = turnCounter % players.Count;
                // Used to calculate how many number are left til maxValue
                int numbersLeftToMax = 0;

                Console.Clear();
                Console.WriteLine(players[currentPlayer].Name);
                Console.WriteLine("------------------");
                Console.WriteLine("Skriv in vilket av följande värde du vill öka till.");
                
                // Print desired numbers from specified interval
                for (int i = 1; i < numberInterval +1; i++)
                {   
                    // Stop to print numbers if current value + i is exceeding the range of maxvalue
                    if (currentValue + i > maxValue) { 
                        break; 
                    }
                    // If only 1 number remains, taunt loosing player.
                    if (currentValue == maxValue -1) {
                        Console.Write(" {0} | Ta ditt nummer och få din dom loser!", maxValue);
                    }
                    else {
                        Console.Write(" {0} |", currentValue+i);
                    }
                    numbersLeftToMax++;
                }
                GetAndControlChosenValue(numbersLeftToMax);

                turnCounter++;
            }
            
            // When game is over
            EndGame(currentPlayer);
        }

        private void EndGame(int isLoser)
        {
            // Print endgame messages and set the loser
            players[isLoser].IsWinner = false;

            for (int i = 0; i < players.Count; i++)
            {
                players[i].PrintEndMessage();
            }

        }
        private void GetAndControlChosenValue(int numbersLeftToMax)
        {
            while (true)
            {
                int input;
                Console.Write("\n: ");

                // Control that input is a number
                if (!Int32.TryParse(Console.ReadLine(), out input)) {
                    Console.Write("Endast siffror tack!");
                    continue;
                }

                // Control that input is within accepted range
                if(!IsValueWithinRange(input, currentValue+1, currentValue + numbersLeftToMax)) {
                    Console.Write("Du kan inte välja det värdet.");
                    continue;
                }
                
                // Set current value to input
                currentValue = input;
                return;
            }
        }

        bool IsValueWithinRange(int valueToTest, int minAllowedValue, int maxAllowedValue)
        {
            // If value is withing the allowed range, return true
            if (valueToTest >= minAllowedValue && valueToTest <= maxAllowedValue) {
                return true;
            }

            return false;
        }
    }
}
