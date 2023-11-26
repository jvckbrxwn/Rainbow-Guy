using Player.MoveSystem.Interfaces;
using UnityEngine;

namespace Player.MoveSystem.Abstract
{
	public abstract class BasePlayerMoving : IPlayerMoving
	{
		protected readonly Transform Transform;
		protected readonly float MoveSpeed;

		protected BasePlayerMoving(Transform transform, float moveSpeed)
		{
			Transform = transform;
			MoveSpeed = moveSpeed;
		}

		public abstract void Move();
	}
}