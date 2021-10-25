using System;

namespace Puissance4
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Connect4();

            do
            {
                Display(game);
                for (; ; )
                {
                    Console.WriteLine($"Player {game.joueur} : Which column 1-{game.NombreColonne} ?");

                    var turn = Console.ReadLine();
                    int column;

                    if (int.TryParse(turn, out column))
                    {
                        game.Jouer(column);
                        break;
                    }
                    Console.Error.WriteLine("Invalid column number.");
                }
            }
            while (!game.Ended);
            Display(game);
            if(game.Gagnant == 0)
            {
                Console.WriteLine("Draw");
            }
            else
            {
                Console.WriteLine($"Le joueur {game.Gagnant} l'emporte");
            }
        }
        private static void Display(Connect4 game)
        {
            for (int y = 0; y < game.NombreLigne; y++)
            {
                for (int x = 0; x < game.NombreColonne; x++)
                {
                    Console.Write($"| {game.Pion(x, y)} ");
                }
                Console.WriteLine("|");
                for (int x = 0; x < game.NombreColonne; x++)
                {
                    Console.Write($"+---");
                }
                Console.WriteLine("+");
            }
            for (int x = 0; x < game.NombreColonne; x++)
            {
                Console.Write($"  {x + 1} ");
            }
            Console.WriteLine();
        }
    }
}