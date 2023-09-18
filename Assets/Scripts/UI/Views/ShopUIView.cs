using System;
using System.Collections.Generic;
using Shop.Panels.Abstract;
using UI.Views.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
	[Serializable]
	public class ShopViewHolder
	{
		[SerializeField] private Button button;
		[SerializeField] private BaseViewController shopController;

		public event Action<BaseViewController> ViewWasOpened;

		public BaseViewController ShopController => shopController;

		public void Init()
		{
			button.onClick.AddListener(OnButtonClicked);
		}

		private void OnButtonClicked()
		{
			ViewWasOpened?.Invoke(ShopController);
		}
	}

	public class ShopUIView : BaseUIView
	{
		[SerializeField] private List<ShopViewHolder> shopViewsHolder;

		private IShopController previousShopController;

		public override void Show()
		{
			gameObject.SetActive(true);
		}

		public override void Hide()
		{
			gameObject.SetActive(false);
		}

		protected override void Init()
		{
			InitButtons();
		}

		private void InitButtons()
		{
			shopViewsHolder.ForEach(x =>
			{
				x.Init();
				x.ViewWasOpened += OnViewWasOpened;
			});
		}

		private void OnViewWasOpened(BaseViewController viewController)
		{
			previousShopController?.Hide();
			previousShopController = viewController;
			previousShopController.Show();
		}
	}
}