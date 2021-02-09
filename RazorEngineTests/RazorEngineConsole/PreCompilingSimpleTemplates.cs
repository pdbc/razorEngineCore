using System;
using System.IO;
using RazorEngineCore;

namespace RazorEngineConsole
{
    public class PreCompilingSimpleTemplates
    {
        public void Run()
        {
            Console.WriteLine($"** Running {this.GetType().Name}");

            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate template = razorEngine.Compile("Hello @Model.Name");

            // save to file
            template.SaveToFile("myTemplate.dll");

            //save to stream
            MemoryStream memoryStream = new MemoryStream();
            template.SaveToStream(memoryStream);
            IRazorEngineCompiledTemplate template1 = RazorEngineCompiledTemplate.LoadFromFile("myTemplate.dll");
            IRazorEngineCompiledTemplate template2 = RazorEngineCompiledTemplate.LoadFromStream(myStream);
        }
    }
}