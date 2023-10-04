using UI.Views.SettingsViews.Abstract;

namespace UI.Views.SettingsViews
{
	public class SoundButtonController : BaseSettingsButtonController
	{
		protected override void OnClicked()
		{
			State = !State;
		}
	}
}