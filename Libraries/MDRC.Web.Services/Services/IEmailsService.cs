using MDRC.Data;
using MDRC.Data.Models;
using MDRC.Models;
using System.Web.Mvc;

namespace MDRC.Services
{
    public interface IEmailsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <returns></returns>
        public List<EmailTemplateModel> GetTemplateList(MDRCSiteDbContext siteContext);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="emailTemplateId"></param>
        /// <returns></returns>
        public EmailTemplateModel GetEditEmailTemplateModel(MDRCSiteDbContext siteContext, Guid emailTemplateId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="generateEmailModel"></param>
        public void SaveEmailTemplate(MDRCSiteDbContext siteContext, EmailTemplateModel generateEmailModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="memberId"></param>
        /// <param name="emailTemplateId"></param>
        /// <returns></returns>
        public GenerateEmailModel GenerateEmail(MDRCSiteDbContext siteContext, int memberId, Guid emailTemplateId);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="siteContext"></param>
       /// <param name="generateEmailModel"></param>
       /// <returns></returns>
        public GeneratedEmailContentModel GenerateEmailFromTemplate(MDRCSiteDbContext siteContext, GenerateEmailModel generateEmailModel);
    }
}
