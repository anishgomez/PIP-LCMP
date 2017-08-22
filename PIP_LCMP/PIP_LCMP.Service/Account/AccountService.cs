using PIP_LCMP.Repositories.User;
using PIP_LCMP.BusinessEntities.Account;
using PIP_LCMP.Utilities.PasswordManager;
using PIP_LCMP.Authorization.TokenManager;

namespace PIP_LCMP.Services.Account
{
    public class AccountService : IAccountService
    {
        private IUserRepository _userRepository;
        private IPasswordManager _passwordManager;
        private ITokenManager _tokenManager;
        public AccountService(IUserRepository userRepository, IPasswordManager passwordManager, ITokenManager tokenManager)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _tokenManager = tokenManager;
        }

        public LoginResponseModel ValidateLogin(LoginRequestModel loginModel)
        {
            var hashedPassword = _passwordManager.GetMD5Hash(loginModel.Password);
            var userModel = _userRepository.AuthenticateUser(loginModel);
            if (userModel != null)
            {
                var tokenRequestModel = new TokenRequestModel { UserName = loginModel.UserName, Password = loginModel.Password, UserId = userModel.Id};
                var token = _tokenManager.GenerateToken(tokenRequestModel);
                return new LoginResponseModel
                {
                    EmailId = userModel.EmailId,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Token = token
                };
            }
            return null;
        }
    }
}
