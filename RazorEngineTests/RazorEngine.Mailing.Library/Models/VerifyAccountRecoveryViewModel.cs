namespace RazorEngine.Mailing.Library.Models
{
    public class VerifyAccountRecoveryViewModel : IMailViewModel
    {
        public MailInfo MailInfo { get; set; }

        public string VerificationCode { get; set; }
    }
}