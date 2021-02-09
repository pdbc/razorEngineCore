using System;
using System.Collections.Generic;

namespace RazorEngine.Mailing.Library.Models
{
    public class InvitationViewModel : IMailViewModel
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
