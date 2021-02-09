using System;
using System.IO;
using RazorEngineCore;

namespace RazorEngineConsole
{
    public class SimpleTestCodeTemplate
    {

        public SimpleTestCodeTemplate()
        {

        }

        public void Run()
        {
            Console.WriteLine($"** Running {this.GetType().Name}");

            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate template = razorEngine.Compile("Hello @Model.Name");

            string result = template.Run(new
            {
                Name = "Patrick"
            });

            Console.WriteLine(result);
        }
    }
}