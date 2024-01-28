using MDRC.Models;

namespace MDRC.Web.ViewModels
{
    public class ErrorMesssageViewModel : IErrorHandlingViewModel
    {
        public ErrorMesssageViewModel()
        {
            ErrorMesssageModel = new ErrorMesssageModel();
        }

        public ErrorMesssageModel ErrorMesssageModel { get; set; }

        public string? SuccessMessage => ErrorMesssageModel.SuccessMessage;

        public string? WarningMessage => ErrorMesssageModel.WarningMessage;

        public string? ErrorMessage => ErrorMesssageModel.ErrorMessage;

    }
}