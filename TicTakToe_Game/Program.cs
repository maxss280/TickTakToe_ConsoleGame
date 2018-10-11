using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTakToe_Game
{
    class Program
    {

        static void Main(string[] args)
        {
            GameManager gManager = new GameManager();

            while (true)
            {
                gManager.RunGame();
                Console.WriteLine("Please hit a key to continue.");
                Console.ReadKey();
            }

        }

    }
}
