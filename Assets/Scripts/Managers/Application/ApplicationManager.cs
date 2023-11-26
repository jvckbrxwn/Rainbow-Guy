namespace Managers.Application
{
	using UnityEngine;
	using Interfaces;
	using Base;

	public class ApplicationManager : BaseManager, IApplicationManager
	{
		protected ApplicationManager()
		{
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
			Application.targetFrameRate = int.MaxValue;
		}
	}
}