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
            //validateInput(word);
            string pigword = TranslateToPigLatin(word);
            Console.WriteLine(pigword);
            Console.WriteLine("Do you wish to continue? (y/n)");
            string answer = Console.ReadLine();
            if (answer == "n" || answer == "N")
                break;
            }
        }
       // static void validateInput(word)
       // {
        

        //}
        static string TranslateToPigLatin(string word)
        {
            //Variables used to evaluate first index
            string vowels = "aeiou";
            bool isVowel;
            
            //Convert to lower case
            word = word.ToLower();
            
            //Test for vowel
            if (vowels.Contains(word[0])==true)
            {
                isVowel = true;
            } 
            else
            {
                isVowel = false;              
            }
            
            //Adding 'way' to end
            if (isVowel==true)
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
        }
    }
}