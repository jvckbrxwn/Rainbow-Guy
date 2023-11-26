using Managers.Player;
using UnityEngine;
using Managers.Sound.Interfaces;

public class BouncyScript : MonoBehaviour
{
	[SerializeField] private Collider2D _collider2D;
	[SerializeField] private GameObject spawner;

	//inject
	private ISoundManager soundManager;
	//inject
	private PlayerManager playerManager;

	// Use this for initialization
	void Start()
	{
		spawner = GameObject.FindGameObjectWithTag("Respawn");
	}
}