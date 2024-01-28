using MDRC.Data;
using MDRC.Data.Models;
using MDRC.Models;
using Newtonsoft.Json;

namespace MDRC.Services
{
    public class EmailsService : IEmailsService
    {
        public List<EmailTemplateModel> GetTemplateList(MDRCSiteDbContext siteContext)
        {
            return siteContext.EmailTemplates.Select(et => new EmailTemplateModel
            {
                EmailTemplateId = et.EmailTemplateId,
                Name = et.Name,
                TemplateText = et.TemplateText
            }).ToList();
        }

        public EmailTemplateModel GetEditEmailTemplateModel(MDRCSiteDbContext siteContext, Guid emailTemplateId)
        {
            var emailTemplate = siteContext.EmailTemplates.First(et => et.EmailTemplateId == emailTemplateId);
            return new EmailTemplateModel
            {
                EmailTemplateId = emailTemplate.EmailTemplateId,
                Name = emailTemplate.Name,
                TemplateText = emailTemplate.TemplateText
            };
        }

        public void SaveEmailTemplate(MDRCSiteDbContext siteContext, EmailTemplateModel generateEmailModel)
        {
            EmailTemplate template = siteContext.EmailTemplates.Single(et => et.EmailTemplateId == generateEmailModel.EmailTemplateId);

            template.Name = generateEmailModel.Name;
            template.TemplateText = generateEmailModel.TemplateText;

            siteContext.SaveChanges();
        }

        public GenerateEmailModel GenerateEmail(MDRCSiteDbContext siteContext, int memberId, Guid emailTemplateId)
        {
            EmailTemplate template = siteContext.EmailTemplates.Single(et => et.IsActive && et.EmailTemplateId == emailTemplateId);
            Member member = siteContext.Members.Single(m => m.UniversityId == memberId);

            return new GenerateEmailModel
            {
                Email = member.Email,
                GivenName = member.GivenName,
                FamilyName = member.FamilyName,
                EmailTemplateId = emailTemplateId,
                TemplateName = template.Name,
            };
        }

        public GeneratedEmailContentModel GenerateEmailFromTemplate(MDRCSiteDbContext siteContext, GenerateEmailModel generateEmailModel)
        {
            var content = new GeneratedEmailContentModel();
            var generatedEmail = FillTemplate(siteContext.EmailTemplates.Single(et => et.EmailTemplateId == generateEmailModel.EmailTemplateId).TemplateText, ToDictionary<string>(generateEmailModel));
            content.SetEmailContent(generatedEmail);
            return content;
        }

        private static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
            return dictionary;
        }

        private static string FillTemplate(string emailTemplate, Dictionary<string, string> contentDictionary)
        {
            foreach (string item in contentDictionary.Keys)
            {
                emailTemplate = emailTemplate.Replace($"${{{item}}}", contentDictionary[item]);
            }
            return emailTemplate;
        }
    }
}
