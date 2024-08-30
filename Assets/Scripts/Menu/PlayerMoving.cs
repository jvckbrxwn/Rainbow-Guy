using UnityEngine;
using Player.Movement.Interfaces;

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

		public void Init(IPlayerMoving playerMoving)
		{
			this.playerMoving = playerMoving;
			this.playerMoving.SetSpeed(moveSpeed);
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

		public void Jump()
		{
			playerMoving.Jump();
		}
	}
}