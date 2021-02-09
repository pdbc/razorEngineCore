using System;

namespace RazorEngineConsole.Models
{
    public class MailModel
    {
        public static MailModel CreateMailModel(string name, string language)
        {
            return new MailModel()
            {
                Name = "Name",
                Subject = "Subject",


                ApplicationScope = "application scope",
                Firstname = "Patrick",
                Lastname="DEBOECK",
                Language = language,

                TemplateName = "template3-text"
            };
        }

        public string Language { get; set; }

        public string Lastname { get; set; }

        public String Subject { get; set; }

        public String Name { get; set; }

        public string ApplicationScope { get; set; }
        public string Firstname { get; set; }

        public string TemplateName { get; set; }
    }
}