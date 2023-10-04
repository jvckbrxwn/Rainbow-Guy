using UI.Views.SettingsViews.Abstract;

namespace UI.Views.SettingsViews
{
	public class MusicButtonController : BaseSettingsButtonController
	{
		protected override void OnClicked()
		{
			State = !State;
		}
	}
}