using MDRC.Models;
using System.ComponentModel.DataAnnotations;

namespace MDRC.Web.ViewModels
{
    public class SwipeViewModel : IErrorHandlingViewModel
    {
        public SwipeViewModel()
        {
            SwipeModel = new SwipeModel();
        }

        public SwipeModel SwipeModel { get; set; }

        public string EventName { get => SwipeModel.EventName; set => SwipeModel.EventName = value; }

        [Display(Name = "Please swipe your RIT ID")]
        public string SwipeReading { get => SwipeModel.SwipeReading; set => SwipeModel.SwipeReading = value; }

        public int? UniversityId { get => SwipeModel.UniversityId; set => SwipeModel.UniversityId = value; }

        public Guid? EventId { get => SwipeModel.EventId; set => SwipeModel.EventId = value; }
        
        public string? SuccessMessage { get => SwipeModel.SuccessMessage; }

        public string? WarningMessage { get => SwipeModel.WarningMessage; }

        public string? ErrorMessage { get => SwipeModel.ErrorMessage; }
    }
}