using Microsoft.IdentityModel.Tokens;
using PIP_LCMP.Utilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PIP_LCMP.Authorization.TokenManager
{
    public class TokenManager : ITokenManager
    {
        /// <summary>
        /// Generates token for the user
        /// </summary>
        /// <param name="tokenRequestModel"></param>
        /// <returns></returns>
        public string GenerateToken(TokenRequestModel tokenRequestModel)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var securityKey = GetBytes(Constants.JWTTokenSecurityKey);
                var dateTime = DateTime.Now;
                List<Claim> claimList = new List<Claim>();
                claimList.Add(new Claim(ClaimTypes.Name, tokenRequestModel.UserName));
                claimList.Add(new Claim("UserId", tokenRequestModel.UserId.ToString()));
                Claim[] claims = claimList.ToArray();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Issuer = Constants.JWTTokenIssuer,
                    Expires = dateTime.AddMinutes(Constants.TokenExpiry),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return new System.Net.Http.Headers.AuthenticationHeaderValue("BEARER", tokenString).ToString();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Validates user token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ValidateToken(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                    throw new ArgumentNullException(Constants.UnauthorizedMessage);
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtRead = tokenHandler.ReadToken(token) as JwtSecurityToken;
                var securityKey = GetBytes(Constants.JWTTokenSecurityKey);
                TokenValidationParameters validParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Constants.JWTTokenIssuer,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(securityKey),
                };
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validParameters, out validatedToken);
                HttpContext.Current.User = principal;
                return true;
            }
            catch
            {
                throw;
            }
        }

        private static byte[] GetBytes(string input)
        {
            var bytes = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public int GetUserIdFromToken(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                    throw new ArgumentNullException(Constants.UnauthorizedMessage);
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtRead = tokenHandler.ReadToken(token) as JwtSecurityToken;
                var userId = jwtRead.Claims.SingleOrDefault(it => it.Type.Contains("UserId")).Value;
                return Convert.ToInt32(userId);
            }
            catch
            {
                throw;
            }
        }
    }
}
