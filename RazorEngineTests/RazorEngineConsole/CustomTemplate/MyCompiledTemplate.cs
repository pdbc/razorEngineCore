using System.Collections.Generic;
using RazorEngineCore;

namespace RazorEngineConsole.CustomTemplate
{
    public class InternalAnonymousTypeWrapper : AnonymousTypeWrapper
    {
        public object Model { get; set; }

        public InternalAnonymousTypeWrapper(object model) : base(model)
        {
            Model = model;
        }
    }
    public class MyCompiledTemplate
    {
        private readonly IRazorEngineCompiledTemplate<LayoutTemplateBase> compiledTemplate;
        private readonly Dictionary<string, IRazorEngineCompiledTemplate<LayoutTemplateBase>> compiledParts;

        public MyCompiledTemplate(IRazorEngineCompiledTemplate<LayoutTemplateBase> compiledTemplate, Dictionary<string, IRazorEngineCompiledTemplate<LayoutTemplateBase>> compiledParts)
        {
            this.compiledTemplate = compiledTemplate;
            this.compiledParts = compiledParts;
        }

        public string Run(object model)
        {
            return this.Run(this.compiledTemplate, model);
        }

        public string Run(IRazorEngineCompiledTemplate<LayoutTemplateBase> template, object model)
        {
            LayoutTemplateBase templateReference = null;

            string result = template.Run(instance =>
            {
                if (!(model is InternalAnonymousTypeWrapper))
                {
                    model = new InternalAnonymousTypeWrapper(model);
                }

                instance.Model = model;
                instance.IncludeCallback = (key, includeModel) => this.Run(this.compiledParts[key], includeModel);

                templateReference = instance;
            });

            if (templateReference.Layout == null)
            {
                return result;
            }

            return this.compiledParts[templateReference.Layout].Run(instance =>
            {
                if (!(model is InternalAnonymousTypeWrapper))
                {
                    model = new InternalAnonymousTypeWrapper(model);
                }

                instance.Model = model;
                instance.IncludeCallback = (key, includeModel) => this.Run(this.compiledParts[key], includeModel);
                instance.RenderBodyCallback = () => result;
                instance.RenderTextBodyCallback = () => "The text of the mail should come here !!!!";
            });
        }

        public void Save()
        {
            /*
            TODO

            this.compiledTemplate.SaveToFile();
            this.compiledTemplate.SaveToStream();

            foreach (var compiledPart in this.compiledParts)
            {
                compiledPart.Value.SaveToFile();
                compiledPart.Value.SaveToStream();
            }
            */
        }

        public void Load()
        {
            // TODO
        }
    }
}