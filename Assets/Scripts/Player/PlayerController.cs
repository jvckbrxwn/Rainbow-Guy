using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField] private SpriteRenderer _player;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
            _player.flipX = true;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
            _player.flipX = false;
        }

        if (Input.touchCount > 0) {
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = Screen.width / 2.0;

            //Check if it is left or right?
            if (touchPosition.x > halfScreen) {
                transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
                _player.flipX = true;
            } else if (touchPosition.x < halfScreen) {
                transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
                _player.flipX = false;
            }
        }
    }
}
