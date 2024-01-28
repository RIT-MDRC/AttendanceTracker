namespace MDRC.Models
{
    public class EmailTemplateModel
    {
        public Guid EmailTemplateId { get; set; }

        public string Name { get; set; } = null!;

        public string TemplateText { get; set; } = null!;
    }
}