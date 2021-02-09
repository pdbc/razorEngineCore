using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;

namespace RazorEngineConsole
{
    public class TemplateInfo
    {
        private readonly string _filename;

        public TemplateInfo(String filename)
        {
            _filename = filename;

            var fileInfo = new FileInfo(filename);

            FilePath = fileInfo.FullName;
            Name = fileInfo.Name;
            Key = Name.Replace(".cshtml", "");

            var parts = Key.Split('_');
            if (parts.Length == 1)
            {
                TemplateName = parts[0];
            } else if (parts.Length == 2)
            {
                TemplateName = parts[0];
                LanguageName = parts[1];
            }
        }

        public string FilePath { get; set; }

        public string LanguageName { get; set; }

        public string TemplateName { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }
    }
}