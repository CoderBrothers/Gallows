using System;
using System.Collections.Generic;
namespace Gallows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hangman hangman = new();
            hangman.Play();
        }
    }
}
