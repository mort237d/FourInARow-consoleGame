using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow_consoleGame
{
    class GameRules
    {
        FourInARow game;
        private int counter;
        public GameRules(FourInARow game)
        {
           this. game = game;
        }
        public void CheckDiagonal()
        {
            for (int i = 0; i <= 2; i++)
            {
                RightAndDown(i);
                RightAndUp(i);
            }
        }
        private void RightAndUp(int i)
        {
            for (int j = 3; j <= 5; j++)
            {
                if (game.twoDimensionalArray[j, i] == game.currentPlayer.brik && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j - 1, i + 1] && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j - 2, i + 2] && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j - 3, i + 3])
                {
                    game.gameOver = true;
                    Console.WriteLine(game.currentPlayer.navn + " har vundet");
                }
            }
        }
        private void RightAndDown(int i)
        {
            for (int j = 0; j <= 2; j++)
            {
                if (game.twoDimensionalArray[j, i] == game.currentPlayer.brik && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j + 1, i + 1] && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j + 2, i + 2] && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j + 3, i + 3])
                {
                    game.gameOver = true;
                    Console.WriteLine(game.currentPlayer.navn + " har vundet");
                }
            }
        }
        public void CheckRow()
        {
            for (int j = 0; j <= 2; j++)
            {
                for (int i = 0; i <= 5; i++)
                {
                    if (game.twoDimensionalArray[j, i] == game.currentPlayer.brik && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j + 1, i] && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j + 2, i] && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j + 3, i])
                    {
                        game.gameOver = true;
                        Console.WriteLine(game.currentPlayer.navn + " har vundet");
                    }
                }
            }
        }
        public void CheckColumn()
        {
            for (int j = 0; j <= 5; j++)
            {
                for (int i = 0; i <= 2; i++)
                {
                    if (game.twoDimensionalArray[j, i] == game.currentPlayer.brik && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j, i + 1] && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j, i + 2] && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j, i + 3])
                    {
                        game.gameOver = true;
                        Console.WriteLine(game.currentPlayer.navn + " har vundet");
                    }
                }
            }
        }
        public void CheckForFullBoard()
        {
            for (int i = 0; i <= 5; i++)
            {
                if (game.twoDimensionalArray[0, i] != "|   |")
                {
                    counter++;
                    if (counter == 6)
                    {
                        game.gameOver = true;
                        Console.WriteLine("Ikke flere mulige træk, da pladen er fuld!");
                    }
                    else counter = 0;
                }
            }
        }
        public void CheckForAWinner()
        {
            CheckDiagonal();
            CheckColumn();
            CheckRow();
        }
    }
}