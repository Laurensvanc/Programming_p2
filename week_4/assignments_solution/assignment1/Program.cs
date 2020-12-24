using System;
using System.IO;
using System.Reflection;

namespace assignment1
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
            string userName;
            Person person;

            Console.Write(String.Format("Enter your name: "));
            userName = Console.ReadLine();

            if (!File.Exists($"{userName}.txt")) {

                Console.WriteLine($"Welcome {userName}!");
                WritePerson(ReadPerson(), $"{userName}.txt");
            } else
            {
                Console.WriteLine($"Nice to see you again, {userName}!");
                Console.WriteLine("We have the following information about you: ");
                using (StreamReader sr = new StreamReader($"{userName}.txt"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            Console.ReadKey();

        }

        Person ReadPerson()
        {
            Person person = new Person();

            Console.Write("Enter your name: ");
            person.name = Console.ReadLine();

            Console.Write("Enter your city: ");
            person.city = Console.ReadLine();

            Console.Write("Enter your age: ");
            person.age = int.Parse(Console.ReadLine());

            return person;
        }

        void DisplayPerson(Person p)
        {
            Console.WriteLine(String.Format("{0,-8} : {1, 0}", "Name", p.name));
            Console.WriteLine(String.Format("{0,-8} : {1, 0}", "City", p.city));
            Console.WriteLine(String.Format("{0,-8} : {1, 0}", "Age", p.age));
        }

        void WritePerson(Person p, string filename)
        {
            StreamWriter sw = new StreamWriter(filename);

            sw.WriteLine("{0} : {1}", "Name", p.name);
            sw.WriteLine("{0} : {1}", "City", p.city);
            sw.WriteLine("{0} : {1}", "Age", p.age);

            Console.WriteLine("Your data is written to file.");

            sw.Close();
        }
    }
}
