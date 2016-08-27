using UnityEngine;
using System.Collections;

public class GenerateManager : MonoBehaviour {

    [SerializeField]
    private GameObject _player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Spawn!");
        }
    }
}
