using PrimeITELLER.Models.AuthenticationModel.GetUserDetailsModel;
using PrimeITELLER.Models.AuthenticationModel.ValidateUser;
using PrimeITELLER.Models.GetUserModel;
using PrimeITELLER.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PrimeITELLER.Repository.Authentication
{
    public interface IAuthentication : IDisposable
    {

        ValidateOutput ValidateUser(ValidateInput Model);

        GetUserDetailsOutput GetUserDetails(ValidateInput Model);

        LogResultModel GetUser(LogInputModel Model);


       

    }
}