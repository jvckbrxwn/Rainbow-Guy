using System;
using System.Collections.Generic;
using UnityEngine;

namespace Audio.Scriptable.Base
{
	[Serializable]
	public struct BaseHolder<T> where T : Enum
	{
		public T type;
		public string address;
	}

	public class BaseAddressableHolder<T> : ScriptableObject where T : Enum
	{
		[SerializeField] private List<BaseHolder<T>> holder;

		public List<BaseHolder<T>> Holder => holder;
	}
}