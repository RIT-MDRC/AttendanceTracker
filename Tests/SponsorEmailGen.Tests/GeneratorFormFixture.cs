using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using SponsorEmailGen.Services;

namespace SponsoeEmailGen.Tests
{
    public class GeneratorFormFixture
    {
        #region Setup Data

        Dictionary<string, Dictionary<string, string>> testInputDictsDict = new Dictionary<string, Dictionary<string, string>>
        {
            { "ColdCallCompany", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "Raymond" },
                    { "directRecipient", "Jane Smith" },
                    { "title", "Fundraising Specialist" },
                    { "formattedPersonality", "your company" },
                    { "formattedPersonality2", "companies" },
                    { "formattedPersonality3", "your company's" },
                    { "formattedPersonality4", "yours" },
                    { GeneratorConstants.GeneratorDictOpenTheDoorValueKey, EmailConstants.OpenTheDoorWebsiteKey },
                    { "email", "jxs1234@rit.edu" },
                    { "possibleSponsorshipOptions", "" }
                }
            },
            { "ColdCallPerson", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "Jane Smith" },
                    { "directRecipient", "Miguel Boxton" },
                    { "title", "Fundraising Specialist" },
                    { "formattedPersonality", "you" },
                    { "formattedPersonality2", "people" },
                    { "formattedPersonality3", "your" },
                    { "formattedPersonality4", "you" },
                    { GeneratorConstants.GeneratorDictOpenTheDoorValueKey, EmailConstants.OpenTheDoorWebsiteKey },
                    { "email", "jxs1234@rit.edu" },
                    { "possibleSponsorshipOptions", "" }
                }
            },
            { "ColdCallOrg", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "NASA" },
                    { "directRecipient", "Jane Smith" },
                    { "title", "Fundraising Specialist" },
                    { "formattedPersonality", "your organization" },
                    { "formattedPersonality2", "organizations" },
                    { "formattedPersonality3", "your organization's" },
                    { "formattedPersonality4", "yours" },
                    { GeneratorConstants.GeneratorDictOpenTheDoorValueKey, EmailConstants.OpenTheDoorWebsiteKey },
                    { "email", "jxs1234@rit.edu" },
                    { "possibleSponsorshipOptions", "" }
                }
            },
            { "EventCompany", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "Raymond" },
                    { "directRecipient", "Jane Smith" },
                    { "title", "Fundraising Specialist" },
                    { "formattedPersonality", "your company" },
                    { "formattedPersonality2", "companies" },
                    { "formattedPersonality3", "your company's" },
                    { "formattedPersonality4", "yours" },
                    { "eventName", "NHRL" },
                    { GeneratorConstants.GeneratorDictOpenTheDoorValueKey, EmailConstants.OpenTheDoorEventKey },
                    { "email", "jxs1234@rit.edu" },
                    { "possibleSponsorshipOptions", "" }
                }
            },
            { "POCCompany", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "Raymond" },
                    { "directRecipient", "Jane Smith" },
                    { "title", "Fundraising Specialist" },
                    { "formattedPersonality", "your company" },
                    { "formattedPersonality2", "companies" },
                    { "formattedPersonality3", "your company's" },
                    { "formattedPersonality4", "yours" },
                    { "pocName", "Jinx McGee" },
                    { GeneratorConstants.GeneratorDictOpenTheDoorValueKey, EmailConstants.OpenTheDoorPersonalConnectionKey },
                    { "email", "jxs1234@rit.edu" },
                    { "possibleSponsorshipOptions", "" }
                }
            },
            { "EventCompanyWOneSponsorOption", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "Raymond" },
                    { "directRecipient", "Jane Smith" },
                    { "title", "Fundraising Specialist" },
                    { "formattedPersonality", "your company" },
                    { "formattedPersonality2", "companies" },
                    { "formattedPersonality3", "your company's" },
                    { "formattedPersonality4", "yours" },
                    { "eventName", "NHRL" },
                    { GeneratorConstants.GeneratorDictOpenTheDoorValueKey, EmailConstants.OpenTheDoorEventKey },
                    { "email", "jxs1234@rit.edu" },
                    { "possibleSponsorshipOptions", "Manufacturing facilities for processing our team’s materials.\r\n" }
                }
            },
            { "EventCompanyWTwoSponsorOptions", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "Raymond" },
                    { "directRecipient", "Jane Smith" },
                    { "title", "Fundraising Specialist" },
                    { "formattedPersonality", "your company" },
                    { "formattedPersonality2", "companies" },
                    { "formattedPersonality3", "your company's" },
                    { "formattedPersonality4", "yours" },
                    { "eventName", "NHRL" },
                    { GeneratorConstants.GeneratorDictOpenTheDoorValueKey, EmailConstants.OpenTheDoorEventKey },
                    { "email", "jxs1234@rit.edu" },
                    { "possibleSponsorshipOptions", "Manufacturing facilities for processing our team’s materials.\r\nMaterials or components our teams could use for future/current projects.\r\n" }
                }
            },
            { "CompanyInitialEmail", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "Raymond" },
                    { "directRecipient", "Jane Smith" },
                    { "title", "Fundraising Specialist" },
                    { "email", "jxs1234@rit.edu" },
                    { "formattedPersonality", "your company" },
                    { "formattedPersonality2", "companies" },
                    { "formattedPersonality3", "your company's" },
                    { "formattedPersonality4", "yours" },
                }
            },
            { "PersonInitialEmail", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "Jane Smith" },
                    { "directRecipient", "Jane Smith" },
                    { "title", "Fundraising Specialist" },
                    { "email", "jxs1234@rit.edu" },
                    { "formattedPersonality", "you" },
                    { "formattedPersonality2", "people" },
                    { "formattedPersonality3", "your" },
                    { "formattedPersonality4", "you" },
                }
            },
            { "OrgInitialEmail", new Dictionary<string, string>
                {
                    { "fullName", "John Smith" },
                    { GeneratorConstants.GeneratorDictRecipientKey, "NASA" },
                    { "directRecipient", "Jane Smith" },
                    { "title", "Fundraising Specialist" },
                    { "email", "jxs1234@rit.edu" },
                    { "formattedPersonality", "your organization" },
                    { "formattedPersonality2", "organizations" },
                    { "formattedPersonality3", "your organization's" },
                    { "formattedPersonality4", "yours" },
                }
            },
        };

        Dictionary<string, string> templateDict = new Dictionary<string, string>
        {
            { FormConstants.OfferEmailTabText, "Dear ${directRecipient},\r\nMy name is ${fullName} and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\n${openTheDoorText}\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to ${formattedPersonality2} like ${formattedPersonality4} to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous ${formattedPersonality2} like ${recipient}; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel — and there are multiple ways ${formattedPersonality} can support us.\r\nMonetary donations to help cover club/team expenses.\r\n${possibleSponsorshipOptions}Your time; we often host robotics-related informational sessions and would love the time of some of your team to help us facilitate those.\r\nAnd if you have any other ideas, we would love to hear them!\r\nWhat’s in it for you?\r\nTo show our appreciation, we want to offer the opportunity to promote ${recipient} to our growing club’s members and alumni, at our event participation (through ${formattedPersonality3} logo and/or name on bots/merchandise), to the student body of RIT through our live demonstrations, and to the general public through our demonstrations at local events. We have also attached a sponsorship package to provide additional information on how you can get involved with our club.\r\nWe hope we can count on your support to help us foster the next generation of engineers, developers, and designers. We would love to chat with you to discuss this exciting opportunity for both of us! You can reach us directly at MDRC@RIT.edu.\r\nI look forward to hearing from you soon. Thanks in advance!\r\n${fullName}\r\n${title}\r\nRIT Multidisciplinary Robotics Club\r\n${email}\r\n"},
            { FormConstants.InitialReachOutTabText, "Hello!\r\nMy name is ${fullName} and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to ${formattedPersonality2} like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous ${formattedPersonality2} like ${recipient}; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel.\r\nI was hoping to be able to get the contact information for ${formattedPersonality3} brand manager, regional marketing manager, or anyone else you may think would be a good contact for us to reach out to in order to provide some more information and begin building our relationship!\r\nThank you so much for your time.\r\nSincerely,\r\n${fullName}\r\n${title}\r\nRIT Multidisciplinary Robotics Club\r\n${email}" }
        };

        Dictionary<string, string> templateAssignmentDict = new Dictionary<string, string>
        {
            { "ColdCallCompany", FormConstants.OfferEmailTabText},
            { "ColdCallPerson", FormConstants.OfferEmailTabText},
            { "ColdCallOrg", FormConstants.OfferEmailTabText},
            { "EventCompany", FormConstants.OfferEmailTabText},
            { "POCCompany", FormConstants.OfferEmailTabText},
            { "EventCompanyWOneSponsorOption", FormConstants.OfferEmailTabText},
            { "EventCompanyWTwoSponsorOptions", FormConstants.OfferEmailTabText},
            { "CompanyInitialEmail", FormConstants.InitialReachOutTabText},
            { "PersonInitialEmail", FormConstants.InitialReachOutTabText},
            { "OrgInitialEmail", FormConstants.InitialReachOutTabText},
        };

        Dictionary<string, string> expectedResultDict = new Dictionary<string, string>
        {
            { "ColdCallCompany", "Dear Jane Smith,\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nWe were looking at your company's website and noticed your company had a history of sponsoring the robotics community. I wanted to reach out to talk about a sponsorship opportunity that we think would be a good fit.\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to companies like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous companies like Raymond; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel — and there are multiple ways your company can support us.\r\nMonetary donations to help cover club/team expenses.\r\nYour time; we often host robotics-related informational sessions and would love the time of some of your team to help us facilitate those.\r\nAnd if you have any other ideas, we would love to hear them!\r\nWhat’s in it for you?\r\nTo show our appreciation, we want to offer the opportunity to promote Raymond to our growing club’s members and alumni, at our event participation (through your company's logo and/or name on bots/merchandise), to the student body of RIT through our live demonstrations, and to the general public through our demonstrations at local events. We have also attached a sponsorship package to provide additional information on how you can get involved with our club.\r\nWe hope we can count on your support to help us foster the next generation of engineers, developers, and designers. We would love to chat with you to discuss this exciting opportunity for both of us! You can reach us directly at MDRC@RIT.edu.\r\nI look forward to hearing from you soon. Thanks in advance!\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu\r\n" },
            { "ColdCallPerson", "Dear Miguel Boxton,\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nWe were looking at your website and noticed you had a history of sponsoring the robotics community. I wanted to reach out to talk about a sponsorship opportunity that we think would be a good fit.\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to people like you to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous people like Jane Smith; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel — and there are multiple ways you can support us.\r\nMonetary donations to help cover club/team expenses.\r\nYour time; we often host robotics-related informational sessions and would love the time of some of your team to help us facilitate those.\r\nAnd if you have any other ideas, we would love to hear them!\r\nWhat’s in it for you?\r\nTo show our appreciation, we want to offer the opportunity to promote Jane Smith to our growing club’s members and alumni, at our event participation (through your logo and/or name on bots/merchandise), to the student body of RIT through our live demonstrations, and to the general public through our demonstrations at local events. We have also attached a sponsorship package to provide additional information on how you can get involved with our club.\r\nWe hope we can count on your support to help us foster the next generation of engineers, developers, and designers. We would love to chat with you to discuss this exciting opportunity for both of us! You can reach us directly at MDRC@RIT.edu.\r\nI look forward to hearing from you soon. Thanks in advance!\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu\r\n" },
            { "ColdCallOrg", "Dear Jane Smith,\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nWe were looking at your organization's website and noticed your organization had a history of sponsoring the robotics community. I wanted to reach out to talk about a sponsorship opportunity that we think would be a good fit.\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to organizations like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous organizations like NASA; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel — and there are multiple ways your organization can support us.\r\nMonetary donations to help cover club/team expenses.\r\nYour time; we often host robotics-related informational sessions and would love the time of some of your team to help us facilitate those.\r\nAnd if you have any other ideas, we would love to hear them!\r\nWhat’s in it for you?\r\nTo show our appreciation, we want to offer the opportunity to promote NASA to our growing club’s members and alumni, at our event participation (through your organization's logo and/or name on bots/merchandise), to the student body of RIT through our live demonstrations, and to the general public through our demonstrations at local events. We have also attached a sponsorship package to provide additional information on how you can get involved with our club.\r\nWe hope we can count on your support to help us foster the next generation of engineers, developers, and designers. We would love to chat with you to discuss this exciting opportunity for both of us! You can reach us directly at MDRC@RIT.edu.\r\nI look forward to hearing from you soon. Thanks in advance!\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu\r\n" },
            { "EventCompany", "Dear Jane Smith,\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nWe were at NHRL and noticed your company had a history of sponsoring the robotics community. I wanted to reach out to talk about a sponsorship opportunity that we think would be a good fit.\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to companies like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous companies like Raymond; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel — and there are multiple ways your company can support us.\r\nMonetary donations to help cover club/team expenses.\r\nYour time; we often host robotics-related informational sessions and would love the time of some of your team to help us facilitate those.\r\nAnd if you have any other ideas, we would love to hear them!\r\nWhat’s in it for you?\r\nTo show our appreciation, we want to offer the opportunity to promote Raymond to our growing club’s members and alumni, at our event participation (through your company's logo and/or name on bots/merchandise), to the student body of RIT through our live demonstrations, and to the general public through our demonstrations at local events. We have also attached a sponsorship package to provide additional information on how you can get involved with our club.\r\nWe hope we can count on your support to help us foster the next generation of engineers, developers, and designers. We would love to chat with you to discuss this exciting opportunity for both of us! You can reach us directly at MDRC@RIT.edu.\r\nI look forward to hearing from you soon. Thanks in advance!\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu\r\n" },
            { "POCCompany", "Dear Jane Smith,\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nI spoke with Jinx McGee and they suggested that I reach out to talk to you about a sponsorship opportunity that I think would be a good fit for your company.\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to companies like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous companies like Raymond; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel — and there are multiple ways your company can support us.\r\nMonetary donations to help cover club/team expenses.\r\nYour time; we often host robotics-related informational sessions and would love the time of some of your team to help us facilitate those.\r\nAnd if you have any other ideas, we would love to hear them!\r\nWhat’s in it for you?\r\nTo show our appreciation, we want to offer the opportunity to promote Raymond to our growing club’s members and alumni, at our event participation (through your company's logo and/or name on bots/merchandise), to the student body of RIT through our live demonstrations, and to the general public through our demonstrations at local events. We have also attached a sponsorship package to provide additional information on how you can get involved with our club.\r\nWe hope we can count on your support to help us foster the next generation of engineers, developers, and designers. We would love to chat with you to discuss this exciting opportunity for both of us! You can reach us directly at MDRC@RIT.edu.\r\nI look forward to hearing from you soon. Thanks in advance!\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu\r\n" },
            { "EventCompanyWOneSponsorOption", "Dear Jane Smith,\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nWe were at NHRL and noticed your company had a history of sponsoring the robotics community. I wanted to reach out to talk about a sponsorship opportunity that we think would be a good fit.\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to companies like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous companies like Raymond; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel — and there are multiple ways your company can support us.\r\nMonetary donations to help cover club/team expenses.\r\nManufacturing facilities for processing our team’s materials.\r\nYour time; we often host robotics-related informational sessions and would love the time of some of your team to help us facilitate those.\r\nAnd if you have any other ideas, we would love to hear them!\r\nWhat’s in it for you?\r\nTo show our appreciation, we want to offer the opportunity to promote Raymond to our growing club’s members and alumni, at our event participation (through your company's logo and/or name on bots/merchandise), to the student body of RIT through our live demonstrations, and to the general public through our demonstrations at local events. We have also attached a sponsorship package to provide additional information on how you can get involved with our club.\r\nWe hope we can count on your support to help us foster the next generation of engineers, developers, and designers. We would love to chat with you to discuss this exciting opportunity for both of us! You can reach us directly at MDRC@RIT.edu.\r\nI look forward to hearing from you soon. Thanks in advance!\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu\r\n" },
            { "EventCompanyWTwoSponsorOptions", "Dear Jane Smith,\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nWe were at NHRL and noticed your company had a history of sponsoring the robotics community. I wanted to reach out to talk about a sponsorship opportunity that we think would be a good fit.\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to companies like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous companies like Raymond; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel — and there are multiple ways your company can support us.\r\nMonetary donations to help cover club/team expenses.\r\nManufacturing facilities for processing our team’s materials.\r\nMaterials or components our teams could use for future/current projects.\r\nYour time; we often host robotics-related informational sessions and would love the time of some of your team to help us facilitate those.\r\nAnd if you have any other ideas, we would love to hear them!\r\nWhat’s in it for you?\r\nTo show our appreciation, we want to offer the opportunity to promote Raymond to our growing club’s members and alumni, at our event participation (through your company's logo and/or name on bots/merchandise), to the student body of RIT through our live demonstrations, and to the general public through our demonstrations at local events. We have also attached a sponsorship package to provide additional information on how you can get involved with our club.\r\nWe hope we can count on your support to help us foster the next generation of engineers, developers, and designers. We would love to chat with you to discuss this exciting opportunity for both of us! You can reach us directly at MDRC@RIT.edu.\r\nI look forward to hearing from you soon. Thanks in advance!\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu\r\n" },
            { "CompanyInitialEmail", "Hello!\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to companies like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous companies like Raymond; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel.\r\nI was hoping to be able to get the contact information for your company's brand manager, regional marketing manager, or anyone else you may think would be a good contact for us to reach out to in order to provide some more information and begin building our relationship!\r\nThank you so much for your time.\r\nSincerely,\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu"},
            { "PersonInitialEmail", "Hello!\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to people like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous people like Jane Smith; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel.\r\nI was hoping to be able to get the contact information for your brand manager, regional marketing manager, or anyone else you may think would be a good contact for us to reach out to in order to provide some more information and begin building our relationship!\r\nThank you so much for your time.\r\nSincerely,\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu"},
            { "OrgInitialEmail", "Hello!\r\nMy name is John Smith and I’m reaching out on behalf of Rochester Institute of Technology’s Multidisciplinary Robotics Club (RIT MDRC).\r\nMDRC is a club dedicated to empowering students with the skills and knowledge to be able to enter the workforce with strong practical experience and problem-solving skills. We look to organizations like yours to allow us to make that happen. We couldn’t provide the resources to allow these students the environment to grow and develop without the help of generous organizations like NASA; that’s why I am reaching out today. We’re looking for sponsors to help us grow our club and help provide the tools to encourage our students to excel.\r\nI was hoping to be able to get the contact information for your organization's brand manager, regional marketing manager, or anyone else you may think would be a good contact for us to reach out to in order to provide some more information and begin building our relationship!\r\nThank you so much for your time.\r\nSincerely,\r\nJohn Smith\r\nFundraising Specialist\r\nRIT Multidisciplinary Robotics Club\r\njxs1234@rit.edu"},
        };

        #endregion

        #region Tests

        [TestCase("ColdCallCompany")]
        [TestCase("ColdCallPerson")]
        [TestCase("ColdCallOrg")]
        [TestCase("EventCompany")]
        [TestCase("POCCompany")]
        [TestCase("EventCompanyWOneSponsorOption")]
        [TestCase("EventCompanyWTwoSponsorOptions")]
        [TestCase("CompanyInitialEmail")]
        [TestCase("PersonInitialEmail")]
        [TestCase("OrgInitialEmail")]

        public void TestOfferGeneration(string testName)
        {
            var testDict = testInputDictsDict[testName];

            var result = GenerationService.PopulateTemplate(testDict, templateAssignmentDict[testName], templateDict[templateAssignmentDict[testName]]);

            Assert.That(result, Is.Not.Null, "The email returned was null.");
            Assert.That(result, Is.Not.EqualTo(string.Empty), "The email returned was empty.");
            Assert.That(result, Is.EqualTo(expectedResultDict[testName]));
        }

        #endregion
    }
}