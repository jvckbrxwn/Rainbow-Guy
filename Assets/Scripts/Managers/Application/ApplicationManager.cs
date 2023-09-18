using Managers.Application.Interfaces;
using Managers.Base;

namespace Managers.Application
{
	public class ApplicationManager : BaseManager, IApplicationManager
	{
		protected ApplicationManager()
		{
			UnityEngine.Application.targetFrameRate = 60;
		}
	}
}