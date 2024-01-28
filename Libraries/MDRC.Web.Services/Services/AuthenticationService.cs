using MDRC.Models;
using System.Security.Claims;
using MDRC.Data;
using Microsoft.EntityFrameworkCore;
using MDRC.Data.Models;

namespace MDRC.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly string EXISTING_MEMBER_MESSAGE = "An active user exists with MemberId: \"{0}\"";
        private readonly string NO_MEMBER_MESSAGE = "There is no member with this UniversityId: \"{0}\"";

        public ErrorMesssageModel Login(string? successMessage = "", string? warningMessage = "", string? errorMessage = "")
        {
            return CreateErrorMessagePayload(successMessage, warningMessage, errorMessage);
        }

        public CreateAccountModel CreateAccount(MDRCSiteDbContext siteContext, int universityId)
        {
            var userAccount = siteContext.UserAccounts.AsNoTracking().SingleOrDefault(ua => ua.MemberId == universityId && ua.IsActive);

            if (userAccount != null)
            {
                throw new InvalidDataException(string.Format(EXISTING_MEMBER_MESSAGE, universityId));
            }

            var member = siteContext.Members.Single(m => m.UniversityId == universityId);

            return new CreateAccountModel
            {
                FullName = string.Format("{0} {1}", member.GivenName, member.FamilyName),
                UniversityId = universityId
            };

        }

        public void CreateNewAccount(MDRCSiteDbContext siteContext, NewAccountModel newAccount)
        {
            var member = siteContext.Members.AsNoTracking().SingleOrDefault(m => m.UniversityId == newAccount.UniversityId && m.IsActive);

            if (member == null)
            {
                throw new InvalidDataException(string.Format(NO_MEMBER_MESSAGE, newAccount.UniversityId));
            }

            var userAccount = siteContext.UserAccounts.AsNoTracking().SingleOrDefault(ua => ua.MemberId == newAccount.UniversityId && ua.IsActive);

            if (userAccount != null)
            {
                throw new InvalidDataException(string.Format(EXISTING_MEMBER_MESSAGE, newAccount.UniversityId));
            }

            siteContext.UserAccounts.Add(new UserAccount
            {
                Username = newAccount.Username,
                Password = newAccount.Password,
                MemberId = newAccount.UniversityId,
                IsActive = true
            });
            siteContext.SaveChanges();
        }

        public AuthenticationModel? Submit(MDRCSiteDbContext siteContext, SignInModel signInRequest)
        {
            var userAccount = siteContext.UserAccounts.SingleOrDefault(ua => ua.Username == signInRequest.Username && ua.IsActive);

            if (userAccount == null || userAccount.Password != signInRequest.PasswordHash)
            {
                return null;
            }

            var member = siteContext.Members.Single(m => m.UniversityId == userAccount.MemberId && m.IsActive);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, member.GivenName + " " + member.FamilyName),
                    new Claim(ClaimTypes.GivenName, member.GivenName),
                    new Claim("UniversityId", member.UniversityId.ToString()),
                };

            return new AuthenticationModel
            {
                Claims = claims,
                IsPersistent = signInRequest.RememberMe
            };
        }

    }
}