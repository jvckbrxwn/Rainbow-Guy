using Player.MoveSystem.Abstract;
using UnityEngine;

namespace Player.MoveSystem
{
	public class EditorPlayerMoving : BasePlayerMoving
	{
		public EditorPlayerMoving(Transform transform, float moveSpeed) : base(transform, moveSpeed)
		{ }
		
		public override void Move()
		{
			if (Input.GetKey(KeyCode.D))
			{
				Transform.Translate(Vector3.right * (MoveSpeed * Time.deltaTime));
			}

			if (Input.GetKey(KeyCode.A))
			{
				Transform.Translate(Vector3.left * (MoveSpeed * Time.deltaTime));
			}
		}
	}
}