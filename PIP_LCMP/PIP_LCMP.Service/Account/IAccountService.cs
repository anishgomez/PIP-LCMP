using PIP_LCMP.BusinessEntities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Services.Account
{
    public interface IAccountService
    {
        LoginResponseModel ValidateLogin(LoginRequestModel loginModel);
    }
}
