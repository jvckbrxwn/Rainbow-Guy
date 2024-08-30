using Player.Movement.Abstract;
using UnityEngine;

namespace Player.Movement
{
	public class EditorPlayerMoving : BasePlayerMoving
	{
		public EditorPlayerMoving(Rigidbody2D rigidbody2D) : base(rigidbody2D)
		{ }
		
		public override void Move()
		{
			if (Input.GetKey(KeyCode.D))
			{
				Rigidbody2D.velocity += Vector2.right * (MoveSpeed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.A))
			{
				Rigidbody2D.velocity += Vector2.left * (MoveSpeed * Time.deltaTime);
			}
		}
	}
}