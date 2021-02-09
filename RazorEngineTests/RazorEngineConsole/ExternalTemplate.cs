using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using RazorEngineConsole.Models;
using RazorEngineCore;
using RazorEngineConsole.CustomTemplate;

namespace RazorEngineConsole
{
    public class ExternalTemplate
    {
        private String TemplateDirectory = @"D:\code\github\pdbc\razorEngineCore\RazorEngineTests\RazorEngineConsole\Templates\";
        private String SharedTemplatesDirectory = @"D:\code\github\pdbc\razorEngineCore\RazorEngineTests\RazorEngineConsole\SharedTemplates\";


        private ConcurrentDictionary<int, IRazorEngineCompiledTemplate> TemplateCache = new ConcurrentDictionary<int, IRazorEngineCompiledTemplate>();
        private TemplateLoader _loader = new TemplateLoader();

        public void Run()
        {
            TransformTemplate("template", "nl", TestModel.CreateTestModel("Template_NL"));
            TransformTemplate("template", "de", TestModel.CreateTestModel("Template_DE"));
            TransformTemplate("template", "en", TestModel.CreateTestModel("Template_EN"));
            TransformTemplate("template2", "nl", TestModel.CreateTestModel("Template_NL"));
            TransformTemplate("template2", "de", TestModel.CreateTestModel("Template_DE"));
            TransformTemplate("template2", "en", TestModel.CreateTestModel("Template_EN"));

        }



        private string TransformTemplate(String templatename, string language, object model)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var templateAndLanguage = $"{templatename}_{language}";

            int hashCode = templateAndLanguage.GetHashCode();
            IRazorEngineCompiledTemplate compiledTemplate = null;
            if (TemplateCache.ContainsKey(hashCode))
            {
                compiledTemplate = TemplateCache[hashCode];
            } else 
            {
                var templates = _loader.GetAllPossibleTemplates(TemplateDirectory);
                var layoutTemplates = _loader.GetAllPossibleTemplates(SharedTemplatesDirectory);

                compiledTemplate = TemplateCache.GetOrAdd(hashCode, i =>
                {
                    RazorEngine razorEngine = new RazorEngine();

                    // 1. try to find the template with language
                    var templateInfo = templates.FirstOrDefault(x => x.Key == templateAndLanguage);// Path.Combine(TemplateDirectory, templateAndLanguage + ".cshtml");
                    if (templateInfo != null)
                    {
                        Console.WriteLine($"Found: {templateAndLanguage}");
                        return razorEngine.Compile(File.ReadAllText(templateInfo.FilePath));
                    }

                    // 2. try to find the template with default language
                    var templateAndDefaultLanguage = $"{templatename}_en";
                    templateInfo = templates.FirstOrDefault(x => x.Key == templateAndDefaultLanguage);// Path.Combine(TemplateDirectory, templateAndLanguage + ".cshtml");
                    if (templateInfo != null)
                    {
                        Console.WriteLine($"Found: {templateAndDefaultLanguage}");
                        return razorEngine.Compile(File.ReadAllText(templateInfo.FilePath));
                    }


                    // 3. try to find the template with default language
                    templateInfo = templates.FirstOrDefault(x => x.Key == templatename);// Path.Combine(TemplateDirectory, templateAndLanguage + ".cshtml");
                    if (templateInfo != null)
                    {
                        Console.WriteLine($"Found: {templatename}");
                        return razorEngine.Compile(File.ReadAllText(templateInfo.FilePath));
                    }


                    throw new NotImplementedException($"{templatename} for {language} cannot be compiled");
                });
            }


            var result = compiledTemplate.Run(model);

            stopwatch.Stop();
            Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds}");

            //Console.WriteLine($"Result: {result}");
            Console.WriteLine($"#Items: {TemplateCache.Count}");


            return result;
        }
    }
}