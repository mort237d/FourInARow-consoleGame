﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow_consoleGame
{
    class FourInARow
    {
        private List<Player> players = new List<Player>();
        private Player currentPlayer;
        private string navn;
        private int position;
        private bool gameOver = false;
        char[,] twoDimensionalArray = new char[6,6];

        public FourInARow()
        {
            //Intro();
            //            Console.WriteLine(" (1) (2) (3) (4) (5) (6)");
            //            Console.WriteLine("+-----------------------+");
            //            for (int i = 0; i < 6; i++) Console.WriteLine("|   |   |   |   |   |   |");
            //            Console.WriteLine("+-----------------------+");
            players.Add(new Player('B', "Daniel"));
            players.Add(new Player('R', "Thomas"));
            currentPlayer = players.First();
            while (!gameOver)
            {
                Console.WriteLine("Hvor vil " + currentPlayer.navn + " sætte sin brik");
                position = Convert.ToInt32(Console.ReadLine());
//                twoDimensionalArray[0, 5] = 'B';
//                twoDimensionalArray[0, 4] = 'R';
                for (int i = 5; i >= 0; i--)
                {
                    if (twoDimensionalArray[position - 1, i] != players[0].brik && twoDimensionalArray[position - 1, i] != players[1].brik)
                    {
                        twoDimensionalArray[position - 1, i] = currentPlayer.brik;
                        break;
                    }
                }

                for (int i = 0; i <= 5; i++)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        Console.WriteLine("[" + i + "," + j + "]");
                        Console.WriteLine(twoDimensionalArray[i, j]);
                    }
                }
                nextPlayer();
            }
        }

        private void Intro()
        {
            Console.WriteLine("Velkommen til Fire På Stribe!");
            Console.WriteLine("Hvilket navn har spiller 1 idag?");
            navn = Console.ReadLine();
            players.Add(new Player('R', navn));
            Console.WriteLine("Hvilket navn har spiller 2 idag?");
            navn = Console.ReadLine();
            players.Add(new Player('B', navn));
        }


        /// <summary>
        /// get a single value from our two dimensional array
        /// </summary>
        /// <param name="x">x axis</param>
        /// <param name="y">y axis</param>
        /// <returns></returns>
        public char getSingleValue(int x, int y)
        {
            return twoDimensionalArray[x, y];
        }

        /// <summary>
        /// Set a single value for our two dimensional array
        /// </summary>
        /// <param name="x">x axis position</param>
        /// <param name="y">y axis position</param>
        /// <param name="value">the char you want to set</param>
        /// <returns></returns>
        public void setSingleValue(int x, int y, char value)
        {
             twoDimensionalArray[x, y] = value;
        }

        private void nextPlayer()
        {
            if (currentPlayer == players.Last()) currentPlayer = players.First();
            else currentPlayer = players.Last();
        }
    }
}
