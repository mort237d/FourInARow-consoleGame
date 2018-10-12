using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow_consoleGame
{
    class Player
    {
        public string navn;
        public string brik;
        public Player(string brik, string navn)
        {
            this.brik = brik;
            this.navn = navn;
        }

    }
}
