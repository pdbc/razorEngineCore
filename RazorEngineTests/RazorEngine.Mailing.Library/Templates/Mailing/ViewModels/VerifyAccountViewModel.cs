﻿
namespace IdentityStore.Core.Mailing.ViewModels
{
    public class VerifyAccountViewModel : InvitationViewModel
    {
        public MailInfo MailInfo { get; set; }

        public string VerificationCode { get; set; }
    }
}