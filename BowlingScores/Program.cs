using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScores
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectBowlingScores();
        }

        public static void CollectBowlingScores()
        {
            string[][] scores = new string[10][];
            scores[0] = new string[2];
            scores[1] = new string[2];
            scores[2] = new string[2];
            scores[3] = new string[2];
            scores[4] = new string[2];
            scores[5] = new string[2];
            scores[6] = new string[2];
            scores[7] = new string[2];
            scores[8] = new string[2];
            scores[9] = new string[3];

            string currentBall;

            Console.WriteLine("Welcome to Bowling Scorer! Please enter your scores (X for strike and / for spare in second frame).");
            for (int i = 0; i < scores.Length - 1; i++)
            {
                Console.WriteLine($"Enter Frame {i + 1} Ball One.");
                currentBall = Console.ReadLine();
                if (currentBall == "X")
                {
                    scores[i][0] = "10";
                    scores[i][1] = null;
                    Console.WriteLine("Congratulations! You got a Strike.");
                    continue;
                }
                else
                {
                    scores[i][0] = currentBall;
                    Console.WriteLine($"Enter Frame {i + 1} Ball Two.");
                    currentBall = Console.ReadLine();
                    if (currentBall == "/")
                    {
                        scores[i][1] = (10 - int.Parse(scores[i][0])).ToString();
                        Console.WriteLine("You got a Spare. Respectable.");
                    }
                    else
                    {
                        scores[i][1] = currentBall;
                    }
                }
            }

            Console.WriteLine("Enter Frame 10 Ball One.");
            currentBall = Console.ReadLine();
            if (currentBall == "X")
            {
                scores[9][0] = "10";
                Console.WriteLine("Congratulations! You got a Strike.");
                Console.WriteLine("Enter Frame 10 Ball Two.");
                currentBall = Console.ReadLine();
                scores[9][1] = currentBall == "X" ? "10" : currentBall;
                if (currentBall == "X")
                    Console.WriteLine("Congratulations! You got a Strike.");
                Console.WriteLine("Enter Frame 10 Ball Three.");
                currentBall = Console.ReadLine();
                scores[9][2] = currentBall == "X" ? "10" : currentBall;
                if (currentBall == "X")
                    Console.WriteLine("Congratulations! You got a Strike.");
            }
            else
            {                
                scores[9][0] = currentBall;
                Console.WriteLine("Enter Frame 10 Ball Two.");
                currentBall = Console.ReadLine();
                if (currentBall == "/")
                {
                    scores[9][1] = (10 - int.Parse(scores[9][0])).ToString();
                    Console.WriteLine("You got a Spare. Respectable.");
                    Console.WriteLine("Enter Frame 10 Ball Three.");
                    currentBall = Console.ReadLine();
                    scores[9][2] = currentBall == "X" ? "10" : currentBall;
                    if (currentBall == "X")
                        Console.WriteLine("Congratulations! You got a Strike.");
                }
                else
                {
                    scores[9][1] = currentBall == "X" ? "10" : currentBall;
                    if (currentBall == "X")
                        Console.WriteLine("Congratulations! You got a Strike.");
                }
            }
            BowlingScores(scores);
        }

        /// <summary>
        /// This method scores a bowling game
        /// </summary>
        public static void BowlingScores(string[][] scores)
        {          
            //// Frame One
            //scores[0][0] = "10";
            //scores[0][1] = null;
            //// Frame Two
            //scores[1][0] = "6";
            //scores[1][1] = "2";
            //// Frame Three
            //scores[2][0] = "9";
            //scores[2][1] = "1";
            //// Frame Four
            //scores[3][0] = "7";
            //scores[3][1] = "0";
            //// Frame Five
            //scores[4][0] = "10";
            //scores[4][1] = null;
            //// Frame Six
            //scores[5][0] = "8";
            //scores[5][1] = "2";
            //// Frame Seven
            //scores[6][0] = "7";
            //scores[6][1] = "1";
            //// Frame Eight
            //scores[7][0] = "5";
            //scores[7][1] = "5";
            //// Frame Nine
            //scores[8][0] = "10";
            //scores[8][1] = null;
            //// Frame Ten
            //scores[9][0] = "6";
            //scores[9][1] = "2";
            //scores[9][2] = "4";
            
            int totalScore = 0;
            int ball1 = 0;
            int ball2 = 0;
            int ball3 = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine($"Frame: {i + 1}");
                // Check for strike on last frame
                if (i == scores.Length - 1 && scores[i][0] == "10")
                {
                    ball1 = int.Parse(scores[i][0]);
                    ball2 = int.Parse(scores[i][1]);
                    ball3 = int.Parse(scores[i][2]);
                    totalScore += ball1 + ball2 + ball3;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                    Console.WriteLine($"Ball Three: {ball3}");
                }
                // Check for spare on last frame
                else if (i == scores.Length - 1 && (int.Parse(scores[i][0]) + int.Parse(scores[i][1]) == 10))
                {
                    ball1 = int.Parse(scores[i][0]);
                    ball2 = int.Parse(scores[i][1]);
                    ball3 = int.Parse(scores[i][2]);
                    totalScore += ball1 + ball2 + ball3;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                    Console.WriteLine($"Ball Three: {ball3}");
                }
                // Check for strike
                else if (scores[i][0] == "10")
                {
                    ball1 = int.Parse(scores[i][0]);
                    ball2 = int.Parse(scores[i + 1][0]);
                    ball3 = 0;
                    if (scores[i + 1][1] == null)
                    {
                        ball3 = int.Parse(scores[i + 2][0]);
                    }
                    else
                    {
                        ball3 = int.Parse(scores[i + 1][1]);
                    }
                    totalScore += ball1 + ball2 + ball3;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                    Console.WriteLine($"Ball Three: {ball3}");
                }
                // Check for spare
                else if (int.Parse(scores[i][0]) + int.Parse(scores[i][1]) == 10)
                {
                    ball1 = int.Parse(scores[i][0]);
                    ball2 = int.Parse(scores[i][1]);
                    ball3 = int.Parse(scores[i + 1][0]);
                    totalScore += ball1 + ball2 + ball3;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                    Console.WriteLine($"Ball Three: {ball3}");
                }
                else
                {
                    ball1 = int.Parse(scores[i][0]);
                    ball2 = int.Parse(scores[i][1]);
                    totalScore += ball1 + ball2;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                }
                Console.WriteLine($"Total so far: {totalScore}");
            }
            Console.WriteLine($"Your final score: {totalScore}");
        }
    }
}
