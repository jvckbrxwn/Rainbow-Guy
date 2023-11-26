using Player.MoveSystem.Abstract;
using UnityEngine;

namespace Player.MoveSystem
{
	public class PhoneAccelerationPlayerMoving : BasePlayerMoving
	{
		private Vector3 prevLoc = Vector3.zero;
		
		public PhoneAccelerationPlayerMoving(Transform transform, float moveSpeed) : base(transform, moveSpeed)
		{ }

		public override void Move()
		{
			Transform.Translate(Input.acceleration.normalized.x * 15f * Time.deltaTime, 0f, 0f);
			Vector3 curVel = (Transform.position - prevLoc) / Time.deltaTime;
			prevLoc = Transform.position;
		}
	}
}