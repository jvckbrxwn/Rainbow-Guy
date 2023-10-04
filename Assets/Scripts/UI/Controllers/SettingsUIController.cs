using Controllers.Abstract;
using Managers.User.Interfaces;
using UI.Views;
using Zenject;

namespace Controllers
{
	public class SettingsUIController : BaseUIController<SettingsUIView>
	{
		[Inject] private IUserManager userManager;

		public SettingsUIController(string key) : base(key)
		{ }

		protected override void Init()
		{
			View.MusicButtonController.Clicked += OnMusicClicked;
			View.SoundsButtonController.Clicked += OnSoundsClicked;
		}

		private void OnSoundsClicked()
		{
			userManager.UserData.settingsData.soundsState = View.SoundsButtonController.State;
		}

		private void OnMusicClicked()
		{
			userManager.UserData.settingsData.musicState = View.MusicButtonController.State;
		}
	}
}