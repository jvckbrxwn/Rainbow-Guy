namespace Player.Movement.Interfaces
{
	public interface IPlayerMoving
	{
		void Move();
		void SetSpeed(float speed);
		void Jump();
	}
}