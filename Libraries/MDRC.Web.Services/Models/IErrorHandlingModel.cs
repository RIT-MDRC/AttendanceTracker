namespace MDRC.Models
{
    public interface IErrorHandlingModel
    {
        public string? SuccessMessage { get; set; }

        public string? WarningMessage { get; set; }

        public string? ErrorMessage { get; set; }

    }
}