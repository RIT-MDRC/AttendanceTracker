using MDRC.Models;
using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace MDRC.Web.ViewModels
{
    public class EditEmailTemplateViewModel
    {
        public EditEmailTemplateViewModel(EmailTemplateModel emailTemplateModel) 
        {
            EmailTemplateModel = emailTemplateModel;
        }

        public EditEmailTemplateViewModel()
        {
            EmailTemplateModel = new EmailTemplateModel();
        }

        public EmailTemplateModel EmailTemplateModel { get; set; }

        public Guid EmailTemplateId { get => EmailTemplateModel.EmailTemplateId; set => EmailTemplateModel.EmailTemplateId = value; }

        [Display(Name = "Email Content:")]
        public string TemplateText { get => EmailTemplateModel.TemplateText; set => EmailTemplateModel.TemplateText = value; }

        [Display(Name = "Template Name:")]
        public string Name { get => EmailTemplateModel.Name; set => EmailTemplateModel.Name = value; }
    }
}