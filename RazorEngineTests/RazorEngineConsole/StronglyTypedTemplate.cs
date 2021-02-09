using System;
using System.IO;
using RazorEngineConsole.Models;
using RazorEngineCore;

namespace RazorEngineConsole
{
    public class StronglyTypedTemplate
    {
        public void Run()
        {
            Console.WriteLine($"** Running {this.GetType().Name}");

            IRazorEngine razorEngine = new RazorEngine();
            string templateText = "Hello @Model.Name";

            // yeah, heavy definition
            IRazorEngineCompiledTemplate<RazorEngineTemplateBase<TestModel>> template = razorEngine.Compile<RazorEngineTemplateBase<TestModel>>(templateText);

            string result = template.Run(instance =>
            {
                instance.Model = new TestModel()
                {
                    Name = "Hello",
                    //Items = new[] { 3, 1, 2 }
                };
            });

            Console.WriteLine(result);
        }
    }

    //public class PreCompilingTypedModelsTemplates
    //{
    //    public void Run()
    //    {
    //        Console.WriteLine($"** Running {this.GetType().Name}");

    //        IRazorEngine razorEngine = new RazorEngine();
    //        IRazorEngineCompiledTemplate template = razorEngine.Compile("Hello @Model.Name");

    //        // save to file
    //        template.SaveToFile("myTemplate.dll");

    //        //save to stream
    //        MemoryStream myStream = new MemoryStream();
    //        template.SaveToStream(memoryStream);

    //        IRazorEngineCompiledTemplate<TestModel> template1 = RazorEngineCompiledTemplate<TestModel>.LoadFromFile<TestModel>("myTemplate.dll");
    //        IRazorEngineCompiledTemplate<TestModel> template2 =
    //            RazorEngineCompiledTemplate<TestModel>.LoadFromStream<TestModel>(myStream);
    //    }
    //}
}