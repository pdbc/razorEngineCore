using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RazorEngine.Mailing.Library.Templates
{
    public class TemplateLoader
    {
        public IList<TemplateInfo> GetAllPossibleParts(String baseDirectory)
        {
            return GetCshtmlFilesFrom(baseDirectory)
                .Select(f => new TemplateInfo(f))
                .ToList();
        }

        public IList<TemplateInfo> GetAllPossibleTemplates(String baseDirectory)
        {
            return GetCshtmlFilesFrom(baseDirectory)
                .Select(f => new TemplateInfo(f))
                .ToList();
        }

        public IList<String> GetCshtmlFilesFrom(String baseDirectory)
        {
            var files = Directory.GetFiles(baseDirectory, "*.cshtml").ToList();
            var directories = Directory.GetDirectories(baseDirectory);
            foreach (var directory in directories)
            {
                files.AddRange(GetCshtmlFilesFrom(directory));
            }
            return files;
        }
    }
}