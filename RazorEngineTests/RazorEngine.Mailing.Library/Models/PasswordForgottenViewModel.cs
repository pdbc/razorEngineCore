using System;

namespace RazorEngine.Mailing.Library.Models
{
    public class PasswordForgottenViewModel : IMailViewModel
    {
        public MailInfo MailInfo { get; set; }

        public String PasswordForgottenUrl { get; set; }
    }
}