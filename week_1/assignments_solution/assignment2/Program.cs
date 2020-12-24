using System;

namespace assignment2
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
            Person[] persons = new Person[3]; // persoon 1, 2 en 3

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = ReadPerson();
                Console.WriteLine("\n");
            }

            for (int i = 0; i < persons.Length; i++)
            {
                PrintPerson(persons[i]);
                Console.WriteLine("\n");
            }

            Console.ReadKey();
        }

        Person ReadPerson()
        {
            Person person;

            person.FirstName = ReadString("Enter first name: ");
            person.LastName = ReadString("Enter last name: ");
            person.Gender = ReadGender("Enter gender (m/f): ");
            person.Age = ReadInt("Enter age: ");
            person.City = ReadString("Enter city: ");

            return person;
        }
        void PrintPerson(Person p)
        {
            Console.Write("{0} {1} ", p.FirstName, p.LastName);

            Console.Write("(");
            PrintGender(p.Gender);
            Console.Write(")\n");

            Console.WriteLine("{0} years old, {1}", p.Age, p.City);
        }

        GenderType ReadGender(string question)
        {
            Console.Write(question);

            string input = Console.ReadLine().ToLower();

            while (input != "m" && input != "f")
            {
                Console.Write("Invalid input.\nEnter gender (m/f): ");
                input = Console.ReadLine();
            }

            if (input == "m")
            {
                return GenderType.Male;
            }
            else
            {
                return GenderType.Female;
            }

        }

        void PrintGender(GenderType gender)
        {
            if (gender == GenderType.Male)
            {
                Console.Write("m");
            }
            else if (gender == GenderType.Female)
            {
                Console.Write("f");
            }
        }

        int ReadInt(string question)
        {
            Console.Write(question);

            int input = int.Parse(Console.ReadLine());

            return input;
        }

        string ReadString(string question)
        {
            Console.Write(question);

            string input = Console.ReadLine();

            return input;
        }
    }
}
