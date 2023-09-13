using Managers.UI.Interfaces;
using Managers.Base;
using Managers.Interfaces;
using UI.Views.Abstract;

namespace Managers.UI
{
	public class UIManager : BaseManager, IUIManager
	{
		private readonly IAddressableManager addressableManager;

		protected UIManager(IAddressableManager addressableManager)
		{
			this.addressableManager = addressableManager;
		}

		public async void Show<T>(string key) where T : BaseUIView
		{
			T view = await addressableManager.GetObject<T>(key);
			view.Show();
		}
	}
}