using UnityEngine;
using System.Collections;
using Managers.Sound.Interfaces;
using AudioType = Audio.Scriptable.AudioType;

public class BouncyScript : MonoBehaviour
{
	private GameObject _player;
	private Collider2D _collider2D;
	private PlayerController _playerControl;
	public GameObject spawner;
	[SerializeField] private AudioClip _redPlatformSound;
	[Range(0, 1)] public float volume;

	private ISoundManager soundManager;

	// Use this for initialization
	void Start()
	{
		spawner = GameObject.FindGameObjectWithTag("Respawn");
		_player = FindObjectOfType<PlayerController>().gameObject;
		_playerControl = _player.GetComponent<PlayerController>();
		soundManager = FindObjectOfType<SoundManager>();
		_collider2D = GetComponent<Collider2D>();
	}

	void Update()
	{
		if (gameObject.GetComponent<Collider2D>())
		{
			if (_player.GetComponent<Rigidbody2D>().velocity.y >= 0)
			{
				_collider2D.enabled = false;
			}
			else
			{
				_collider2D.enabled = true;
			}
		}

		var destroyPlane = Camera.main.WorldToScreenPoint(transform.position).y < Camera.main.orthographicSize;
		if (destroyPlane)
			Destroy(gameObject);
	}

	async void OnTriggerEnter2D(Collider2D other)
	{
		other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _playerControl.JumpSpeed, ForceMode2D.Impulse);
		if (gameObject.tag == "redPlatform")
		{
			await soundManager.PlaySound(AudioType.RedPlatform);
			Destroy(gameObject);
		}
		else
		{
			await soundManager.PlaySound(AudioType.GreenPlatform);
		}
	}
}