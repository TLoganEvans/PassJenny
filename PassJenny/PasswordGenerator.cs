using System.Text;
using System;

namespace Core
{
    public class PasswordGenerator
    {
        public static string GeneratePassword(string passLength, bool upperBool, bool numBool, bool specBool)
        {

            string validChars = "abcdefghijklmnopqrstuvwxyz";

            string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numChars = "0123456789";
            string specialChars = "@!#$%^&*";

            StringBuilder generatedPassword = new StringBuilder();
            int length = Int32.Parse(passLength);

            if (upperBool == true)
            {
                validChars += upperChars;
            }
            if (numBool == true)
            {
                validChars += numChars;
            }
            if (specBool == true)
            {
                validChars += specialChars;
            }

            Random rnd = new Random();
            while (0 < length--)
            {
                generatedPassword.Append(validChars[rnd.Next(validChars.Length)]);
            }

            return generatedPassword.ToString();
        }
    }
}