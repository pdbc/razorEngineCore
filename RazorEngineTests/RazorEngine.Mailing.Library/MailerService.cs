using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using RazorEngine.Mailing.Library.Models;
using RazorEngine.Mailing.Library.Templates;

namespace RazorEngine.Mailing.Library
{
    public interface IMailerService
    {
        void SendMail(IMailViewModel model);

        void DropMail(IMailViewModel model);
    }

    public class MailerService : IMailerService
    {
        private MailGenerationService _mailGenerationService;
        private IMailerConfiguration _mailerConfiguration;

        public MailerService()
        {
            _mailGenerationService = new MailGenerationService();
            _mailerConfiguration = new MailerConfiguration();
        }

        public void SendMail(IMailViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public void DropMail(IMailViewModel model)
        {
            var smtpClient = new SmtpClient("smtp.dika.be");
            string path = Path.Combine(_mailerConfiguration.PickupDirectoryLocation, model.MailInfo.TemplateName);
            if (!Directory.Exists(path)) 
                Directory.CreateDirectory(path);


            smtpClient.PickupDirectoryLocation = path;
            smtpClient.Send(GetMailMessage(model, false));
        }

        private MailMessage GetMailMessage(IMailViewModel model, bool shouldLog = true)
        {
            var html = _mailGenerationService.GenerateHtmlMail(model);
            var text = _mailGenerationService.GenerateTextOnlyMail(model) ?? html.StripHtml();
            
            var mailMessage = new MailMessage();
            mailMessage.To.Add(model.MailInfo.ToEmailAddress);
            mailMessage.From = new MailAddress(_mailerConfiguration.FromEmailAddress, _mailerConfiguration.FromDisplayName);
            if (!string.IsNullOrWhiteSpace(model.MailInfo.Cc))
            {
                mailMessage.CC.Add(model.MailInfo.Cc);
            }
            mailMessage.Priority = model.MailInfo.Priority;
            mailMessage.Subject = model.MailInfo.Subject;

            // Text view
            mailMessage.IsBodyHtml = false;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Body = text;

            // HTML view
            var htmlView = AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html);
            mailMessage.AlternateViews.Add(htmlView);

            var sdImage = GetEmbeddedImage("Logo_SDWorx.png", "logo_sdworx");
            if (sdImage != null)
            {
                htmlView.LinkedResources.Add(sdImage);
            }

            if (!string.IsNullOrWhiteSpace(model.MailInfo.Cc))
                mailMessage.CC.Add(model.MailInfo.Cc);

            if (!string.IsNullOrWhiteSpace(model.MailInfo.Bcc))
                mailMessage.Bcc.Add(model.MailInfo.Bcc);

            return mailMessage;
        }

        private LinkedResource GetEmbeddedImage(string imageFileName, string imageContentName, string mediaType = "image/png")
        {
            var imagePath = Path.Combine(Extensions.AssemblyDirectory, _mailerConfiguration.ImageDirectory, imageFileName);
            if (!File.Exists(imagePath))
            {
                //_log.Debug($"Unable to load image from path {imagePath}");
                return null;
            }

            var inline = new LinkedResource(imagePath, mediaType)
            {
                ContentId = imageContentName
            };
            return inline;
        }
    }


}