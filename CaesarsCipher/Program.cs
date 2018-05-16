using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarsCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Split string
            string userInput = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(userInput))
            {
                try
                {
                    string[] temp = userInput.Split(':');
                    int shift = Convert.ToInt32(temp[0]);
                    if (shift > 1000000000 || shift < -1000000000)
                        throw new IndexOutOfRangeException();
                    string text = temp[1];
                    string ciperText = GetCaesarsCipher(text, shift);
                    Console.WriteLine(ciperText);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine(e);
                }
                

            }
        }

        private static string GetCaesarsCipher(string text, int shift)
        {
            //Get shifts for numbers and letters
            int numberShift = shift % 10;
            int letterShift = shift % 26;
            //Set arrays
            char[] lowerCase = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] numbers = "0123456789".ToCharArray();
            string cipherText = "";

            if (shift == 0)  {return text;}

            for (int i = 0; i < text.Length; i++)
            {
                //Check if charater is lowerCase
                if (text[i] >= 'a' && text[i] <= 'z')
                {
                    int index = Array.IndexOf(lowerCase, text[i]);
                    index += letterShift;
                    if (index < 0) { index += 26;}
                    if (index > 25) { index -= 26;}

                    cipherText += lowerCase[index];
                }
                //Check if charater is upperCase.
                else if (text[i] >= 'A' && text[i] <= 'Z')
                {
                    int index = Array.IndexOf(upperCase, text[i]);
                    index += letterShift;
                    if (index < 0) { index += 26; }
                    if (index > 25) { index -= 26; }

                    cipherText += upperCase[index];
                }
                //Check if charater is number 0-9.
                else if (text[i] >= '0' && text[i] <= '9')
                {
                    int index = Array.IndexOf(numbers, text[i]);
                    index += numberShift;
                    if (index < 0) { index += 10; }
                    if (index > 9) { index -= 10; }

                    cipherText += numbers[index];
                }
                //Otherwise, do nothing to it.
                else
                {
                    cipherText += text[i];
                }
            }
            return cipherText;
        }
    }
}

