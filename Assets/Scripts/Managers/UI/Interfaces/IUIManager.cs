using UI.Views.Abstract;

namespace Managers.UI.Interfaces
{
	public interface IUIManager
	{
		void Show<T>(string key) where T : BaseUIView;
	}
}