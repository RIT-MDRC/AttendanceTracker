namespace MDRC.Models
{
    public class GeneratedEmailContentModel
    {
        private string encodedEmailContent = null!;

        public string GetEmailContent()
        {
            return encodedEmailContent;
        }

        public void SetEmailContent(string value)
        {
            encodedEmailContent = Uri.EscapeDataString(value);
        }
    }
}