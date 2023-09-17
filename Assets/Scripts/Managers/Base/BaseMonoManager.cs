using Managers.Interfaces;
using UnityEngine;

namespace Managers.Base
{
	public class BaseMonoManager : MonoBehaviour, IInitializable
	{
		protected virtual void Awake()
		{
			Debug.Log($"Hello, I'm {this.GetType()}");
		}
	}
}