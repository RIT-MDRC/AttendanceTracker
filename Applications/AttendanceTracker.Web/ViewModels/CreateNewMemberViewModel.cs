using System.ComponentModel.DataAnnotations;
using MDRC.Models;

namespace MDRC.Web.ViewModels
{
    public class CreateNewMemberViewModel
    {
        public CreateNewMemberViewModel(CreateNewMemberModel createNewMemberModel)
        {
            CreateNewMemberModel = createNewMemberModel;
        }

        public CreateNewMemberViewModel()
        {
            CreateNewMemberModel = new CreateNewMemberModel();
        }

        public CreateNewMemberModel CreateNewMemberModel { get; set; }

        [Display(Name = "First Name:")]
        public string GivenName { get => CreateNewMemberModel.GivenName; set => CreateNewMemberModel.GivenName = value; }

        [Display(Name = "Last Name:")]
        public string FamilyName { get => CreateNewMemberModel.FamilyName; set => CreateNewMemberModel.FamilyName = value; }

        public int UniversityId { get => CreateNewMemberModel.UniversityId; set => CreateNewMemberModel.UniversityId = value; }

        [Display(Name = "RIT Email (format: xyz1234@rit.edu):")]
        public string Email { get => CreateNewMemberModel.Email; set => CreateNewMemberModel.Email = value; }

        public Guid EventId { get => CreateNewMemberModel.EventId; set => CreateNewMemberModel.EventId = value; }

        [Display(Name = "Are you a new member to our club? ")]
        public bool IsNewMember { get => CreateNewMemberModel.IsNewMember; set => CreateNewMemberModel.IsNewMember = value; }
    }
}