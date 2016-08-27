using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    [SerializeField]
    private Transform _player;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (_player.position.y > 0) {
            if (_player.position.y > transform.position.y) {
                this.transform.position = new Vector3(0, _player.position.y, -1);
            }
        }
    }


}
