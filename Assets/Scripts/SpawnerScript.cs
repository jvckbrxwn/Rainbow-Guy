using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour {

    [SerializeField] private GameObject[] itemsToSpawn;
    //public List<GameObject> floors;
    [HideInInspector] public float lastYPosition;

    // Use this for initialization
    void Start() {
        lastYPosition = 0;
    }

    // Update is called once per frame
    void Update() {
        if (lastYPosition < Camera.main.transform.position.y + Camera.main.orthographicSize) { 
            Spawn();
        }
    }

    void Spawn() {
        Instantiate(itemsToSpawn[Random.Range(0, itemsToSpawn.Length)],
            new Vector3(transform.position.x, transform.position.y),
            Quaternion.identity);

        lastYPosition = gameObject.transform.position.y;
    }
}
