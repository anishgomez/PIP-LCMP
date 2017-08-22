using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Authorization.TokenManager
{
    public interface ITokenManager
    {
        /// <summary>
        /// Generates token for the user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        string GenerateToken(TokenRequestModel tokenRequestModel);
        /// <summary>
        /// Validates user token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool ValidateToken(string token);

        int GetUserIdFromToken(string token);
    }
}
