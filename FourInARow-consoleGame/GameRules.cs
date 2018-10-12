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
        //TODO if full board
        //TODO if vertical is full
        FourInARow Game;
        private int counter;
        public GameRules(FourInARow game)
        {
            Game = game;
        }

        //TODO Diagonal 4 in a row
        public void CheckDiagonal()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    
                }
            }
        }

        public void CheckRow()
        {
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Game.twoDimensionalArray[j, i] == Game.currentPlayer.brik) counter++;
                    else counter = 0;

                    if (counter == 4)
                    {
                        Game.gameOver = true;
                        Console.WriteLine(Game.currentPlayer.navn + " har vundet");
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
                    if (Game.twoDimensionalArray[i, j] == Game.currentPlayer.brik) counter++;
                    else counter = 0;

                    if (counter == 4)
                    {
                        Game.gameOver = true;
                        Console.WriteLine(Game.currentPlayer.navn + " har vundet");
                    }
                }
            }
        }

        public void CheckForAWinner()
        {
            //CheckDiagonal();
            CheckColumn();
            CheckRow();
        }
    }
}
