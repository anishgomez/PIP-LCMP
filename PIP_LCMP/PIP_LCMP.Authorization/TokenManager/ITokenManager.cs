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
        /// <param name="tokenRequestModel"></param>
        /// <returns></returns>
        string GenerateToken(TokenRequestModel tokenRequestModel);
        /// <summary>
        /// Validates user token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool ValidateToken(string token);

        /// <summary>
        /// Gets UserId from token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        int GetUserIdFromToken(string token);
    }
}
