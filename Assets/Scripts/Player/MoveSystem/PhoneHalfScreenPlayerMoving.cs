using Player.Movement.Abstract;
using UnityEngine;

namespace Player.Movement
{
	public class PhoneHalfScreenPlayerMoving : BasePlayerMoving
	{
		public PhoneHalfScreenPlayerMoving(Rigidbody2D rigidbody2D) : base(rigidbody2D)
		{ }
		
		public override void Move()
		{
			if (Input.touchCount > 0)
			{
				Vector2 touchPosition = Input.GetTouch(0).position;
				double halfScreen = Screen.width / 2.0;

				//Check if it is left or right?
				if (touchPosition.x > halfScreen)
				{
					Rigidbody2D.velocity = Vector3.right * (MoveSpeed * Time.deltaTime);
				}
				else if (touchPosition.x < halfScreen)
				{
					Rigidbody2D.velocity = Vector3.left * (MoveSpeed * Time.deltaTime);
				}
			}
		}
	}
}