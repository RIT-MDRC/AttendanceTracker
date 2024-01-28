using MDRC.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MDRC.Web.ViewModels
{
    public class ManualEntryViewModel : IErrorHandlingViewModel
    {
        public ManualEntryViewModel()
        {
            ManualEntryModel = new ManualEntryModel();
            SwipeModel = new SwipeModel();
        }
        
        public ManualEntryModel ManualEntryModel { get; set; }

        public SwipeModel SwipeModel { get; set; }

        public IEnumerable<SelectListItem> MemberList
        {
            get
            {
                return ManualEntryModel.MemberList?.Select(m => new SelectListItem
                {
                    Text = m.FullName,
                    Value = m.UniversityId.ToString()
                }) ?? new List<SelectListItem>();
            }
        }

        [Display(Name = "Member:")]
        public int? UniversityId { get => SwipeModel.UniversityId; set => SwipeModel.UniversityId = value; }

        public int RequesterUniversityId { get => ManualEntryModel.RequesterUniversityId; set => ManualEntryModel.RequesterUniversityId = value; }

        public IEnumerable<SelectListItem> EventList
        {
            get
            {
                return ManualEntryModel.EventList?.Select(m => new SelectListItem
                {
                    Text = m.EventName,
                    Value = m.EventId.ToString(),
                    Selected = EventId != null && EventId == m.EventId
                }) ?? new List<SelectListItem>();
            }
        }

        [Display(Name = "Event:")]
        public Guid? EventId { get => ManualEntryModel.EventId ?? SwipeModel.EventId; set => SwipeModel.EventId = value; }

        [Display(Name = "Swipe Time:")]
        public DateTimeOffset SwipeDate { get => SwipeModel.SwipeDate; set => SwipeModel.SwipeDate = value; }

        public string? SuccessMessage { get => ManualEntryModel.SuccessMessage; set => ManualEntryModel.SuccessMessage = value; }

        public string? WarningMessage { get => ManualEntryModel.WarningMessage; set => ManualEntryModel.WarningMessage = value; }

        public string? ErrorMessage { get => ManualEntryModel.ErrorMessage; set => ManualEntryModel.ErrorMessage = value; }
    }
}