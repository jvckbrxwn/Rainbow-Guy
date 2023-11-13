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
		[SerializeField] private Button playButton;

		public event Action ShopClicked;
		public event Action SettingsClicked;
		public event Action AchievementsClicked;
		public event Action PlayClicked;

		private void OnPlayClicked()
		{
			PlayClicked?.Invoke();
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
		{
			gameObject.SetActive(false);
		}

		protected override void Init()
		{
			shopButton.onClick.AddListener(OnShopClicked);
			settingsButton.onClick.AddListener(OnSettingsClicked);
			achievementsButton.onClick.AddListener(OnAchievementsClicked);
			playButton.onClick.AddListener(OnPlayClicked);
		}
	}
}