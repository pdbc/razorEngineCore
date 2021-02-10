namespace IdentityStore.Core.Mailing.ViewModels
{
    public class AuditViewModel: IMailViewModel
    {
        public MailInfo MailInfo { get; set; }

        public string AuditDescription { get; set; }

        public string PortalAuditUrl { get; set; }

        public string PortalProfileUrl { get; set; }
    }
}
