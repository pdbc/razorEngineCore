using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace IdentityStore.Core.Mailing.Implementation.Templates
{
    public class MvcMailingTemplate<T> : TemplateBase<T>
    {
        public IEncodedString EmbedCss(string path)
        {
            var cssFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, path);
            // load the contents of that file
            try
            {
                var cssText = System.IO.File.ReadAllText(cssFilePath);
                var styleElement = new TagBuilder("style");
                styleElement.InnerHtml.AppendHtml(cssText);
                styleElement.Attributes.Add("type", "text/css");
                return Raw(styleElement.ToString());
            }
            catch (Exception)
            {
                // return nothing if we can't read the file for any reason
                return null;
            }
        }
    }
}
