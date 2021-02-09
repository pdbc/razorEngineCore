using System;
using System.Collections.Generic;
using System.Text;
using RazorEngineCore;

namespace RazorEngineConsole.CustomTemplate
{
    public class LayoutTemplateBase : RazorEngineTemplateBase
    {
        public LayoutTemplateBase(IRazorEngineCompiledTemplate<LayoutTemplateBase> compile, Dictionary<string, IRazorEngineCompiledTemplate<LayoutTemplateBase>> toDictionary)
        {
            throw new NotImplementedException();
        }

        public Func<string, object, string> IncludeCallback { get; set; }
        public Func<string> RenderBodyCallback { get; set; }
        public string Layout { get; set; }

        public string Include(string key, object model = null)
        {
            return this.IncludeCallback(key, model);
        }

        public string RenderBody()
        {
            return this.RenderBodyCallback();
        }
    }
}
