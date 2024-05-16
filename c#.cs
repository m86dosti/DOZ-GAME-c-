using System;

namespace TicTacToe
{
    class Program
    {
           
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char Player = 'X';

        static void Main(string[] args)
        {
            bool gameEnded = false;

            while (!gameEnded)
            {
                DrawBoard();
                int move = GetMove();
                board[move] = Player;

             if (CheckWin())
                {
                	Console.SetCursorPosition(80,24);
                	Console.ForegroundColor=ConsoleColor.DarkYellow;
                	Console.Write("Player ");
                	Console.ForegroundColor=ConsoleColor.Red;
                	Console.Write(Player);
                	Console.ForegroundColor=ConsoleColor.DarkYellow;
                	Console.Write(" wins!");
                    Console.ReadKey();
                    gameEnded = true;
                }
                else if (CheckDraw())
                {
                	Console.ForegroundColor=ConsoleColor.Green;
                	Console.SetCursorPosition(80,24);
                    Console.WriteLine("It's a draw!");
                    gameEnded = true;
                }
                else
                {
                    Player = (Player == 'X') ? 'O' : 'X';
                }
            }
        }

        static void DrawBoard()
        {
        	Console.Clear();
        	Console.WriteLine();
        	Console.WriteLine();
            Console.ForegroundColor=ConsoleColor.DarkGray;
        	Console.WriteLine();
        	Console.WriteLine("                                                                                   Game guide");
        	Console.WriteLine();
        	Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine("                                                                                   " + 0 + " | " + 1 + " | " + 2 + " ");
            Console.WriteLine("                                                                                  ---+---+---");
            Console.WriteLine("                                                                                   " + 3 + " | " + 4 + " | " + 5 + " ");
            Console.WriteLine("                                                                                  ---+---+---");
            Console.WriteLine("                                                                                   " + 6 + " | " + 7 + " | " + 8 + " ");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor=ConsoleColor.Gray;
            Console.WriteLine("                                        _________________________________________________________________________________________________");
            Console.WriteLine();
            Console.ForegroundColor=ConsoleColor.DarkYellow;
            Console.WriteLine();       
            Console.WriteLine("                                                                                █┌───────────┐█");
            Console.WriteLine("                                                                                █│ " + board[0] + " | " + board[1] + " | " + board[2] + " │█");
            Console.WriteLine("                                                                                █│---+---+---│█");
            Console.WriteLine("                                                                                █│ " + board[3] + " | " + board[4] + " | " + board[5] + " │█");
            Console.WriteLine("                                                                                █│---+---+---│█");
            Console.WriteLine("                                                                                █│ " + board[6] + " | " + board[7] + " | " + board[8] + " │█");
            Console.WriteLine("                                                                                █└───────────┘█");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor=ConsoleColor.Blue;
            Console.Write("                                         ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ");
            Console.ForegroundColor=ConsoleColor.DarkGray;
            Console.Write("About ");
            Console.ForegroundColor=ConsoleColor.Blue;
            Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.WriteLine("");
            Console.WriteLine("                                                                     This is a simple DOZ game written in C#");
            Console.WriteLine("");
            Console.ForegroundColor=ConsoleColor.Red;
            Console.Write("                                                                           Developer :");
            Console.ForegroundColor=ConsoleColor.Blue;
            Console.WriteLine(" Mohammad Dosti Por");
            Console.WriteLine("");
            Console.WriteLine("                                             ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            


        }


        static int GetMove()
        {
            int move = -1;
            bool validMove = false;

            while (!validMove)
            {
                Console.ForegroundColor=ConsoleColor.Blue;
            	Console.SetCursorPosition(50,17);
            	Console.ForegroundColor=ConsoleColor.DarkRed;
                Console.WriteLine("Player " + Player);
            	Console.SetCursorPosition(45,19);
            	Console.ForegroundColor=ConsoleColor.Blue;
                Console.WriteLine("Enter your move (0-8): ");
            	Console.SetCursorPosition(68,19);              
                string input = Console.ReadLine();

                if (int.TryParse(input, out move) && move >= 0 && move < 9 && board[move] == ' ')
                {
                    validMove = true;
                }
                else
                {
                    Console.ForegroundColor=ConsoleColor.DarkRed;
                	Console.SetCursorPosition(70,25);
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }

            return move;
        }

        static bool CheckWin()
        {
            // Check rows
            
            for (int i = 0; i < 9; i += 3)
            {
                if (board[i] != ' ' && board[i] == board[i + 1] && board[i] == board[i + 2])
                {
                    return true;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i] != ' ' && board[i] == board[i + 3] && board[i] == board[i + 6])
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0] != ' ' && board[0] == board[4] && board[0] == board[8])
            {
                return true;
            }
            if (board[2] != ' ' && board[2] == board[4] && board[2] == board[6])
            {
                return true;
            }

            return false;
        }

        static bool CheckDraw()
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == ' ')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
