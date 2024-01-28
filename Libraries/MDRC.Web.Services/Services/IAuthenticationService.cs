using MDRC.Data;
using MDRC.Models;

namespace MDRC.Services
{
    public interface IAuthenticationService : IBaseService
    {
        ErrorMesssageModel Login(string? successMessage = "", string? warningMessage = "", string? errorMessage = "");

        CreateAccountModel CreateAccount(MDRCSiteDbContext siteContext, int universityId);

        void CreateNewAccount(MDRCSiteDbContext siteContext, NewAccountModel newAccount);

        AuthenticationModel? Submit(MDRCSiteDbContext siteContext, SignInModel signInRequest);

    }
}