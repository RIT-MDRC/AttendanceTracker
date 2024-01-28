using MDRC.Models;

namespace MDRC.Web.ViewModels
{
    public class CreateAccountViewModel
    {
        public CreateAccountViewModel()
        {
            CreateAccountModel = new CreateAccountModel();
        }

        public CreateAccountModel CreateAccountModel { get; set; }

        public int UniversityId => CreateAccountModel.UniversityId;

        public string FullName => CreateAccountModel.FullName;
    }
}