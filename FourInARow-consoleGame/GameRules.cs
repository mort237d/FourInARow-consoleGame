using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow_consoleGame
{
    class GameRules
    {

        FourInARow Game;
        private int counter;
        public GameRules(FourInARow game)
        {
            Game = game;
        }

        public void CheckRow()
        {
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Game.twoDimensionalArray[j, i] == Game.players[0].brik)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }

                    if (counter == 4)
                    {
                        Game.gameOver = true;
                        Console.WriteLine(Game.players[0].navn + " har vundet");
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
                    if (Game.twoDimensionalArray[i, j] == Game.players[0].brik)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }

                    if (counter == 4)
                    {
                        Game.gameOver = true;
                        Console.WriteLine(Game.players[0].navn + " har vundet");
                    }
                }
            }
        }

        public void CheckForAWinner()
        {
            CheckColumn();
            CheckRow();
        }

        public void CheckBrik()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (Game.twoDimensionalArray[i, j] == Game.players[0].brik)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
            counter = 0;
        }
    }
}
