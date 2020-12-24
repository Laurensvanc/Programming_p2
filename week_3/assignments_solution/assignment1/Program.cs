using System;
using System.Linq;
using System.Collections.Generic;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program mainProgram = new Program();
            mainProgram.Start();
        }

        void Start()
        {
            List<Course> gradeList = new List<Course>();

            gradeList = ReadGradeList(3);

            DisplayGradeList(gradeList);
            Console.ReadKey();
        }

        void DisplayGradeList(List<Course> gradeList)
        {
            int perfect = 0;
            int successfull = 0;
            int retakes = 0;
            int count = 0;

            foreach (Course grade in gradeList)
            {
                DisplayCourse(grade);

                if (!grade.Passed())
                {
                    if (!grade.CumLaude())
                    {
                        perfect++;
                    }
                    successfull++;
                }
                else
                {
                    retakes++;
                }
                count++;
            }

            if (retakes > 0)
            {
                Console.WriteLine($"Too bad, you did not graduate, you got {retakes} retakes.");
            }
            else if (perfect == count)
            {
                Console.WriteLine("Congratulations, you graduated Cum Laude!");
            }
            else
            {
                Console.WriteLine("Congratulations, you graduated!");
            }

        }

        PracticalGrade ReadPracticalGrade(string question)
        {
            PracticalGrade grade = new PracticalGrade();

            Console.WriteLine("0. None 1. Absent 2. Insufficent 3. Sufficient 4. Good");
            Console.Write(question);

            Console.ForegroundColor = ConsoleColor.Green;
            grade = (PracticalGrade)int.Parse(Console.ReadLine());

            Console.ResetColor();
            return grade;
        }

        List<Course> ReadGradeList(int nrOfCourses)
        {
            List<Course> gradeList = new List<Course>();

            for (int i = 0; i < nrOfCourses; i++)
            {
                Course grade = ReadCourse("Enter a course.");
                gradeList.Add(grade);
                Console.WriteLine();
            }

            return gradeList;
        }

        void DisplayPracticalGrade(PracticalGrade practical)
        {

        }

        Course ReadCourse(string question)
        {
            Course course = new Course();
            Console.WriteLine(question);

            course.Name = ReadString("Name of the course: ");
            course.Grade = ReadInt($"Grade for {course.Name}: ");
            course.Practical = ReadPracticalGrade($"Practical grade for {course.Name}: ");

            return course;
        }

        void DisplayCourse(Course course)
        {
            Console.WriteLine(String.Format("{0,-14}  : {1,2} {2,3}", course.Name, course.Grade, course.Practical));
        }

        // Methods from week 1
        int ReadInt(string question)
        {
            Console.Write(question);

            Console.ForegroundColor = ConsoleColor.Green;
            int input = int.Parse(Console.ReadLine());

            Console.ResetColor();
            return input;
        }

        int ReadInt(string question, int min, int max)
        {
            Console.Write(question);

            Console.ForegroundColor = ConsoleColor.Green;
            int input = int.Parse(Console.ReadLine());

            if (input > max || input < min)
            {
                input = ReadInt(question, min, max);
            }

            Console.ResetColor();
            return input;
        }

        string ReadString(string question)
        {
            Console.Write(question);

            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ResetColor();

            return input;
        }
    }

    class Course
    {
        public string Name;
        public int Grade;
        public PracticalGrade Practical;

        public bool Passed()
        {
            if (Practical >= PracticalGrade.Sufficient && Grade >= 55)
            {
                return true;
            }

            return false;
        }
        public bool CumLaude()
        {
            if (Practical >= PracticalGrade.Good && Grade >= 80)
            {
                return true;
            }

            return false;
        }
    }

    enum PracticalGrade
    {
        None,
        Absent,
        Insufficient,
        Sufficient,
        Good
    }
}
