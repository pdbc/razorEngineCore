using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RazorEngine.Mailing.Library
{

    public interface IMailerConfiguration
    {
        string TemplateDirectory { get; }

        string ImageDirectory { get; }

        string Originator { get; }

        string DefaultMailLanguage { get; }

        string FromEmailAddress { get; }

        string FromDisplayName { get; }

        string PickupDirectoryLocation { get; }
    }
    public class MailerConfiguration : IMailerConfiguration
    {
        //public MailerConfiguration(IConfiguration configuration)
        //{
        //    configuration.GetSection("MailerConfiguration").Bind(this);
        //}

        public MailerConfiguration()
        {
            TemplateDirectory = "";
            ImageDirectory = "Images";
            Originator = "Mail Tests";
            DefaultMailLanguage = "EN";
            FromEmailAddress = "mail.tests@sdworx.com";
            FromDisplayName = "Mail Tests";
            PickupDirectoryLocation = @"c:\temp\mails_cia";
        }



        public string TemplateDirectory { get; set; }
        public string ImageDirectory { get; set; }
        public string Originator { get; set; }
        public string DefaultMailLanguage { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromDisplayName { get; set; }
        public string PickupDirectoryLocation { get; set; }
    }
}