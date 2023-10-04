using UI.Views.Abstract;
using UI.Views.SettingsViews;
using UnityEngine;

namespace UI.Views
{
	public class SettingsUIView : BaseUIView
	{
		[SerializeField] private MusicButtonController musicButtonController;
		[SerializeField] private SoundButtonController soundButtonController;

		public MusicButtonController MusicButtonController => musicButtonController;
		public SoundButtonController SoundsButtonController => soundButtonController;

		protected override void Init()
		{ }
	}
}