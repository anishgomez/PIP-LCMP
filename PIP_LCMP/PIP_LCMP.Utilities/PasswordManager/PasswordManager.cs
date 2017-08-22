using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Utilities.PasswordManager
{
    public class PasswordManager : IPasswordManager
    {
        /// <summary>
        /// Returns MD5 hash of the password string
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetMD5Hash(string password)
        {
            using (MD5 MD5Hash = MD5.Create())
            {
                byte[] data = MD5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    sBuilder.Append(data[i].ToString("x2"));
                return sBuilder.ToString();
            }
        }

        /// <summary>
        /// Verifies the password against the MD5 password hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public bool VerifyMD5Hash(string password, string passwordHash)
        {
            using (MD5 MD5Hash = MD5.Create())
            {
                var hashedPassword = GetMD5Hash(password);
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;
                if (comparer.Compare(hashedPassword, passwordHash) == 0)
                    return true;
                else return false;
            }
        }
        /// <summary>
        /// Generates Random Password
        /// </summary>
        /// <param name="passwordLength"></param>
        /// <returns></returns>
        //public string GenerateRandomPlainPassword(int passwordLength)
        //{
        //    string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    char[] chars = new char[passwordLength];
        //    Random random = new Random();
        //    var password = Membership.GeneratePassword(passwordLength, 1);
        //    return Regex.Replace(password, "[^0-9A-Za-z]", allowedChars[random.Next(0, allowedChars.Length)].ToString());
        //}
    }
}
