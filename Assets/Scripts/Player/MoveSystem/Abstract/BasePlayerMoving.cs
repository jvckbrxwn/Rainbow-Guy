using Player.Movement.Interfaces;
using UnityEngine;

namespace Player.Movement.Abstract
{
	public abstract class BasePlayerMoving : IPlayerMoving
	{
		protected readonly Rigidbody2D Rigidbody2D;
		protected float MoveSpeed;

		protected BasePlayerMoving(Rigidbody2D rigidbody2D)
		{
			Rigidbody2D = rigidbody2D;
		}

		public void SetSpeed(float speed)
		{
			MoveSpeed = speed;
		}

		public virtual void Jump()
		{
			Rigidbody2D.velocity = Vector2.zero;
			Rigidbody2D.AddRelativeForce(Vector2.up * MoveSpeed * 10000, ForceMode2D.Impulse);
		}

		public abstract void Move();
	}
}