using System;
using System.Collections.Concurrent;
using RazorEngine.Mailing.Library.Templates;
using RazorEngine.Mailing.Library.Templates.BaseTemplate;

namespace RazorEngine.Mailing.Library
{
    //TODO Singleton
    public class MailTemplateCacheService
    {
        private readonly TemplateFileLoader _templateFileFileLoader;
        private readonly RazorEngineCore.RazorEngine _razorEngine;

        // TODO - Remove (use Caching Advice)
        private ConcurrentDictionary<string, BaseCompiledTemplate> TemplateCache = new ConcurrentDictionary<string, BaseCompiledTemplate>();

        public MailTemplateCacheService()
        {
            // Inject 
            _templateFileFileLoader = new TemplateFileLoader();
            _razorEngine = new RazorEngineCore.RazorEngine();
        }

        // TODO This should do the caching
        public BaseCompiledTemplate GetHtmlTemplate(string key, string languageCode)
        {
            string templateKey = $"{key}_{languageCode}";
            string defaultLanguageKey = $"{key}_en";
            string cacheKey = $"{templateKey}_html";

            // Retrieve the template
            BaseCompiledTemplate compiledTemplate = null;
            if (TemplateCache.ContainsKey(cacheKey))
            {
                compiledTemplate = TemplateCache[cacheKey];
            }
            else
            {
                compiledTemplate = TemplateCache.GetOrAdd(cacheKey, i =>
                {
                    var parts = _templateFileFileLoader.GetLayoutPartsFor(languageCode);

                    var templateInfo = _templateFileFileLoader.GetHtmlMailTemplateInfoFor(templateKey, defaultLanguageKey, key);
                    if (templateInfo != null)
                    {
                        return _razorEngine.Compile(templateInfo.TemplateBody, parts);
                    }

                    throw new NotImplementedException($"{key}_{languageCode} cannot be compiled");
                });
            }

            return compiledTemplate;
        }


        // TODO This should do the caching
        public BaseCompiledTemplate GetTextOnlyTemplate(string key, string languageCode)
        {
            string templateKey = $"{key}_{languageCode}";
            string defaultLanguageKey = $"{key}_en";
            string cacheKey = $"{templateKey}_text";

            // Retrieve the template
            BaseCompiledTemplate compiledTemplate = null;
            if (TemplateCache.ContainsKey(cacheKey))
            {
                compiledTemplate = TemplateCache[cacheKey];
            }
            else
            {
                compiledTemplate = TemplateCache.GetOrAdd(cacheKey, i =>
                {
                    var parts = _templateFileFileLoader.GetLayoutPartsFor(languageCode);

                    var templateInfo = _templateFileFileLoader.GetTextMailTemplateInfoFor(templateKey, defaultLanguageKey, key);
                    if (templateInfo != null)
                    {
                        return _razorEngine.Compile(templateInfo.TemplateBody, parts);
                    }

                    return null;

                    //throw new NotImplementedException($"{key}_{languageCode} cannot be compiled");
                });
            }

            return compiledTemplate;
        }
    }
}