using Managers.Player;
using Player.Movement;
using UnityEngine;

namespace Controllers.Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private PlayerMoving playerMoving;
		[SerializeField] private new Rigidbody2D rigidbody2D;
		
		private void Awake()
		{
#if UNITY_EDITOR
			playerMoving.Init(new EditorPlayerMoving(rigidbody2D));
#elif UNITY_IOS || UNITY_ANDROID
			playerMoving.Init(new PhoneAccelerationPlayerMoving(transform));
#endif
		}

		public void Jump()
		{
			playerMoving.Jump();
		}
	}
}