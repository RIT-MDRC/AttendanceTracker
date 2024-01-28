using MDRC.Models;

namespace MDRC.Services
{
    public interface IBaseService
    {
        public ErrorMesssageModel CreateErrorMessagePayload(string successMessage = "", string warningMessage = "", string errorMessage = "");
    }
}