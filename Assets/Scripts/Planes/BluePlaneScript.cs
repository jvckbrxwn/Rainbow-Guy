using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlaneScript : MonoBehaviour {

    private float _delta = 2.8f;  // Amount to move left and right from the start point
    private float _speed;
    private Vector3 startPos;

    void Start()
    {
        startPos = new Vector3(0, transform.position.y);
        _speed = Random.Range(0.3f, 1f);
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += _delta * Mathf.Sin(Time.time * _speed);
        transform.position = v;
    }
}
