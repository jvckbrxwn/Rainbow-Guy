using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	[SerializeField] private float _speed;
	[SerializeField] private float _moveSpeed;
	[SerializeField] private SpriteRenderer _player;
	[SerializeField] private GameObject _gameOverPanel;
	public bool isAccelerationMove, isHalfScreenMove, isCompMove;

	void Awake()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1f;
	}

	// Update is called once per frame
	void Update()
	{
		AccelerationMove(isAccelerationMove);
		HalfScreenMove(isHalfScreenMove);
		CompMove(isCompMove);
	}

	void AccelerationMove(bool agreed)
	{
		if(agreed)
		{
			transform.Translate(Input.acceleration.x * 0.3f, 0, 0);
			if(Input.acceleration.x > 0.001f)
			{
				_player.flipX = true;
			}
			if(Input.acceleration.x < 0.001f)
			{
				_player.flipX = false;
			}
		}
	}

	void HalfScreenMove(bool agreed)
	{
		if(agreed)
		{
			if(Input.touchCount > 0)
			{
				Vector2 touchPosition = Input.GetTouch(0).position;
				double halfScreen = Screen.width / 2.0;

				//Check if it is left or right?
				if(touchPosition.x > halfScreen)
				{
					_player.flipX = true;
					transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
				}
				else if(touchPosition.x < halfScreen)
				{
					_player.flipX = false;
					transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
				}
			}
		}
	}

	void CompMove(bool agreed)
	{
		if(agreed)
		{
			if(Input.GetKey(KeyCode.D))
			{
				transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
				_player.flipX = true;
			}
			if(Input.GetKey(KeyCode.A))
			{
				transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
				_player.flipX = false;
			}
		}
	}

	/*public IEnumerator Death() {

        yield return 0;
    }*/

	public void Death()
	{
		//SceneManager.LoadScene();
		_gameOverPanel.SetActive(true);
		Time.timeScale = 0.0000000001f;
	}
}
