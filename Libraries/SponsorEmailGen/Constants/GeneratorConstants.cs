namespace SponsorEmailGen.Constants
{
    public static class GeneratorConstants
    {
        public static readonly string GeneratorDictOpenTheDoorValueKey = "openTheDoorValue";
        public static readonly string GeneratorDictRecipientKey = "recipient";
        public static readonly string EmailRootPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"Sponsor Email Generator",
                @"Emails");
    }
}
