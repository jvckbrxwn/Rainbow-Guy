using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PowerUpsController : MonoBehaviour
{
	[HideInInspector] public bool isFlying = false;
	[SerializeField] private float _flySpeed;
	[SerializeField] private Rigidbody2D _rigidbody2D;
	[SerializeField] private Sprite[] _sprites;
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private Collider2D _collider2D;
	[SerializeField] private GameObject _flashlightPanel;
	private bool isHighJump = false, isDeadly = false;
	private int low = 0;
	private PlayerController _playerControl;
	private ClothesManager _clothesManager;
	private SoundManager _soundManager;

	void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_collider2D = GetComponent<Collider2D>();
		_playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		_clothesManager = FindObjectOfType<ClothesManager>();
		_soundManager = FindObjectOfType<SoundManager>();
	}

	void Update()
	{
		if (isFlying)
			StartCoroutine(FlyPowerUp());
		if (isHighJump)
			StartCoroutine(HighJumpPowerUp());
		if (isDeadly)
			StartCoroutine(DeadlyPowerUp());
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (gameObject.tag == "Player" || gameObject.tag == "DeadlyPlayer")
		{
			if (other.tag == "PowerUpFly")
				FlyPU(other);
			if (other.tag == "PowerUpHighJump")
				HighJumpPU(other);
			if (other.tag == "PowerUpDeadly")
				DeadlyPU(other);
			FlashlightRoomCollision(other);
		}

		///mb gavnokod
		if (gameObject.tag == "FlyPlayer")
		{
			FlashlightRoomCollision(other);
		}
	}

	private void FlashlightRoomCollision(Collider2D other)
	{
		if (other.tag == "PowerUpFalshLightPlatform")
		{
			_soundManager.FlashlightOffOn();
			FlashlightPU(other.gameObject, 1f, 0.2f, true);
			Destroy(other.gameObject);
		}

		if (other.tag == "PowerUpFlashlight")
			FlashlightPU(other.gameObject, 0.5f, 0.2f, true);
		if (other.tag == "PowerUpFlashlightOff")
		{
			_soundManager.FlashlightOffOn();
			FlashlightPU(other.gameObject, 0f, 0.2f, true, false, 0.2f);
		}
	}

	private void FlashlightPU(GameObject other, float fade, float time, bool ignoreTimeScale,
		bool activePanel = true, float offTime = 0f)
	{
		if (other.tag == "PowerUpFalshLightPlatform")
			_flashlightPanel.GetComponent<CanvasRenderer>().SetAlpha(0.01f);
		StartCoroutine(OffFlashLightPanel(activePanel, offTime));
		_flashlightPanel.GetComponent<Image>().CrossFadeAlpha(fade, time, ignoreTimeScale);
		Destroy(other);
	}

	IEnumerator OffFlashLightPanel(bool activePanel, float time)
	{
		yield return new WaitForSeconds(time);
		_flashlightPanel.SetActive(activePanel);
	}

	private void DeadlyPU(Collider2D other)
	{
		StopAllCoroutines();
		PowerUpAction(PowerUpState.deadly);
		Destroy(other.gameObject);
		ChangeSprite(_sprites[2]);
	}

	private void HighJumpPU(Collider2D other)
	{
		StopAllCoroutines();
		PowerUpAction(PowerUpState.high_jump);
		Destroy(other.gameObject);
		ChangeSprite(_sprites[1]);
		_clothesManager._playerSprites[2].enabled = false;
	}

	private void FlyPU(Collider2D other)
	{
		StopAllCoroutines();
		PowerUpAction(PowerUpState.fly);
		Destroy(other.gameObject);
		ChangeSprite(_sprites[0]);
		for (int i = 0; i < _clothesManager._playerSprites.Length; i++)
		{
			_clothesManager._playerSprites[i].enabled = false;
		}
	}

	IEnumerator ChangeSpriteBack(Sprite sprite)
	{
		yield return new WaitForSeconds(5f);
		_spriteRenderer.sprite = sprite;
	}

	IEnumerator HighJumpPowerUp()
	{
		_playerControl.JumpSpeed = 15;
		yield return new WaitForSeconds(5f);
		_playerControl.JumpSpeed = 8.5f;
		isHighJump = false;
		_clothesManager._playerSprites[2].enabled = true;
		StopCoroutine(HighJumpPowerUp());
	}

	IEnumerator DeadlyPowerUp()
	{
		_playerControl.gameObject.tag = "DeadlyPlayer";
		yield return new WaitForSeconds(5f);
		_playerControl.gameObject.tag = "Player";
		isDeadly = false;
		StopCoroutine(DeadlyPowerUp());
	}

	public IEnumerator FlyPowerUp()
	{
		_rigidbody2D.velocity = Vector2.zero;
		_playerControl.gameObject.tag = "FlyPlayer";
		_rigidbody2D.AddRelativeForce(Vector2.up * _flySpeed, ForceMode2D.Impulse);
		yield return new WaitForSeconds(5f);
		isFlying = false;
		_playerControl.gameObject.tag = "Player";
		for (int i = 0; i < _clothesManager._playerSprites.Length; i++)
		{
			_clothesManager._playerSprites[i].enabled = true;
		}

		StopCoroutine(FlyPowerUp());
	}

	void PowerUpAction(PowerUpState state)
	{
		if (state == PowerUpState.high_jump)
			isHighJump = true;
		if (state == PowerUpState.fly)
			isFlying = true;
		if (state == PowerUpState.deadly)
			isDeadly = true;
	}

	void ChangeSprite(Sprite sprite)
	{
		_spriteRenderer.sprite = sprite;
		StartCoroutine(ChangeSpriteBack(_sprites[3]));
	}

	enum PowerUpState
	{
		fly, high_jump, deadly
	}
}