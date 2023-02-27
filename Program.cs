using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace RPSGame
{

    class Program
    {
        static void Main(string[] args)
        {
            GameOn gameOn = new GameOn();
            gameOn.GameStart();

            Console.ReadKey();
        }
    }

    public class Messages
    {
        Scores _score = new Scores();
        public void Intro()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome To The Newest Game In The Building!");
            Console.WriteLine("Choose your move: Rock, Paper, or Scissors?");
        }
        public void PickMessage()
        {
            Console.Write("Pick Another Move. ROCK-PAPER-SCISSORS =>");
            _score.ScoreLimit();
        }

        public void WinMsg()
        {
            Console.WriteLine("Huuray! You WON This Round. You've Gotta Go Again.");
        }
        public void LoseMsg()
        {
            Console.WriteLine("Awwwww :(  You LOST This Round. Better Luck Next Round");
        }
        public void TieMsg()
        {
            Console.WriteLine("Hmmmmnn! Was A TIE. You've Got This. Lets Geaux!!!!");
        }
        public void ErrorMsg()
        {
            Console.WriteLine("You Inputted A WRONG RESPONSE. Your Score Is Intact, Lets Try Again.");
        }

        public void GameOverMsg()
        {
            Console.WriteLine("Game Over. See You Soon");
        }
        
    }

    public class Question
    {
        public string Quest()
        {
            string answer = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return answer;
        }
    }

    public class Scores
    {
        public int GameScore()
        {
            int currScore = 0;
            return currScore;
        }
        public void ScoreLimit()
        {
            int scoreLimit = 7;
            Console.WriteLine($"Score Limit: {scoreLimit}/-{scoreLimit}");
        }
        public int HighScoreLimit()
        {
            int highScore = 7;
            return highScore;
        }

        public int LowScoreLimit()
        {
            int lowScore = -7;
            return lowScore;
        }
    }
    
    public class GameOn
    {
        Messages message = new Messages();
        Question qtn = new Question();
        private Scores _score = new Scores();

        public void GameStart()
        {
            message.Intro();
            int score = _score.GameScore();
            int highScoreLimit = _score.HighScoreLimit();
            int lowScoreLimit = _score.LowScoreLimit();

            while (score < highScoreLimit && score > lowScoreLimit)
            {
                string playerMove = qtn.Quest();

                // generate the computer's move
                Random random = new Random();
                int computerMoveIndex = random.Next(3);
                string[] moves = { "ROCK", "PAPER", "SCISSORS" };
                string computerMove = moves[computerMoveIndex];

                // determine the result
                string result = "";
                if (playerMove == "ROCK" && computerMove == "SCISSORS" ||
                    playerMove == "PAPER" && computerMove == "ROCK" ||
                    playerMove == "SCISSORS" && computerMove == "PAPER")
                {
                    result = "win";
                }
                else if (playerMove == "ROCK" && computerMove == "PAPER" ||
                         playerMove == "PAPER" && computerMove == "SCISSORS" ||
                         playerMove == "SCISSORS" && computerMove == "ROCK")
                {
                    result = "lose";
                }
                else if (playerMove == computerMove)
                {
                    result = "tie";
                }
                else
                {
                    result  = "error";
                }

                // update the score
                if (result == "win")
                {
                    message.WinMsg();
                    score++;
                }
                else if (result == "lose")
                {
                    message.LoseMsg();
                    score--;
                }
                else if (result == "tie")
                {
                    message.TieMsg();
                }
                else
                {
                    message.ErrorMsg();
                }

                // display the score
                Console.WriteLine("Score: " + score);
                Console.WriteLine();
                message.PickMessage();
            }

            // the game is over
            message.GameOverMsg();
        }
    }
}