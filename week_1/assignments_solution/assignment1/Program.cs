using System;

namespace assignment1
{
    class Program
    {
        static void Main()
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            //PrintMonth(Month.January);

            PrintMonths();

            Console.Write("\nEnter a month number: ");
            ReadMonth(Console.ReadLine());

            Console.ReadKey();
        }

        void PrintMonth(Month month)
        {
            Console.WriteLine(month);
        }

        void PrintMonths()
        {
            for (int i = 1; i <= 12; i++)
            {
                Console.Write($"{i}. ");
                PrintMonth((Month)i);
            }
        }

        Month ReadMonth(string question)
        {
            int inputMonth = int.Parse(question);

            while (!Enum.IsDefined(typeof(Month), (Month)inputMonth))
            {
                Console.WriteLine($"{inputMonth} is not a valid value.");
                Console.Write("Enter a month number: ");
                inputMonth = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"{inputMonth} => {(Month)inputMonth}");
            return (Month)inputMonth;

        }
    }
}
