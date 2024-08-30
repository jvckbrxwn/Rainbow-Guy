using Player.Movement.Abstract;
using UnityEngine;

namespace Player.Movement
{
	public class PhoneAccelerationPlayerMoving : BasePlayerMoving
	{
		public PhoneAccelerationPlayerMoving(Rigidbody2D rigidbody2D) : base(rigidbody2D)
		{ }

		public override void Move()
		{
			Rigidbody2D.velocity = new Vector2(Input.acceleration.normalized.x * MoveSpeed * Time.deltaTime,
				Vector3.down.y * (MoveSpeed * Time.deltaTime));
		}
	}
}