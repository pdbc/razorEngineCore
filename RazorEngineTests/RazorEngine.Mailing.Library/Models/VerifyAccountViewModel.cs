namespace RazorEngine.Mailing.Library.Models
{
    public class VerifyAccountViewModel : IMailViewModel
    {
        public MailInfo MailInfo { get; set; }

        public string VerificationCode { get; set; }
    }
}