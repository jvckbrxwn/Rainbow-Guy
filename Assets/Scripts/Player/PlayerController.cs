using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [HideInInspector] public UIController uiControl;
    [SerializeField] private float _speed, _jumpSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private PowerUpsController _powerUpController;

    public bool isAccelerationMove, isHalfScreenMove, isCompMove, isAlive;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        uiControl = FindObjectOfType<UIController>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
        _powerUpController = GetComponent<PowerUpsController>();
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        AccelerationMove(isAccelerationMove);
        HalfScreenMove(isHalfScreenMove);
        CompMove(isCompMove);
        var playerShouldDie = Camera.main.WorldToScreenPoint(transform.position).y < Camera.main.orthographicSize * 0.1f;
        if (isAlive && playerShouldDie)
        {
            uiControl.onGameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "DeadlyPlayer")
            if (other.tag == "Enemy")
                Destroy(other.gameObject);
        if (gameObject.tag == "Player")
            if (other.tag == "Enemy")
                Death();
    }

    void AccelerationMove(bool agreed)
    {
        if (agreed)
        {
            transform.Translate(Input.acceleration.x * 0.3f, 0, 0);
            if (Input.acceleration.x > 0.001f)
            {
                _playerSpriteRenderer.flipX = true;
            }
            if (Input.acceleration.x < 0.001f)
            {
                _playerSpriteRenderer.flipX = false;
            }
        }
    }

    void HalfScreenMove(bool agreed)
    {
        if (agreed)
        {
            if (Input.touchCount > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                double halfScreen = Screen.width / 2.0;

                //Check if it is left or right?
                if (touchPosition.x > halfScreen)
                {
                    _playerSpriteRenderer.flipX = true;
                    transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
                }
                else if (touchPosition.x < halfScreen)
                {
                    _playerSpriteRenderer.flipX = false;
                    transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
                }
            }
        }
    }

    void CompMove(bool agreed)
    {
        if (agreed)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
                _playerSpriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
                _playerSpriteRenderer.flipX = false;
            }
        }
    }

    public void Death()
    {
        //SceneManager.LoadScene();
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0.0000000001f;
    }

    public float JumpSpeed
    {
        set
        {
            _jumpSpeed = value;
        }
        get
        {
            return _jumpSpeed;
        }
    }

    public void StayAlive()
    {
        Debug.Log("He stay alive!");
    }
}
