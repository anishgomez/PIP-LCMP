using PIP_LCMP.BusinessEntities.Account;
using PIP_LCMP.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Repositories.User
{
    public interface IUserRepository
    {
        UserModel AuthenticateUser(LoginRequestModel loginModel);
    }
}
