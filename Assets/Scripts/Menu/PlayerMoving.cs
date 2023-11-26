using Player.MoveSystem;
using UnityEngine;
using Player.MoveSystem.Interfaces;

namespace Managers.Player
{
	public class PlayerMoving : MonoBehaviour
	{
		[SerializeField] private float moveSpeed = 2f;

		//TODO: make holder for that
		private SpriteRenderer _playerSpriteRenderer;
		private PowerUpsController _powerUpController;
		private ClothesManager _cloth;

		private IPlayerMoving playerMoving;

		private void Awake()
		{
#if UNITY_EDITOR
			playerMoving = new EditorPlayerMoving(transform, moveSpeed);
#elif UNITY_IOS || UNITY_ANDROID
			playerMoving = new PhoneAccelerationPlayerMoving(transform, moveSpeed);
#endif
		}

		private void Update()
		{
			playerMoving.Move();
		}

		private void FlipX(bool isFlip)
		{
			_playerSpriteRenderer.flipX = isFlip;
			_cloth._playerSprites[0].flipX = isFlip;
			_cloth._playerSprites[1].flipX = isFlip;
			_cloth._playerSprites[2].flipX = isFlip;
		}
	}
}