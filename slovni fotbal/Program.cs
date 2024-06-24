using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace slovni_fotbal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comparisonF;
            string comparisonL;
            string word1 = "test";
            string word2;
            string word3;


            Console.WriteLine("Welcome to Word Football");
            Console.WriteLine("Please chose which a gamemode:");
            Console.WriteLine("1. Player vs Player ");
            Console.WriteLine("2. Player vs Computer");
            Console.WriteLine("3. Exit");
            string gamemode = Console.ReadLine();

            if (gamemode == "1" || gamemode == "2")
            {
                if (gamemode == "1") {

                    Console.WriteLine("\nPlayer vs Player mode\n");
                    Console.WriteLine("Please chose a name for plyers: ");
                    Console.WriteLine("Player 1: ");
                    string player1 = Console.ReadLine();
                    Console.WriteLine("Player 2: ");
                    string player2 = Console.ReadLine();

                    Console.WriteLine("Good luck " + player1 + " and " + player2 + "!");

                    bool player1Turn = true;
                    string ComparisonL = string.Empty;

                    while (true)
                    {
                        if (player1Turn)
                        {
                            Console.WriteLine( player1 +", enter a word:");
                        }
                        else
                        {
                            Console.WriteLine( player2 + ", enter a word:");
                        }

                        string WordP = Console.ReadLine().ToLower();

                        if (string.IsNullOrEmpty(WordP))
                        {
                            Console.WriteLine("Invalid word. " + (player1Turn ? player1 : player2) + " loses!");
                            Console.WriteLine((player1Turn ? player2 : player1) + " wins!");
                            break;
                        }

                        if (!string.IsNullOrEmpty(ComparisonL) && WordP.First() != ComparisonL.First())
                        {
                            Console.WriteLine("\n\nThe word must start with the letter: " + ComparisonL +"\n");
                            Console.WriteLine((player1Turn ? player1 : player2) + " loses!");
                            Console.WriteLine((player1Turn ? player2 : player1) + " wins!");
                            break;
                        }

                        ComparisonL = WordP.Last().ToString();
                        player1Turn = !player1Turn;
                    }

                    Console.WriteLine("\n\nGame over!");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("\nPlayer vs Computer mode\n");
                    List<string> Words = new List<string>
                         {
                          "apple", "elephant", "tiger", "rabbit", "tree", "eagle", "orange", "giraffe"
                         };

                    bool player2Turn = true;
                    string ComparisonL = string.Empty;

                    while (true)
                    {
                        if (player2Turn)
                        {
                            Console.WriteLine("Player, enter a word:");
                            string WordP = Console.ReadLine().ToLower();

                            if (string.IsNullOrEmpty(WordP))
                            {
                                Console.WriteLine("Invalid word. Player loses!");
                                break;
                            }

                            if (!string.IsNullOrEmpty(ComparisonL) && WordP.First() != ComparisonL.First())
                            {
                                Console.WriteLine("The word must start with the letter: " + ComparisonL);
                                Console.WriteLine("Player loses!");
                                break;
                            }

                            ComparisonL = WordP.Last().ToString();
                        }
                        else
                        {
                            string WordC = Words.FirstOrDefault(w => w.StartsWith(ComparisonL));
                            if (WordC == null)
                            {
                                Console.WriteLine("Computer cannot find a word. Computer loses!");
                                break;
                            }

                            Console.WriteLine("Computer chose the word: " + WordC);
                            Words.Remove(WordC);
                            ComparisonL = WordC.Last().ToString();
                        }

                        player2Turn = !player2Turn;
                    }

                    Console.WriteLine("\n\nGame over!");
                    Console.ReadLine();

                }
            }
            else
            {

                //exit

            }
        }

    }

        
    
    
}
