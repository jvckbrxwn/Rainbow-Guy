using Controllers.Abstract;
using UI.Views;

namespace Controllers
{
	public class GameUIController : BaseUIController<GameUIView>
	{
		public GameUIController(string key) : base(key)
		{ }

		protected override void Init()
		{ }
	}
}