using UnityEngine;
using System.Collections;

public class TwoPlaneScript : MonoBehaviour {

    [SerializeField] private GameObject plane1, plane2;
    private float halfOfScreen = 0f;

    // Use this for initialization
    void Start () {
        plane1.transform.position = new Vector2(Random.Range(halfOfScreen - 0.5f, -2.5f), 
            gameObject.transform.position.y);
        plane2.transform.position = new Vector2(Random.Range(halfOfScreen + 0.5f, 2.5f), 
            gameObject.transform.position.y);
    }
}
