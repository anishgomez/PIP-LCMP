using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Utilities.PasswordManager
{
    public interface IPasswordManager
    {
        /// <summary>
        /// Returns MD5 hash of the password string
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string GetMD5Hash(string password);
        /// <summary>
        /// Verifies the password against the MD5 password hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        bool VerifyMD5Hash(string password, string passwordHash);

        /// <summary>
        /// Generates Random Password
        /// </summary>
        /// <param name="passwordLength"></param>
        /// <returns></returns>
        //string GenerateRandomPlainPassword(int passwordLength = 5);

    }
}
