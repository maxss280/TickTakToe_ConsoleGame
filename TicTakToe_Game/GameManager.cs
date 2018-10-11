using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTakToe_Game
{
    class GameManager
    {
        private int gameState;
        private GameBoard gameBoard = new GameBoard();

        public GameManager()
        {
           this.gameState = 1;
        }

        public void RunGame()
        {
            //1 New Game
            //2 Player1
            //3 Player2
            //4 Reset

            switch (gameState)
            {
                case 1:
                    //Reinitalize Board
                    gameBoard.NewBoard();
                    gameBoard.DisplayBoard();

                    //Change to Player1
                    gameState = 2;

                    break;
                case 2:
                    //NPC Choose random board value
                    int randNum;

                    //Check Cat Game
                    if (gameBoard.CheckCat())
                    {
                        Console.WriteLine("Game goes to Cat");
                        gameState = 4;
                        break;
                    }
                    //Mark Board
                    do
                    {
                        randNum = (new Random().Next(1, 10));
                    }
                    while (!gameBoard.MarkBoard("X", randNum.ToString()));
                    //Display Board
                    gameBoard.DisplayBoard();
                    Console.WriteLine("Player 1 chose square {0}", randNum);

                    //Wait for key input to continue.

                    //Check 3 in row
                    //Check win
                    if (gameBoard.CheckWin("Player1"))
                    {
                        gameBoard.DisplayBoard();
                        Console.WriteLine("Sorry you Player 2 you have lost ;-;");
                        Console.WriteLine("Hit any key to reset");
                        gameState = 4;
                        break;
                    }
                    else
                    {
                        //switch to player 2
                        gameState = 3;
                    }

                    break;
                case 3:
                    bool res, markedBoard = false;
                    int num;
                    //Check Cat Game
                    if (gameBoard.CheckCat())
                    {
                        Console.WriteLine("Game goes to Cat");
                        gameState = 4;
                        break;
                    }
                    //Mark Board
                    do
                    {
                        gameBoard.DisplayBoard();
                        Console.WriteLine("Player 2 Please choose your square.");
                        string input1 = Console.ReadLine();
                        res = int.TryParse(input1, out num);

                        if (!res)
                        {
                            Console.WriteLine("You need to only enter a number.. and that didn't look like a number? {0} ???", input1);
                            Console.WriteLine("Please hit Enter to continue");
                            Console.ReadKey();
                        }

                        //Mark Board
                        if (res)
                        {
                            markedBoard = gameBoard.MarkBoard("O", num.ToString());
                            if (!markedBoard)
                            {
                                Console.WriteLine("That Space is alread marked.");
                                Console.ReadKey();
                            }
                        }

                    }
                    while (!markedBoard);
                    gameBoard.DisplayBoard();

                    //Check win
                    if (gameBoard.CheckWin("Player2"))
                    {
                        gameBoard.DisplayBoard();
                        Console.WriteLine("Congrats Player 2 you have won!!!!!");
                        gameState = 4;
                        break;
                    }
                    else
                    {
                        //Switch to player 1
                        gameState = 2;
                    }
                    break;
                case 4:
                    //Wait for enter key then switch to newgame
                    gameState = 1;
                    break;

            }
        }
    }
}
