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
			gameObject.SetActive(true);
			animator.SetTrigger(open);
		}

		public virtual void Hide()
		{
			animator.SetTrigger(close);
		}

		public virtual void Disable()
		{
			gameObject.SetActive(false);
		}

		protected abstract void Init();
	}
}