namespace IdentityStore.Core.Mailing.ViewModels
{
    public class VerifyAccountRecoveryViewModel : InvitationViewModel
    {
        public MailInfo MailInfo { get; set; }

        public string VerificationCode { get; set; }
    }
}