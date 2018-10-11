using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTakToe_Game
{
    class GameBoard
    {
        private string[,] board = new string[3, 3];

        public void NewBoard()
        {
            board = new string[,]
            {
                { "1","2","3"},
                { "4","5","6"},
                { "7","8","9"}
            };
        }

        public void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |   ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", board[0, 0],board[0,1],board[0,2]);
            Console.WriteLine("     |     |   ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |   ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("     |     |   ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |   ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |   ");

        }
        public bool MarkBoard(string playerMarker, string boardPos)
        {
            //bool didWeUpdate = false;
            for(int i = 0; i < 3; i++)
            {
                for(int c = 0; c < 3; c++)
                {
                    if(boardPos == board[i, c])
                    {
                        board[i, c] = playerMarker;
                        return true;
                    }
                }
            }

            return false ;
        }

        public bool CheckWin(string player)
        {
            string marker = "Y";
            if (player == "Player1") marker = "X";
            else if (player == "Player2") marker = "O";
            else Console.WriteLine("Logic Error in CheckWin.");

            if (marker == board[0, 0] && marker == board[0, 1] && marker == board[0, 2]) return true;
            else if (marker == board[1, 0] && marker == board[1, 1] && marker == board[1, 2]) return true;
            else if (marker == board[2, 0] && marker == board[2, 1] && marker == board[2, 2]) return true;
            else if (marker == board[0, 0] && marker == board[1, 0] && marker == board[2, 0]) return true;
            else if (marker == board[0, 1] && marker == board[1, 1] && marker == board[2, 1]) return true;
            else if (marker == board[0, 2] && marker == board[1, 2] && marker == board[2, 2]) return true;
            else if (marker == board[0, 0] && marker == board[1, 1] && marker == board[2, 2]) return true;
            else if (marker == board[0, 2] && marker == board[1, 1] && marker == board[2, 0]) return true;
            else return false;
        }

        public bool CheckCat()
        {
            int n = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (int.TryParse(board[i,c], out n))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
