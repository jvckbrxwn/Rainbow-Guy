using System;

namespace Managers.User.Interfaces
{
	public interface IUserManager
	{
		public UserData UserData { get; }
	}

	[Serializable]
	public class UserData
	{
		public SettingsData settingsData = new();
	}

	[Serializable]
	public class SettingsData
	{
		public bool musicState;
		public bool soundsState;
	}
}