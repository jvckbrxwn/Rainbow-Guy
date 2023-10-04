using Managers.User.Interfaces;

namespace Managers.User
{
	public class UserManager : IUserManager
	{
		public UserManager()
		{ }

		public UserData UserData { get; } = new ();
	}
}