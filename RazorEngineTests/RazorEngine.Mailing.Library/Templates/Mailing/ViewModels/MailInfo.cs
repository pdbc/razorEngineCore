using System;
using System.Net.Mail;

namespace IdentityStore.Core.Mailing
{
    public class MailInfo
    {
        // Profile
        public long AreaId { get; set; }
        public String AreaType { get; set; }


        // Template
        public String TemplateName { get; set; }
        public String TemplateLanguageCode { get; set; }

        public String GetTemplateKey()
        {
            return $"{TemplateName}_{TemplateLanguageCode}";
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