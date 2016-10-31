using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Generator.");
            while (true)
            {
                Console.WriteLine("Please enter a word to convert into Pig Latin");
                string word = Console.ReadLine();
                if (validateInput(word)) // guards against executing the pig latin translation for unacceptable user inputs
                {
                    string pigword = TranslateToPigLatin(word);
                    Console.WriteLine(pigword);
                    Console.WriteLine("Do you wish to continue? (y/n)");
                    string answer = Console.ReadLine();
                    if (answer == "n" || answer == "N")
                        break; //ends loop if user elects to quit
                }
            }
        }
        static bool validateInput(string word)
        {
            char[] unexceptibleChars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '@', '#',
            '$', '%', '^', '&', '*', '(', ')','.',','}; // array for all "unacceptable" characters for the lab, if these are present, method returns false
            
            if (word.Trim() == "")
            {                
                Console.WriteLine("Please actually enter an input.");
                return false; //triggered if the user didn't enter any characters ie. spaces or tabs or nothing
            }
            else
            {
                foreach (char letter in word)
                {
                    if (unexceptibleChars.Contains(letter) == true)
                    {
                        Console.WriteLine("You've included some numbers and/or alphanumeric symbols. Please try again.");
                        return false; //triggered if an "unacceptable" character is present
                    }
                }
            }
            return true;
        } //method to validate that the user entered an acceptable string

        static string TranslateToPigLatin(string word)
        {
            //Variables used to evaluate first index
            string vowels = "aeiou";
            bool isVowel;

            //Convert to lower case
            word = word.ToLower();

            //Test for vowel
            if (vowels.Contains(word[0]) == true)
            {
                isVowel = true;
            }
            else
            {
                isVowel = false;
            }

            //Adding 'way' to end
            if (isVowel == true)
            {
                word = word + "way";
            }

            //Pre vowel consonsants moved to end / adding 'ay'
            else
            {
                char[] vowelArray = { 'a', 'e', 'i', 'o', 'u' };
                int vowelIndex = word.IndexOfAny(vowelArray);
                string word1 = word.Substring(0, vowelIndex);
                string word2 = word.Substring(vowelIndex);
                word = word2 + word1 + "ay";
            }
            return word;
        }// method to translate an acceptable user input to pig latin
    }
}