using UnityEngine;
using System.Collections;

public class WallsFoolow : MonoBehaviour
{

	[SerializeField] private GameObject _player;
	[SerializeField] private Transform _leftWall;
	[SerializeField] private Transform _rightWall;
	[SerializeField] private TrailRenderer _trailRender;

	void Start()
	{
		_player = FindObjectOfType<PlayerController>().gameObject;
		_trailRender = _player.GetComponent<TrailRenderer>();
	}

	void Update()
	{
		if(_player.transform.position.y > 0)
		{
			if(_player.transform.position.y > transform.position.y)
			{
				this.transform.position = new Vector3(gameObject.transform.position.x, _player.transform.position.y, 0);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "Player" || other.tag == "DeadlyPlayer")
            if (gameObject.tag == "LeftWall")
            {
                _player.transform.position = new Vector2(_rightWall.position.x - 0.4f, _player.transform.position.y);
            }

        if (other.tag == "Player" || other.tag == "DeadlyPlayer")
            if (gameObject.tag == "RightWall")
            {
                _player.transform.position = new Vector2(_leftWall.position.x + 0.4f, _player.transform.position.y);
            }
	}
}
