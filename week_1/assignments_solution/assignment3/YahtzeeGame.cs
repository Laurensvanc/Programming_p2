using System;
using System.Collections.Generic;
using System.Text;

namespace assignment3
{
    class YahtzeeGame
    {
        Dice[] dices = new Dice[5];

        public void Init()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice();
            }
        }

        public void Throw()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i].Throw();
            }
        }

        public void DisplayValues()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i].DisplayValue();
                Console.Write(" ");
            }
            Console.WriteLine("");
        }

        public int Matcher()
        {
            int matches = 0;

            for (int diceCheck = 0; diceCheck < dices.Length; diceCheck++)
            {
                matches = 0;
                int tempDiceNumber = dices[diceCheck].value;

                for (int diceCompare = 0; diceCompare < dices.Length; diceCompare++)
                {

                    if (tempDiceNumber == dices[diceCompare].value)
                    {
                        matches++;
                    }
                }
            }

            return matches;
        }

        public bool Yahtzee()
        {
            if (Matcher() == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ThreeOfAKind()
        {
            if (Matcher() == 3)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public bool FourOfAKind()
        {
            if (Matcher() == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
