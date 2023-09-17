using Cysharp.Threading.Tasks;

namespace Managers.UI.Interfaces
{
	public interface IUIManager
	{
		UniTask Show<T>();
	}
}