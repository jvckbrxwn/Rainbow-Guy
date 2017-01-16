using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResizeBackScript : MonoBehaviour
{
	[HideInInspector] public GameObject _player;
	
	// Use this for initialization
	void Awake()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();

		float worldScreenHeight = Camera.main.orthographicSize * 2;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		transform.localScale = new Vector3(
			worldScreenWidth / sr.sprite.bounds.size.x,
			worldScreenHeight / sr.sprite.bounds.size.y, 1);

		_player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if(SceneManager.GetActiveScene().buildIndex == 1)
			if(_player.transform.position.y > 0)
			{
				if(_player.transform.position.y > transform.position.y)
				{
					this.transform.position = new Vector3(gameObject.transform.position.x, _player.transform.position.y, gameObject.transform.position.z);
				}
			}
	}
}
