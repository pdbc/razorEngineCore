using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RazorEngineConsole
{
    public class TemplateLoader
    {
        public IList<TemplateInfo> GetAllPossibleParts(String baseDirectory)
        {
            return GetPossibleTemplates(baseDirectory)
                .Select(f => new TemplateInfo(f))
                .ToList();
        }

        public IList<TemplateInfo> GetAllPossibleTemplates(String baseDirectory)
        {
            return GetPossibleTemplates(baseDirectory)
                .Select(f => new TemplateInfo(f))
                .ToList();
        }

        public IList<String> GetPossibleTemplates(String baseDirectory)
        {
            var files = Directory.GetFiles(baseDirectory, "*.cshtml").ToList();
            var directories = Directory.GetDirectories(baseDirectory);
            foreach (var directory in directories)
            {
                files.AddRange(GetPossibleTemplates(directory));
            }
            return files;
        }
    }
}