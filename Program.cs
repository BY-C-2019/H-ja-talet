using System;

namespace hoja_talet
{
    class Program
    {
        static void Main(string[] args)
        {
            HigherNumberGame game = new HigherNumberGame(2, 3, 21);
            game.StartGame();
        }   
    }
}
