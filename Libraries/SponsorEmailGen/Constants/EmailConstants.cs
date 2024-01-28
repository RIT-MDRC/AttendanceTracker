using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SponsorEmailGen.Constants
{
    public static class EmailConstants
    {
        public static readonly string OpenTheDoorPersonalConnectionKey = "pc";
        public static readonly string OpenTheDoorWebsiteKey = "w";
        public static readonly string OpenTheDoorEventKey = "e";

        public static readonly Dictionary<string, string> EmailTemplateNamesDict = new Dictionary<string, string>()
        {
            {FormConstants.InitialReachOutTabText, "InitialReachOut.txt"},
            {FormConstants.OfferEmailTabText, "OfferEmail.txt"}
        };

        public static readonly Dictionary<string, string> SponsorOptionsDict = new Dictionary<string, string>()
        {
            {"Manufacturing facilities", "Manufacturing facilities for processing our team’s materials."},
            {"Materials or components", "Materials or components our teams could use for future/current projects."}
        };

        public static readonly Dictionary<string, string> OpenTheDoorDict = new Dictionary<string, string>()
        {
            { OpenTheDoorPersonalConnectionKey, "I spoke with ${pocName} and they suggested that I reach out to talk to you about a sponsorship opportunity that I think would be a good fit for ${formattedPersonality}." },
            { OpenTheDoorWebsiteKey, "We were looking at ${formattedPersonality3} website and noticed ${formattedPersonality} had a history of sponsoring the robotics community. I wanted to reach out to talk about a sponsorship opportunity that we think would be a good fit." },
            { OpenTheDoorEventKey, "We were at ${eventName} and noticed ${formattedPersonality} had a history of sponsoring the robotics community. I wanted to reach out to talk about a sponsorship opportunity that we think would be a good fit." }
        };
    }
}
