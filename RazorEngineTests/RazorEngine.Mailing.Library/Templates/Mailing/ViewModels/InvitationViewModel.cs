using IdentityStore.Core.Extensions;
using System;
using System.Collections.Generic;

namespace IdentityStore.Core.Mailing.ViewModels
{
    public class InvitationViewModel : CustomViewModelBase<InvitationViewModel>, IMailViewModel
    {
        public MailInfo MailInfo { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ApplicationScope { get; set; }

        public IList<string> Applications { get; set; } = new List<string>();

        public string Url { get; set; }

        public string DateOfBirthString => DateOfBirth?.ToIdentityStoreDateFormat();

        public string AccountOfficialName { get; set; }
    }
}
