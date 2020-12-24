using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace assignment2
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
            HangmanGame hangman = new HangmanGame();

            hangman.Init(SelectWord(ListOfWords()));

            if (PlayHangMan(hangman))
            {
                Console.WriteLine("\nYou guessed the word!");
            }
            else
            {
                Console.WriteLine($"\nToo bad, you did not guess the word: {hangman.secretWord}");
            }

            Console.ReadKey();
        }

        void DisplayWord(string word)
        {
            foreach (char character in word)
            {
                Console.Write($"{character}");
            }
        }

        void DisplayLetters(List<char> letters)
        {
            Console.Write("Entered letters: ");

            foreach (char character in letters)
            {
                Console.Write($"{character} ");
            }

            Console.WriteLine();
        }

        char ReadLetter(List<char> blacklistLetters)
        {
            Console.Write("Enter a letter: ");
            char character = Console.ReadKey().KeyChar;
            Console.WriteLine();

            while (blacklistLetters.Contains(character))
            {
                Console.WriteLine("Word arleady contains letter.");

                Console.Write("Enter a letter: ");
                character = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }

            return character;
        }

        bool PlayHangMan(HangmanGame hangman)
        {
            List<char> enteredLetters = new List<char>();
            int tries = 10;

            while (tries > 0 && !hangman.IsGuessed()) 
            {
                Console.Write("");
                DisplayWord(hangman.guessedWord);
                Console.WriteLine();

                char enteredLetter = ReadLetter(enteredLetters);
                enteredLetters.Add(enteredLetter);

                if (!hangman.ContainsLetter(enteredLetter))
                {
                    tries--;
                }

                Console.WriteLine($"Attempts left: {tries}");
                DisplayLetters(enteredLetters);
                Console.WriteLine();
            }
            return false;
        }

        string SelectWord(List<string> word)
        {
            Random rnd = new Random();
            int selectedWord = rnd.Next(word.Count);

            return word[selectedWord];
        }

        List<string> ListOfWords()
        {
            List<string> listOfWords = new List<string>();

            listOfWords.Add("airplane");
            listOfWords.Add("kitchen");
            listOfWords.Add("building");
            listOfWords.Add("incredible");
            listOfWords.Add("funny");
            listOfWords.Add("trainstation");
            listOfWords.Add("neighbour");
            listOfWords.Add("different");
            listOfWords.Add("department");
            listOfWords.Add("planet");
            listOfWords.Add("presentation");
            listOfWords.Add("embarrassment");
            listOfWords.Add("integration");
            listOfWords.Add("scenario");
            listOfWords.Add("discount");
            listOfWords.Add("management");
            listOfWords.Add("understanding");
            listOfWords.Add("registration");
            listOfWords.Add("security");
            listOfWords.Add("language");

            return listOfWords;
        }
    }

    class HangmanGame
    {
        public string secretWord;
        public string guessedWord;

        public void Init(string secretWord)
        {
            string[] secret = secretWord.Split("");
            guessedWord = new string("");

            for (int i = 0; i < secret.Length; i++)
            {
                guessedWord = $"{guessedWord}.";
            }
        }

        public bool ContainsLetter(char letter)
        {
            bool containsLetter = secretWord.Contains(letter);

            if (containsLetter)
            {
                string newLetter = new string("");

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == letter)
                    {
                        newLetter = $"{newLetter}{secretWord[i]}";
                    }
                    else
                    {
                        newLetter = $"{newLetter}{secretWord[i]}";
                    }
                }

                guessedWord = newLetter;
            }

            return containsLetter;
        }

        public void ProcessLetter(char letter)
        {
            
        }

        public bool IsGuessed()
        {
            return secretWord == guessedWord;
        }
    }
}
