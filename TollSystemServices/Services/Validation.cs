using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TollSystemServices.Enums;

namespace TollSystemServices
{
    /// <summary>
    /// Helper class for validation of data
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// The property to generate a random number
        /// </summary>
        private static Random Random = new Random();

        /// <summary>
        /// Generate bitmap image file for captcha
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap CaptchaToImage(string text, int width, int height)
        {
            //Create a new bitmap with the given width and height, and convert this to the Graphics object for drawing
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush sb = new SolidBrush(Color.White);

            //Set the background and the image properties
            g.FillRectangle(sb, 0, 0, bmp.Width, bmp.Height);
            Font font = new Font("Tahoma", 45);
            sb = new SolidBrush(Color.Black);
            g.DrawString(text, font, sb, bmp.Width / 2 - (text.Length / 2) * font.Size, (bmp.Height / 2) - font.Size);

            //Draw the random characters
            int count = 0;
            Random rand = new Random();
            while (count < 1000)
            {
                sb = new SolidBrush(Color.YellowGreen);
                g.FillEllipse(sb, rand.Next(0, bmp.Width), rand.Next(0, bmp.Height), 4, 2);
                count++;
            }

            //Draw over the random characters to make it difficult for AI to recognize the characters
            count = 0;
            while (count < 25)
            {
                g.DrawLine(new Pen(Color.Bisque), rand.Next(0, bmp.Width), rand.Next(0, bmp.Height), rand.Next(0, bmp.Width), rand.Next(0, bmp.Height));
                count++;
            }

            //Return the created image
            return bmp;
        }

        /// <summary>
        /// Generate a random string for captcha
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            //Allowed characters to be used for random generation
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// See if the passed string is in a valid email address format
        /// </summary>
        /// <param name="eMail"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string eMail)
        {
            bool Result = false;

            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(eMail);

                Result = (eMail.LastIndexOf(".") > eMail.LastIndexOf("@"));
            }
            catch
            {
                Result = false;
            };

            return Result;
        }

        /// <summary>
        /// Check that the password is secure enough
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static PasswordScore CheckPasswordStrength(string password)
        {
            int score = 0;

            if (password.Length < 1)
            {
                return PasswordScore.Blank;
            }

            else if (password.Length < 4)
            {
                return PasswordScore.VeryWeak;
            }

            if (password.Length >= 8)
            {
                score++;
            }
            if (password.Length >= 12)
            {
                score++;
            }
            if (Regex.Match(password, @"\d+", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
            if (Regex.Match(password, @".[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
            {
                score++;
            }

            return (PasswordScore)score;
        }

        /// <summary>
        /// Check that a string is not empty and contains character
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool CheckForValidString(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check that a string contains only numbers
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool CheckStringIsDigitOnly(string text)
        {
            if (CheckForValidString(text))
            {
                return text.All(c => c >= '0' && c <= '9' || (c == '.' || c == ','));
            }

            return false;
        }

        /// <summary>
        /// Return password in a hashed format for security
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }

        /// <summary>
        /// Compare two passwords and see if they have changed
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static bool CheckIfPasswordChanged(int userID, string newPassword)
        {
            string oldPassword = DataConnection.ReturnUserHashedPassword(userID);

            if (oldPassword != newPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
