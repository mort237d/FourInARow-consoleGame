using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow_consoleGame
{
    class FourInARow
    {

      
        private Player currentPlayer;

        char[,] twoDimensionalArray = new char[6,6];

        public FourInARow()
        {
            
           // Intro();
            Console.WriteLine("+-----------------------+");
            for (int i = 0; i < 6; i++) Console.WriteLine("|   |   |   |   |   |   |");
            Console.WriteLine("+-----------------------+");
        }

        private static void Intro()
        {
            Console.WriteLine("Velkommen til Fire På Stribe!");
            Console.WriteLine("Hvilket navn har spiller 1 idag?");
            string navn = Console.ReadLine();
            Player player1 = new Player('R', navn);
            Console.WriteLine("Hvilket navn har spiller 2 idag?");
            navn = Console.ReadLine();
            Player player2 = new Player('B', navn);
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
    }

    
}
