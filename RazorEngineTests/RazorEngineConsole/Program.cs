using System;
using System.Collections;

namespace RazorEngineConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //new SimpleTestCodeTemplate().Run();
            //new StronglyTypedTemplate().Run();
            new ExternalTemplate().Run();

            Console.WriteLine("All completed!");
        }
    }
}
