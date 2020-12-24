using System;

namespace assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();

        }

        void Start()
        {
            YahtzeeGame yahtzeeGame = new YahtzeeGame();
            yahtzeeGame.Init();
            PlayYahtzee(yahtzeeGame);

            Console.ReadKey();
        }

        void PlayYahtzee (YahtzeeGame game)
        {
            int nrOfAttempts = 0;
            int nrOfThrees = 0;
            int nrOfFours = 0;

            do
            {
                game.Throw();
                game.DisplayValues();

                if(game.ThreeOfAKind())
                {
                    nrOfThrees++;
                }

                if (game.FourOfAKind())
                {
                    nrOfFours++;
                }

                nrOfAttempts++;
            } while (!game.Yahtzee());

            Console.WriteLine("Number of attempts needed (for Yahtzee): {0}", nrOfAttempts);
            Console.WriteLine("Amounts of ThreeOfAKind thrown: {0}", nrOfThrees);
            Console.WriteLine("Amounts of FourOfAKind thrown:: {0}", nrOfFours);
        }
    }
}
