public static class Program
    {
        public enum Choice { Rock, Paper, Scissors };

        public enum Result { Draw, Winner, Loser };

        public static Result PlayJoKenPo(Choice choicePlayerOne, Choice choicePlayerTwo)
        {
            return (Result)((choicePlayerOne - choicePlayerTwo + 3) % 3);
        }

        public static void Main()
        {
            var result = PlayJoKenPo(Choice.Paper, Choice.Scissors);

            switch (result)
            {
                case Result.Draw: { Console.WriteLine("Draw!"); break; }
                case Result.Winner: { Console.WriteLine("Player One Winner!"); break; }
                case Result.Loser: { Console.WriteLine("Player Two Winner!"); break; }
            }

            Console.ReadKey();
        }
    }
