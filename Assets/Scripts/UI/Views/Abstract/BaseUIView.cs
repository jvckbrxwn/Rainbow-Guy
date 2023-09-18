using UnityEngine;

namespace UI.Views.Abstract
{
	//TODO: create controller with Zenject
	public abstract class BaseUIView : MonoBehaviour
	{
		[SerializeField] protected Animator animator;
		private static readonly int open = Animator.StringToHash("Open");
		private static readonly int close = Animator.StringToHash("Close");

		private void Start()
		{
			Init();
		}
		
		public virtual void Show()
		{
			animator.SetTrigger(open);
		}

		public virtual void Hide()
		{
			animator.SetTrigger(close);
		}

		protected abstract void Init();
	}
}