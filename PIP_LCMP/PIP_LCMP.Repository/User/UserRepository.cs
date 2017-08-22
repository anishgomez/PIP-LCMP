using System;
using PIP_LCMP.BusinessEntities.Account;
using PIP_LCMP.DataEntities;
using PIP_LCMP.Repositories.ContextProvider;
using AutoMapper;
using System.Linq.Expressions;
using PIP_LCMP.Utilities.PasswordManager;

namespace PIP_LCMP.Repositories.User
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        private IMapper _mapper;
        private IPasswordManager _passwordManager;
        public UserRepository(IDbContextProvider dbContextProvider, IPasswordManager passwordManager)
            : base(dbContextProvider)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Users, UserModel>()
           );
            _mapper = config.CreateMapper();
            _passwordManager = passwordManager;
        }

        public UserModel AuthenticateUser(LoginRequestModel loginModel)
        {
            var hashedPassword = _passwordManager.GetMD5Hash(loginModel.Password);
            Expression<Func<Users, bool>> predicate = (it => it.UserName == loginModel.UserName && it.Password == hashedPassword);
            var user = GetOne(predicate);
            if (user != null)
                return _mapper.Map<Users, UserModel>(user);
            return null;

        }
    }
}
