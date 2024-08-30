using UnityEngine;

public class WallsFoolow : MonoBehaviour
{
	[SerializeField] private GameObject _player;
	[SerializeField] private Transform _leftWall;
	[SerializeField] private Transform _rightWall;

	void Start()
	{
		_leftWall.position = -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));
		_rightWall.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));
	}

	void Update()
	{
		if (_player.transform.position.y > 0)
		{
			if (_player.transform.position.y > transform.position.y)
			{
				transform.position = new Vector3(gameObject.transform.position.x, _player.transform.position.y, 0);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") || other.CompareTag("DeadlyPlayer") || other.CompareTag("FlyPlayer"))
			if (gameObject.CompareTag("LeftWall"))
			{
				_player.transform.position = new Vector2(_rightWall.position.x - 0.4f, _player.transform.position.y);
			}

		if (other.CompareTag("Player") || other.CompareTag("DeadlyPlayer") || other.CompareTag("FlyPlayer"))
			if (gameObject.CompareTag("RightWall"))
			{
				_player.transform.position = new Vector2(_leftWall.position.x + 0.4f, _player.transform.position.y);
			}
	}
}