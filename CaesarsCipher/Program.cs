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
            string cipherText = "";

            if (shift == 0)  {return text;}

            for (int i = 0; i < text.Length; i++)
            {
                //Check if charater is lowerCase
                if (text[i] >= 'a' && text[i] <= 'z')
                {
                    int temp = Convert.ToInt32(text[i]) + letterShift;
                    if (temp < 97) { temp += 26;}
                    if (temp > 122) { temp -= 26;}
                    cipherText += Convert.ToChar(temp);
                }
                //Check if charater is upperCase.
                else if (text[i] >= 'A' && text[i] <= 'Z')
                {
                    int temp = Convert.ToInt32(text[i]) + letterShift;
                    if (temp < 65) { temp += 26; }
                    if (temp > 90) { temp -= 26; }
                    cipherText += Convert.ToChar(temp);
                }
                //Check if charater is number 0-9.
                else if (text[i] >= '0' && text[i] <= '9')
                {
                    int temp = Convert.ToInt32(text[i]) + numberShift;
                    if (temp < 48) { temp += 10; }
                    if (temp > 57) { temp -= 10; }
                    cipherText += Convert.ToChar(temp); ;
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

