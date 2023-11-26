using UnityEngine;
using UnityEngine.SceneManagement;

public class ResizeBackScript : MonoBehaviour
{
	private GameObject player;

	// Use this for initialization
	void Awake()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();

		float worldScreenHeight = Camera.main.orthographicSize * 2;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		var sprite = sr.sprite;
		transform.localScale = new Vector3(worldScreenWidth / sprite.bounds.size.x,
			worldScreenHeight / sprite.bounds.size.y, 1);
	}

	void Update()
	{
		// if (SceneManager.GetActiveScene().buildIndex == 1)
		// 	if (player.transform.position.y > 0)
		// 	{
		// 		if (player.transform.position.y > transform.position.y)
		// 		{
		// 			var o = gameObject;
		// 			var position = o.transform.position;
		// 			transform.position = new Vector3(position.x, player.transform.position.y, position.z);
		// 		}
		// 	}
	}
}