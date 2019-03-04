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
            BowlingScorerImproved();
        }

        /// <summary>
        /// Collects input from the user and uses score method
        /// </summary>
        public static void CollectBowlingScores()
        {
            int?[][] scores = new int?[10][];
            scores[0] = new int?[2];
            scores[1] = new int?[2];
            scores[2] = new int?[2];
            scores[3] = new int?[2];
            scores[4] = new int?[2];
            scores[5] = new int?[2];
            scores[6] = new int?[2];
            scores[7] = new int?[2];
            scores[8] = new int?[2];
            scores[9] = new int?[3];

            // Holds user input
            string currentBall;

            Console.WriteLine("Welcome to Bowling Scorer! Please enter your scores (X for strike and / for spare in second frame).");
            for (int i = 0; i < scores.Length - 1; i++)
            {
                Console.WriteLine($"Enter Frame {i + 1} Ball One.");
                currentBall = Console.ReadLine();
                if (currentBall == "X")
                {
                    scores[i][0] = 10;
                    scores[i][1] = null;
                    Console.WriteLine("Congratulations! You got a Strike.");
                }
                else
                {
                    scores[i][0] = int.Parse(currentBall);
                    Console.WriteLine($"Enter Frame {i + 1} Ball Two.");
                    currentBall = Console.ReadLine();
                    if (currentBall == "/")
                    {
                        scores[i][1] = 10 - scores[i][0];
                        Console.WriteLine("You got a Spare. Respectable.");
                    }
                    else
                    {
                        scores[i][1] = int.Parse(currentBall);
                    }
                }
            }

            Console.WriteLine("Enter Frame 10 Ball One.");
            currentBall = Console.ReadLine();
            if (currentBall == "X")
            {
                scores[9][0] = 10;
                Console.WriteLine("Congratulations! You got a Strike.");
                Console.WriteLine("Enter Frame 10 Ball Two.");
                currentBall = Console.ReadLine();
                scores[9][1] = currentBall == "X" ? 10 : int.Parse(currentBall);
                if (currentBall == "X")
                    Console.WriteLine("Congratulations! You got a Strike.");
                Console.WriteLine("Enter Frame 10 Ball Three.");
                currentBall = Console.ReadLine();
                scores[9][2] = currentBall == "X" ? 10 : int.Parse(currentBall);
                if (currentBall == "X")
                    Console.WriteLine("Congratulations! You got a Strike.");
            }
            else
            {                
                scores[9][0] = int.Parse(currentBall);
                Console.WriteLine("Enter Frame 10 Ball Two.");
                currentBall = Console.ReadLine();
                if (currentBall == "/")
                {
                    scores[9][1] = 10 - scores[9][0];
                    Console.WriteLine("You got a Spare. Respectable.");
                    Console.WriteLine("Enter Frame 10 Ball Three.");
                    currentBall = Console.ReadLine();
                    scores[9][2] = currentBall == "X" ? 10 : int.Parse(currentBall);
                    if (currentBall == "X")
                        Console.WriteLine("Congratulations! You got a Strike.");
                }
                else
                {
                    scores[9][1] = currentBall == "X" ? 10 : int.Parse(currentBall);
                    if (currentBall == "X")
                        Console.WriteLine("Congratulations! You got a Strike.");
                }
            }
            BowlingScores(scores);
        }

        /// <summary>
        /// This method scores a bowling game
        /// </summary>
        public static void BowlingScores(int?[][] scores)
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
            //scores[9][2] = null;
            
            int? totalScore = 0;
            int? ball1 = 0;
            int? ball2 = 0;
            int? ball3 = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine($"Frame: {i + 1}");
                // Check for strike on last frame
                if (i == scores.Length - 1 && scores[i][0] == 10)
                {
                    ball1 = scores[i][0];
                    ball2 = scores[i][1];
                    ball3 = scores[i][2];
                    totalScore += ball1 + ball2 + ball3;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                    Console.WriteLine($"Ball Three: {ball3}");
                }
                // Check for spare on last frame
                else if (i == scores.Length - 1 && (scores[i][0] + scores[i][1] == 10))
                {
                    ball1 = scores[i][0];
                    ball2 = scores[i][1];
                    ball3 = scores[i][2];
                    totalScore += ball1 + ball2 + ball3;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                    Console.WriteLine($"Ball Three: {ball3}");
                }
                // Check for strike
                else if (scores[i][0] == 10)
                {
                    ball1 = scores[i][0];
                    ball2 = scores[i + 1][0];
                    ball3 = 0;
                    if (scores[i + 1][1] == null)
                    {
                        ball3 = scores[i + 2][0];
                    }
                    else
                    {
                        ball3 = scores[i + 1][1];
                    }
                    totalScore += ball1 + ball2 + ball3;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                    Console.WriteLine($"Ball Three: {ball3}");
                }
                // Check for spare
                else if (scores[i][0] + scores[i][1] == 10)
                {
                    ball1 = scores[i][0];
                    ball2 = scores[i][1];
                    ball3 = scores[i + 1][0];
                    totalScore += ball1 + ball2 + ball3;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                    Console.WriteLine($"Ball Three: {ball3}");
                }
                else
                {
                    ball1 = scores[i][0];
                    ball2 = scores[i][1];
                    totalScore += ball1 + ball2;
                    Console.WriteLine($"Ball One: {ball1}");
                    Console.WriteLine($"Ball Two: {ball2}");
                }
                Console.WriteLine($"Total so far: {totalScore}");
            }
            Console.WriteLine($"Your final score: {totalScore}");
        }

        /// <summary>
        /// Scores a bowling game in real time
        /// </summary>
        public static void BowlingScorerImproved()
        {
            Console.WriteLine("Welcome to Bowling Scorer.");
            int score = 0;
            string current = "", oneBack = "", twoBack = "";
            
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"Frame {i} ball 1. Enter your score (X for Strike):");
                current = Console.ReadLine();
                if (twoBack == "X")
                    score += current == "X" ? 10 : int.Parse(current);
                if (oneBack == "X" || oneBack == "/")
                    score += current == "X" ? 10 : int.Parse(current);
                if (current == "X")
                {
                    score += 10;
                    twoBack = oneBack;
                    oneBack = current;
                    Console.WriteLine($"Potential score so far: {score}. (May change with future frames)");
                    continue;
                }
                score += int.Parse(current);
                twoBack = oneBack;
                oneBack = current;
                Console.WriteLine($"Frame {i} ball 2. Enter your score (/ for Spare):");
                current = Console.ReadLine();
                if (twoBack == "X")
                    score += current == "/" ? 10 - int.Parse(oneBack) : int.Parse(current);
                score += current == "/" ? 10 - int.Parse(oneBack) : int.Parse(current);
                twoBack = oneBack;
                oneBack = current;
                Console.WriteLine($"Potential score so far: {score}. (May change with future frames)");
            }
            Console.WriteLine("Frame 10 ball 1. Enter your score (X for Strike):");
            current = Console.ReadLine();
            if (twoBack == "X")
                score += current == "X" ? 10 : int.Parse(current);
            if (oneBack == "X" || oneBack == "/")
                score += current == "X" ? 10 : int.Parse(current);
            score += current == "X" ? 10 : int.Parse(current);
            twoBack = oneBack;
            oneBack = current;
            Console.WriteLine("Frame 10 ball 2. Enter your score (X for Strike, / for Spare):");
            current = Console.ReadLine();
            if (twoBack == "X")
            {
                if (current == "X")
                    score += 10;
                else if (current == "/")
                    score += 10 - int.Parse(oneBack);
                else
                    score += int.Parse(current);
            }
            if (current == "/")
                score += 10 - int.Parse(oneBack);
            else
                score += current == "X" ? 10 : int.Parse(current);
            twoBack = oneBack;
            oneBack = current;
            if (oneBack == "X" || oneBack == "/")
            {
                Console.WriteLine("Frame 10 ball 3. Enter your score (X for Strike):");
                current = Console.ReadLine();
                if (twoBack == "X")
                    score += current == "X" ? 10 : int.Parse(current);
                if (oneBack == "/")
                    score += current == "X" ? 10 : int.Parse(current);
            }
            Console.WriteLine($"Final score: {score}.");
            Console.ReadLine();
        }
    }
}
