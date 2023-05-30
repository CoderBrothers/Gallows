using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallows
{
    internal class Hangman
    {
        private Dictionary<string, string> words = new()
    {
        { "apple", "Description of apple" },
        { "pineapple", "Description of pineapple" },
        { "orange", "Description of orange" },
        { "grapes", "Description of grapes" },
        { "melon", "Description of melon" },
    };
        private string word;
        private List<char> guessedLetters;
        private int attempts = 6;   

        public void Play()
        {
            word = GetRandomKey();
            guessedLetters = new();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(word);
                Console.WriteLine($"{words[word]}\nAttempts: {attempts}");
                DrawWord();
                Console.WriteLine("Enter a letter:");
                char.TryParse(Console.ReadLine(), out char guess);
                if (!char.IsLetter(guess))
                {
                    Console.WriteLine("Incorrect input. Try again.\nPress any key to continue.");
                    Console.ReadKey();
                    continue;
                }
                if (IsLetterAlreadyGuessed(guess))
                {
                    Console.WriteLine("You already guessed that letter. Try again.\nPress any key to continue.");
                    Console.ReadKey();
                    continue;
                }

                guessedLetters.Add(guess);
                if (word.Contains(guess))
                {
                    Console.WriteLine("Correct guess!");
                }
                else
                {
                    Console.WriteLine("Wrong guess!");
                    attempts--;
                }

                if (attempts == 0)
                {
                    Console.WriteLine("Game over! The word was: " + word);
                }

                if (guessedLetters.SequenceEqual(word))
                {
                    Console.WriteLine("You win!");
                    Console.ReadKey();
                    break;
                }

                Console.ReadKey();
            }
        }

        private string GetRandomKey()
        {
            var keys = words.Keys.ToList();
            Random index = new Random();
            return keys[index.Next(keys.Count)];
        }
        private void DrawWord()
        {
            foreach (var letter in word)
            {
                if (guessedLetters.Contains(letter))
                {
                    Console.Write(letter + " ");
                }
                else
                {
                    Console.Write("* ");
                }
            }
            Console.WriteLine();
        }

        private bool IsLetterAlreadyGuessed(char letter) => guessedLetters.Contains(letter);
    }
}
