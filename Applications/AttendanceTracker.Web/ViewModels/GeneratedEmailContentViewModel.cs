using MDRC.Models;

namespace MDRC.Web.ViewModels
{
    public class GeneratedEmailContentViewModel
    {
        public GeneratedEmailContentViewModel(GeneratedEmailContentModel generatedEmailContentModel)
        {
            GeneratedEmailContentModel = generatedEmailContentModel;
        }

        public GeneratedEmailContentViewModel() 
        {
            GeneratedEmailContentModel = new GeneratedEmailContentModel();
        }

        public GeneratedEmailContentModel GeneratedEmailContentModel { get; set; }

        public string EmailContent => GeneratedEmailContentModel.GetEmailContent();
    }
}