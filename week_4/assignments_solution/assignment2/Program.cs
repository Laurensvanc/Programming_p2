using System;
using System.Collections.Generic;
using System.IO;

namespace assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid number of arguments!");
                Console.WriteLine("usage: assignment[2-3] <filename>");
                return;
            }

            string filename = args[0];

            Program mainProgram = new Program();
            mainProgram.Start();
        }

        void Start()
        {
            HangmanGame hangman = new HangmanGame();

            hangman.Init(SelectWord(WordList()));

            if (PlayHangman(hangman)){
                Console.WriteLine("\n You've won!");
            }
            else
            {
                Console.WriteLine("\n You lost");
            }

            Console.ReadKey();
        }

        string SelectWord(List<string> words)
        {
            Random rng = new Random();

            int index = rng.Next(words.Count);
            string word = words[index];

            while (word.Length <= 3)
            {
                index = rng.Next(words.Count);
                word = words[index];
            }

            return word;
        }

        List<string> WordList()
        {
            List<string> wordsList = new List<string>(File.ReadLines("ListOfWords.txt"));

            return wordsList;
        }

        void ShowWord(string word)
        {
            foreach (char character in word)
            {
                Console.Write($"{character} ");
            }
        }

        char ReadCharacter(List<char> blacklistedChar)
        {
            Console.Write("Enter a character: ");
            char character = Console.ReadKey().KeyChar;
            Console.WriteLine();

            while (blacklistedChar.Contains(character))
            {
                Console.WriteLine("You've already enterd this character");
                Console.Write("Enter a character: ");
                character = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }

            return character;
        }

        void ShowCharacters(List<char> characters)
        {
            Console.Write("Entered letters: ");

            foreach (char character in characters)
            {
                Console.Write($"{character} ");
            }

            Console.WriteLine();
        }

        bool PlayHangman(HangmanGame hangman)
        {
            List<char> enteredChars = new List<char>();
            int amountOfAttempts = 10;

            while (!hangman.IsGuessed() && amountOfAttempts > 0)
            {
                Console.Write("The guessed word is: ");
                ShowWord(hangman.guessedWord);
                Console.WriteLine();

                char enteredChar = ReadCharacter(enteredChars);
                enteredChars.Add(enteredChar);

                if (!hangman.GuessLetter(enteredChar))
                {
                    amountOfAttempts--;
                }

                Console.WriteLine($"Amount of attempts left: {amountOfAttempts}");
                ShowCharacters(enteredChars);
                Console.WriteLine();
            }

            Console.WriteLine($"Word is {hangman.secretWord}");

            return hangman.IsGuessed();
        }
    }

    class HangmanGame
    {
        public string secretWord;
        public string guessedWord;

        public void Init(string secretWord)
        {
            this.secretWord = secretWord;
            this.guessedWord = new String("");

            for (int i = 0; i < secretWord.Length; i++)
            {
                guessedWord = $"{secretWord}.";
            }
        }

        public bool GuessLetter(char letter)
        {
            bool containsLetter = secretWord.Contains(letter);

            if (containsLetter)
            {
                string newGuessed = new string("");

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == letter)
                    {
                        newGuessed = $"{newGuessed}{secretWord[i]}";
                    }else
                    {
                        newGuessed = $"{newGuessed}{guessedWord[i]}";
                    }
                }
                guessedWord = newGuessed;
            }

            return containsLetter;
        }

        public bool IsGuessed()
        {
            return secretWord == guessedWord;
        }
    }
}
