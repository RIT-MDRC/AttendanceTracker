using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SponsorEmailGen.Constants
{
    public static class FormConstants
    {
        /// <summary>
        /// The display version of the text displayed when the user's name is invalid
        /// </summary>
        public static readonly string YourNameMessageText = "Your Name";

        /// <summary>
        /// The display version of the text displayed when the company name is invalid
        /// </summary>
        public static readonly string CompanyNameMessageText = "Company Name";

        /// <summary>
        /// The display version of the text displayed when the direct recipient's name is invalid
        /// </summary>
        public static readonly string DirectRecipientMessageText = "Direct Recipient Name";

        /// <summary>
        /// The display version of the text displayed when the user's title is invalid
        /// </summary>
        public static readonly string TitleMessageText = "MDRC Title";

        /// <summary>
        /// The display version of the text displayed when the email is invalid
        /// </summary>
        public static readonly string EmailMessageText = "Email";

        /// <summary>
        /// The display version of the text displayed when the email is improperly formatted
        /// </summary>
        public static readonly string EmailFormattingMessageText = "Email (Bad Formatting)";

        /// <summary>
        /// The display version of the text displayed when the "Recipient Type" selection is invalid
        /// </summary>
        public static readonly string RecipientTypeMessageText = "Recipient Type";

        /// <summary>
        /// The display version of the text displayed when the "How We Know Them" selection is invalid
        /// </summary>
        public static readonly string HowWeKnowThemMessageText = "How we know them";

        /// <summary>
        /// The display version of the text displayed when the event's name is invalid
        /// </summary>
        public static readonly string EventMessageText = "Event Name";

        /// <summary>
        /// The display version of the text displayed when the personal contact's name is invalid
        /// </summary>
        public static readonly string PersonalContactMessageText = "Personal Contact Name";

        /// <summary>
        /// The internal name of the initialReachOutTab
        /// </summary>
        public static readonly string InitialReachOutTabText = "initialReachOutTabPage";

        /// <summary>
        /// The internal name of the offerEmailTab
        /// </summary>
        public static readonly string OfferEmailTabText = "offerEmailTabPage";
    }
}
