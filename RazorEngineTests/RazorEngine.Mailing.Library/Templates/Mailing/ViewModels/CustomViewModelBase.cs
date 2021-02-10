using RazorEngine.Templating;

namespace IdentityStore.Core.Mailing.ViewModels
{
    public class CustomViewModelBase<T> : TemplateBase<T>
	{
		public new T Model
		{
			get { return base.Model; }
			set { base.Model = value; }
		}

		public CustomViewModelBase()
		{
		}
	}
}
