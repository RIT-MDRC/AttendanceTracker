namespace MDRC.Models
{
    public class ErrorMesssageModel
    {
        private string? _successMessage;
        private string? _warningMessage;
        private string? _errorMessage;

        public string? SuccessMessage { get => _successMessage; set { _successMessage = string.IsNullOrEmpty(value) ? null : Uri.UnescapeDataString(value); } }
        public string? WarningMessage { get => _warningMessage; set { _warningMessage = string.IsNullOrEmpty(value) ? null : Uri.UnescapeDataString(value); } }
        public string? ErrorMessage { get => _errorMessage; set { _errorMessage = string.IsNullOrEmpty(value) ? null : Uri.UnescapeDataString(value); } }
    }
}