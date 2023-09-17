using Controllers.Abstract;
using UI.Views;

namespace Controllers
{
	public class SettingsUIController : BaseUIController<SettingsUIView>
	{
		public SettingsUIController(string key) : base(key)
		{ }
	}
}