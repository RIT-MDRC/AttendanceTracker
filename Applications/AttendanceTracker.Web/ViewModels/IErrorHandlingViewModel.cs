using MDRC.Models;

namespace MDRC.Web.ViewModels
{
    public interface IErrorHandlingViewModel
    {
        public string? SuccessMessage { get; }

        public string? WarningMessage { get; }

        public string? ErrorMessage { get; }

    }
}