using UnityEngine;
using System.Collections;

public class OnePlaneScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		transform.position = new Vector2(Random.Range(-2.85f, 2.85f), transform.position.y);
	}
}