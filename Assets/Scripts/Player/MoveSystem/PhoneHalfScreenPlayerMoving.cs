using Player.MoveSystem.Abstract;
using UnityEngine;

namespace Player.MoveSystem
{
	public class PhoneHalfScreenPlayerMoving : BasePlayerMoving
	{
		public PhoneHalfScreenPlayerMoving(Transform transform, float moveSpeed) : base(transform, moveSpeed)
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
					Transform.Translate(Vector3.right * (MoveSpeed * Time.deltaTime));
				}
				else if (touchPosition.x < halfScreen)
				{
					Transform.Translate(Vector3.left * (MoveSpeed * Time.deltaTime));
				}
			}
		}
	}
}