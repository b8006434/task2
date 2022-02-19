using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollSystemServices
{
    public static class DataHelper
    {

        /// <summary>
        /// Log user in and return the current user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User LogInUser(string userName, string password)
        {
            string hashedPassword = Validation.HashPassword(password);
            return DataConnection.LoginUser(userName, hashedPassword);
        }

        /// <summary>
        /// Refresh user details
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User RefreshUser(string username, string password)
        {
            return DataConnection.LoginUser(username, password);
        }

        /// <summary>
        /// Check if given email is already in the system
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckForExistingEmail(string email)
        {
            return DataConnection.CheckForExistingEmail(email);
        }

        /// <summary>
        /// Convert first letter of a given string to upper char
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

    }
}
