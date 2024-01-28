using MDRC.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace MDRC.Web.ViewModels
{
    public class GenerateEmailViewModel
    {
        public GenerateEmailViewModel(GenerateEmailModel generateEmailModel)
        {
            GenerateEmailModel = generateEmailModel;
        }

        public GenerateEmailViewModel()
        {
            GenerateEmailModel = new GenerateEmailModel();
        }

        public GenerateEmailModel GenerateEmailModel { get; set; }

        [Display(Name = "First Name:")]
        public string GivenName { get => GenerateEmailModel.GivenName; set => GenerateEmailModel.GivenName = value; }

        [Display(Name = "Last Name:")]
        public string FamilyName { get => GenerateEmailModel.FamilyName; set => GenerateEmailModel.FamilyName = value; }

        public string FullName => GenerateEmailModel.FullName;

        public string Email { get => GenerateEmailModel.Email; set => GenerateEmailModel.Email = value; }

        [Display(Name = "Title:")]
        public string Title { get => GenerateEmailModel.Title; set => GenerateEmailModel.Title = value; }

        public Guid EmailTemplateId { get => GenerateEmailModel.EmailTemplateId; set => GenerateEmailModel.EmailTemplateId = value; }

        [Display(Name = "Template Name:")]
        public string TemplateName { get => GenerateEmailModel.TemplateName; set => GenerateEmailModel.TemplateName = value; }

        [Display(Name = "Recipient Type:")]
        public RecipientType RecipientType { get => GenerateEmailModel.RecipientType; set => GenerateEmailModel.RecipientType = value; }

        public IEnumerable<SelectListItem> RecipientTypeList
        {
            get
            {
                return Enum.GetValues(typeof(RecipientType))
                    .Cast<RecipientType>()
                    .Select(rt => new SelectListItem
                    {
                        Text = rt.ToString(),
                        Value = rt.ToString()
                    });
            }
        }

        [Display(Name = "Recipient Name:")]
        public string RecipientName { get => GenerateEmailModel.RecipientName; set => GenerateEmailModel.RecipientName = value; }

        [Display(Name = "Direct Recipient Name:")]
        public string DirectRecipientName { get => GenerateEmailModel.DirectRecipientName; set => GenerateEmailModel.DirectRecipientName = value; }

        [Display(Name = "Event Name:")]
        public string EventName { get => GenerateEmailModel.EventName; set => GenerateEmailModel.EventName = value; }
    }
}