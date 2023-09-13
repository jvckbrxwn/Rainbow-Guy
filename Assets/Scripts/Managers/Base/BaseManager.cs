using Managers.Interfaces;
using UnityEngine;

namespace Managers.Base
{
	public class BaseManager : IInitializable
	{
		protected BaseManager()
		{
			Debug.Log($"Hello, I'm {this.GetType()}");
		}
	}
}