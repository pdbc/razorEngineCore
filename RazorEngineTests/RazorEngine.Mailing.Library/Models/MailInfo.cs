using System;
using System.Net.Mail;

namespace RazorEngine.Mailing.Library.Models
{
    public class MailInfo
    {
        // Profile
        //public long AreaId { get; set; }
        //public String AreaType { get; set; }


        // Template
        public String TemplateName { get; set; }
        public String TemplateLanguageCode { get; set; }

        // TODO Can we elaborate on this??
        //public String MailTitle { get; set; }
        //public String MailSubTitle { get; set; } = null;

        public bool UseHeaderForApplicationScope => ! String.IsNullOrEmpty(ApplicationScope?.Trim());

        public String ApplicationScope { get; set; }

        public String GetTemplateKey()
        {
            return $"{TemplateName}_{TemplateLanguageCode}";
        }
        public String GetTemplateKey(string defaultLanguage)
        {
            return $"{TemplateName}_{defaultLanguage}";
        }

        // Mail
        public string ToEmailAddress { get; set; }

        public string Subject { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        // Extra testing parameters ....
        public string Cc { get; set; }
        public string Bcc { get; set; }

        public MailPriority Priority { get; set; }

        /// <summary>
        /// Only use during diagnostics test
        /// </summary>
        public Boolean ShouldAuditMailEvent { get; set; }

        
    }
}