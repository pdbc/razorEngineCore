using System;

namespace IdentityStore.Core.Mailing.ViewModels
{
    public class PasswordForgottenViewModel : InvitationViewModel
    {
        public MailInfo MailInfo { get; set; }

        public String PasswordForgottenUrl { get; set; }
    }
}