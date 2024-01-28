using MDRC.Models;
using System.ComponentModel.DataAnnotations;

namespace MDRC.Web.ViewModels
{
    public class AddUpdateEventViewModel : IErrorHandlingViewModel
    {
        public AddUpdateEventViewModel()
        {
            AddUpdateEventModel = new AddUpdateEventModel();
        }

        public AddUpdateEventModel AddUpdateEventModel { get; set; }

        public Guid? EventId { get => AddUpdateEventModel.EventId; set => AddUpdateEventModel.EventId = value; }

        [Display(Name = "Event Name:")]
        public string EventName { get => AddUpdateEventModel.EventName; set => AddUpdateEventModel.EventName = value; }

        [Display(Name = "Start Date and Time:")]
        public DateTimeOffset StartDate { get => AddUpdateEventModel.StartDate; set => AddUpdateEventModel.StartDate = value; }

        [Display(Name = "End Date and Time:")]
        public DateTimeOffset? EndDate { get => AddUpdateEventModel.EndDate; set => AddUpdateEventModel.EndDate = value; }

        public string StartDateString => Uri.EscapeDataString(StartDate.ToString("O")) ?? string.Empty;

        public string EndDateString => Uri.EscapeDataString(EndDate?.ToString("O") ?? string.Empty);

        [Display(Name = "Is this event swipe granting?")]
        public bool IsSwipeGranting { get => AddUpdateEventModel.IsSwipeGranting; set => AddUpdateEventModel.IsSwipeGranting = value; }

        public string? SuccessMessage { get => AddUpdateEventModel.SuccessMessage; }

        public string? WarningMessage { get => AddUpdateEventModel.WarningMessage; }

        public string? ErrorMessage { get => AddUpdateEventModel.ErrorMessage; }
    }
}