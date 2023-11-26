using Zenject;

namespace Managers.Base
{
	public class BaseManager : IInitializable
	{
		protected BaseManager()
		{ }

		public virtual void Initialize()
		{ }
	}
}