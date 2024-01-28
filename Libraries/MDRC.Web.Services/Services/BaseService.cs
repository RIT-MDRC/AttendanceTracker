using MDRC.Models;

namespace MDRC.Services
{
    public class BaseService
    {
        public ErrorMesssageModel CreateErrorMessagePayload(string? successMessage = "", string? warningMessage = "", string? errorMessage = "")
        {
            return new ErrorMesssageModel
            {
                SuccessMessage = string.IsNullOrEmpty(successMessage) ? null : Uri.EscapeDataString(successMessage),
                WarningMessage = string.IsNullOrEmpty(warningMessage) ? null : Uri.EscapeDataString(warningMessage),
                ErrorMessage = string.IsNullOrEmpty(errorMessage) ? null : Uri.EscapeDataString(errorMessage)
            };
        }
    }
}