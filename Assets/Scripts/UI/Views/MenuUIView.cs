using System;
using UI.Views.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
	public class MenuUIView : BaseUIView
	{
		[SerializeField] private Button shopButton;
		[SerializeField] private Button settingsButton;
		[SerializeField] private Button achievementsButton;

		public event Action ShopClicked;
		public event Action SettingsClicked;
		public event Action AchievementsClicked;

		private void Awake()
		{
			shopButton.onClick.AddListener(OnShopClicked);
			settingsButton.onClick.AddListener(OnSettingsClicked);
			achievementsButton.onClick.AddListener(OnAchievementsClicked);
		}

		private void OnAchievementsClicked()
		{
			AchievementsClicked?.Invoke();
		}

		private void OnSettingsClicked()
		{
			SettingsClicked?.Invoke();
		}

		private void OnShopClicked()
		{
			ShopClicked?.Invoke();
		}

		public override void Show()
		{
			gameObject.SetActive(true);
		}

		public override void Hide()
		{ }
	}
}