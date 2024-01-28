using System.ComponentModel.DataAnnotations;

namespace MDRC.Models
{
    public class ManualEntryModel : ErrorMesssageModel, IErrorHandlingModel
    {
        public int? MemberId { get; set; }

        public Guid? EventId { get; set; }

        public List<MemberModel> MemberList { get; set; } = null!;

        public List<EventModel> EventList { get; set; } = null!;

        public int RequesterUniversityId { get; set; }
    }
}