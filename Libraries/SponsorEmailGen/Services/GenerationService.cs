using SponsorEmailGen.Constants;

namespace SponsorEmailGen.Services;
public class GenerationService
{
    public static string GenerateEmail(Dictionary<string, string> generatorValueDict, string selectedTabName)
    {
        try
        {
            var emailTemplate = GetEmailTemplate(selectedTabName);

            var filledEmail = PopulateTemplate(generatorValueDict, selectedTabName, emailTemplate);

            var outputPath = @"C:\GeneratedEmails\";
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            var fileName = Path.Combine(
                outputPath,
                string.Format("{0}_{1}_{2}.txt", 
                    generatorValueDict[GeneratorConstants.GeneratorDictRecipientKey], 
                    EmailConstants.EmailTemplateNamesDict[selectedTabName][..^4], 
                    DateTimeOffset.Now.ToString("ddMMyyyyhhmmss"))
                );

            WriteEmail(fileName, filledEmail);
            return fileName;
        } catch (Exception e)
        {
            Console.Error.WriteLine(string.Format("{0}\n{1}", e.Message, e.StackTrace));
        }
        return string.Empty;
    }

    public static string GetEmailTemplate(string selectedTabName)
    {
        var emailPath = Path.Combine(GeneratorConstants.EmailRootPath, EmailConstants.EmailTemplateNamesDict[selectedTabName]);
        var emailTemplateReader = new StreamReader(emailPath);
        var emailTemplate = emailTemplateReader.ReadToEnd();
        emailTemplateReader.Close();
        return emailTemplate;
    }

    public static void WriteEmail(string fileName, string filledEmail)
    {
        var outputWriter = new StreamWriter(fileName);
        outputWriter.Write(filledEmail);
        outputWriter.Close();
    }

    public static string PopulateTemplate(Dictionary<string, string> generatorValueDict, string selectedTabName, string template)
    {
        if (selectedTabName == FormConstants.OfferEmailTabText)
        {
            var openTheDoorText = EmailConstants.OpenTheDoorDict[generatorValueDict[GeneratorConstants.GeneratorDictOpenTheDoorValueKey]];
            foreach (var item in generatorValueDict)
            {
                openTheDoorText = openTheDoorText.Replace("${" + item.Key + "}", item.Value);
            }

            generatorValueDict["openTheDoorText"] = openTheDoorText;
        }

        foreach (var item in generatorValueDict)
        {
            template = template.Replace("${" + item.Key + "}", item.Value);
        }

        return template;
    }
}
