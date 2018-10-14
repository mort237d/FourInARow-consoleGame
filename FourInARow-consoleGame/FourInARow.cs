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
        public Player currentPlayer;
        private string navn;
        private int position, counter;
        public bool gameOver = false;
        bool noMoreSpace;
        public string[,] twoDimensionalArray = new string[6, 6];
        public string[,] ATopOfBoard = new string[2, 6];
        private GameRules gameRules;

        public FourInARow()
        {
            gameRules = new GameRules(this);
            for (int i = 0; i < 6; i++) for (int j = 0; j < 6; j++) twoDimensionalArray[i, j] = "|   |";
            for (int i = 0; i < 6; i++) ATopOfBoard[1, i] = " (" + (i + 1) + ") ";
            for (int i = 0; i < 6; i++) ATopOfBoard[0, i] = "     ";
            Console.SetWindowSize(35, 15);
            Intro();
            GamePlay();
        }
        private void GamePlay()
        {
            while (!gameOver)
            {
                ATopOfBoard[0, position - 1] = "     ";
                gameRules.CheckForFullBoard();
                noMoreSpace = false;
                //position = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                do
                {
                    Console.Clear();
                    Console.WriteLine("Indsæt et nummer mellem 1 og 6!");
                    drawBoard();
                    Console.WriteLine("Hvor vil " + currentPlayer.navn + " sætte sin brik");
                } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out position));
                Console.Clear();
                if (position <= 6 && position != 0)
                {
                    CheckWhereToInsertBrik();
                    if (noMoreSpace) Console.WriteLine("No more space at " + position);
                    gameRules.CheckForAWinner();
                    ATopOfBoard[0, position - 1] = "  v  ";
                    drawBoard();
                    if (!noMoreSpace) nextPlayer();
                }
                else
                {
                    Console.WriteLine("Ugyldigt input. Vælg et input mellem 1 og 6.");
                    drawBoard();
                }
            }
        }
        private void CheckWhereToInsertBrik()
        {
            for (int i = 5; i >= 0; i--)
            {
                if (twoDimensionalArray[i, position - 1] != players[0].brik && twoDimensionalArray[i, position - 1] != players[1].brik)
                {
                    twoDimensionalArray[i, position - 1] = currentPlayer.brik;
                    break;
                }
                else if (twoDimensionalArray[0, position - 1] != "|   |")
                {
                    noMoreSpace = true;
                    break;
                }
            }
        }
        private void drawBoard()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++) Console.Write(ATopOfBoard[i,j]);
                Console.WriteLine();
            }
            Console.WriteLine("+----------------------------+");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (twoDimensionalArray[i, j] == "| B |")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(twoDimensionalArray[i, j]);
                        Console.ResetColor();
                    }
                    else if (twoDimensionalArray[i, j] == "| R |")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(twoDimensionalArray[i, j]);
                        Console.ResetColor();
                    }
                    else Console.Write(twoDimensionalArray[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("+----------------------------+");
        }
        private void Intro()
        {
            Console.WriteLine("Velkommen til Fire På Stribe!");
            AddNewPlayer(1, "| R |");
            AddNewPlayer(2, "| B |");
            currentPlayer = players.First();
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