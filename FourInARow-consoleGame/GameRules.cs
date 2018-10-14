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
        //TODO Diagonal 4 in a row
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
                if (game.twoDimensionalArray[j, i] == game.currentPlayer.brik
                    && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j - 1, i + 1]
                    && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j - 2, i + 2]
                    && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j - 3, i + 3])
                {
                    game.gameOver = true;
                    Console.WriteLine(game.currentPlayer.navn + " har vundet");
                    break;
                }
            }
        }
        private void RightAndDown(int i)
        {
            for (int j = 0; j <= 2; j++)
            {
                if (game.twoDimensionalArray[j, i] == game.currentPlayer.brik
                    && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j + 1, i + 1]
                    && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j + 2, i + 2]
                    && game.twoDimensionalArray[j, i] == game.twoDimensionalArray[j + 3, i + 3])
                {
                    game.gameOver = true;
                    Console.WriteLine(game.currentPlayer.navn + " har vundet");
                    break;
                }
            }
        }
        public void CheckRow()
        {
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (game.twoDimensionalArray[j, i] == game.currentPlayer.brik) counter++;
                    else counter = 0;

                    if (counter == 4)
                    {
                        game.gameOver = true;
                        Console.WriteLine(game.currentPlayer.navn + " har vundet");
                    }
                }
            }
        }
        public void CheckColumn()
        {
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (game.twoDimensionalArray[i, j] == game.currentPlayer.brik) counter++;
                    else counter = 0;

                    if (counter == 4)
                    {
                        game.gameOver = true;
                        Console.WriteLine(game.currentPlayer.navn + " har vundet");
                    }
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
