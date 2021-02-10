using System;
using RazorEngine.Mailing.Library.Models;

namespace RazorEngine.Mailing.Library.Templates
{
    public class MailGenerationService
    {
        private MailTemplateCacheService _mailTemplateCacheService;
        public MailGenerationService()
        {
            _mailTemplateCacheService = new MailTemplateCacheService();
        }


        public String GenerateHtmlMail(IMailViewModel mailViewModel)
        {
            // Retrieve the template
            var compiledTemplate = _mailTemplateCacheService.GetHtmlTemplate(mailViewModel.MailInfo.TemplateName, mailViewModel.MailInfo.TemplateLanguageCode);
            var result = compiledTemplate.Run(mailViewModel);
            return result;
        }

        public String GenerateTextOnlyMail(IMailViewModel mailViewModel)
        {
            // Retrieve the template
            var compiledTemplate = _mailTemplateCacheService.GetTextOnlyTemplate(mailViewModel.MailInfo.TemplateName, mailViewModel.MailInfo.TemplateLanguageCode);

            var result = compiledTemplate?.Run(mailViewModel);
            return result;
        }
    }
}