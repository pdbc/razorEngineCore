using System.Collections.Generic;
using System.Linq;
using RazorEngineCore;

namespace RazorEngineConsole.CustomTemplate
{
    public static class RazorEngineCoreExtensions
    {
        public static MyCompiledTemplate Compile(this RazorEngine razorEngine, string template, IDictionary<string, string> parts)
        {
            return new MyCompiledTemplate(
                razorEngine.Compile<LayoutTemplateBase>(template),
                parts.ToDictionary(
                    k => k.Key,
                    v => razorEngine.Compile<LayoutTemplateBase>(v.Value)));
        }
    }
}