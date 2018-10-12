using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow_consoleGame
{
    class FourInARow
    {
        public List<Player> players = new List<Player>();
        private Player currentPlayer;
        private string navn;
        private int position;
        public bool gameOver = false;
        public string[,] twoDimensionalArray = new string[6,6];
        private GameRules gameRules;

        public FourInARow()
        {
            gameRules = new GameRules(this);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    twoDimensionalArray[i, j] = "|   |";
                }
            }
            
            //Intro();
            
            players.Add(new Player("| B |", "Daniel", this));
            players.Add(new Player("| R |", "Thomas", this));
            currentPlayer = players.First();
            drawBoard();

            while (!gameOver)
            {
                Console.WriteLine("Hvor vil " + currentPlayer.navn + " sætte sin brik");
                position = Convert.ToInt32(Console.ReadLine());

                for (int i = 5; i >= 0; i--)
                {
                    if (twoDimensionalArray[i , position - 1] != players[0].brik && twoDimensionalArray[i , position - 1] != players[1].brik)
                    {
                        twoDimensionalArray[i , position - 1] = currentPlayer.brik;
                        break;
                    }
                }
                Console.Clear();
                gameRules.CheckRow();
                drawBoard();
                
                nextPlayer();
            }
        }

        private void drawBoard()
        {
            Console.WriteLine(" (1)  (2)  (3)  (4)  (5)  (6)");
            Console.WriteLine("+----------------------------+");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++) Console.Write(twoDimensionalArray[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine("+----------------------------+");
        }

        private void Intro()
        {
            Console.WriteLine("Velkommen til Fire På Stribe!");
            AddNewPlayer(1, "| R |");
            AddNewPlayer(2, "| B |");
            drawBoard();
        }

        private void AddNewPlayer(int n, string brik)
        {
            Console.WriteLine("Hvilket navn har spiller " + n + " idag?");
            navn = Console.ReadLine();
            players.Add(new Player(brik, navn, this));
        }

        private void nextPlayer()
        {
            if (currentPlayer == players.Last()) currentPlayer = players.First();
            else currentPlayer = players.Last();
        }
    }
}
