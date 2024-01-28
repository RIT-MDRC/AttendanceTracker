using System.Text.Json.Serialization;

namespace MDRC.Models
{
    public enum RecipientType
    {
        Company,
        Person,
        Organization
    }

    public class GenerateEmailModel : MemberModel
    {
        [JsonIgnore]
        public Guid EmailTemplateId { get; set; }

        public string TemplateName { get; set; } = null!;

        [JsonIgnore]
        public RecipientType RecipientType { get; set; }

        public string RecipientName { get; set; } = null!;

        public string DirectRecipientName { get; set; } = null!;

        public string EventName { get; set; } = null!;

        public string FormattedPersonality
        {
            get
            {
                switch (RecipientType)
                {
                    case RecipientType.Company:
                        return "your company";
                    case RecipientType.Person:
                        return "you";
                    case RecipientType.Organization:
                    default:
                        return "your organization";
                }
            }
        }

        public string FormattedPersonality2
        {
            get
            {
                switch (RecipientType)
                {
                    case RecipientType.Company:
                        return "companies";
                    case RecipientType.Person:
                        return "people";
                    case RecipientType.Organization:
                    default:
                        return "organizations";
                }
            }
        }

        public string FormattedPersonality3
        {
            get
            {
                switch (RecipientType)
                {
                    case RecipientType.Company:
                        return "your company's";
                    case RecipientType.Person:
                        return "your";
                    case RecipientType.Organization:
                    default:
                        return "your organization's";
                }
            }
        }

        public string FormattedPersonality4
        {
            get
            {
                switch (RecipientType)
                {
                    case RecipientType.Company:
                        return "yours";
                    case RecipientType.Person:
                        return "you";
                    case RecipientType.Organization:
                    default:
                        return "yours";
                }
            }
        }
    }
}