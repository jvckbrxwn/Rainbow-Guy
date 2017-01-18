using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPanel : MonoBehaviour {

    [SerializeField] private LoadScene _loadScene;

	void Start () {
        _loadScene = FindObjectOfType<LoadScene>();
	}

    void Update()
    {
        if (Input.touchCount > 0)
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                _loadScene.LoadNumberScene(1);
        if (Input.GetMouseButton(0))
            _loadScene.LoadNumberScene(1);
    }
}
