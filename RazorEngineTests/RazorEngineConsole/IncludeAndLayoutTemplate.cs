using System;
using System.Collections.Generic;
using RazorEngineCore;

public class IncludeAndLayoutTemplate
{
    public void Run()
    {
        string template = @"
                @{
                    Layout = ""MyLayout"";
                 }

                <h1>@Model.Title</h1>

                @Include(""outer"", Model)
            ";

        IDictionary<string, string> parts = new Dictionary<string, string>()
        {
            {"MyLayout", @"
                        LAYOUT HEADER
                            @RenderBody()
                        LAYOUT FOOTER
                    "},
            {"outer", "This is Outer include, <@Model.Title>, @Include(\"inner\")"},
            {"inner", "This is Inner include"}
        };

        IRazorEngine razorEngine = new RazorEngine();

        var compiledTemplate = razorEngine.Compile(template, parts);

        string result = compiledTemplate.Run(new { Title = "Hello" });

        Console.WriteLine(result);
        Console.ReadKey();
    }
}