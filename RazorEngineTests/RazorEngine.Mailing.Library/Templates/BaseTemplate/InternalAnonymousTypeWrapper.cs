using RazorEngineCore;

namespace RazorEngine.Mailing.Library.Templates.BaseTemplate
{
    public class InternalAnonymousTypeWrapper : AnonymousTypeWrapper
    {
        public object Model { get; set; }

        public InternalAnonymousTypeWrapper(object model) : base(model)
        {
            Model = model;
        }
    }
}