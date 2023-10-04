using Controllers.Abstract;
using UI.Views;

namespace Controllers
{
	public class AchievementsUIController : BaseUIController<AchievementsUIView>
	{
		public AchievementsUIController(string key) : base(key)
		{ }

		protected override void Init()
		{ }
	}
}