namespace IdentityStore.Core.Mailing.ViewModels
{
    public  class SupportViewModel : InvitationViewModel
    {
        public MailInfo MailInfo { get; set; }

        public string ShortSummary { get; set; }
        public string CherwellCategory { get; set; }
        public string CherwellSubCategory { get; set; }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string ShortDateOfBirth { get; set; }
        public string Question { get; set; }
        public string MobileNumber { get; set; }
        public string Language { get; set; }
    }
}
