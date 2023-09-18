using UnityEngine;
using UnityEngine.UI;

namespace Shop.Panels.Abstract
{
	public abstract class BaseViewController : MonoBehaviour, IShopController
	{
		protected abstract void Init();

		protected virtual void Awake()
		{
			Init();
		}

		public abstract void Show();
		public abstract void Hide();
	}

	public abstract class BaseViewShopController<T> : BaseViewController
	{
		[SerializeField] private GridLayoutGroup gridLayout;
		[SerializeField] private BaseShopViewItem shopViewItem;
		[SerializeField] private T items;

		protected T Items => items;
		protected GridLayoutGroup ParentLayout => gridLayout;
		protected BaseShopViewItem ShopViewItem => shopViewItem;

		public override void Show()
		{
			gameObject.SetActive(true);
		}

		public override void Hide()
		{
			gameObject.SetActive(false);
		}
	}

	public interface IShopController
	{
		void Show();
		void Hide();
	}
}