using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed, _jumpSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _gameOverPanel;
    private UIController _uiControl;
    private SpriteRenderer _playerSpriteRenderer;
    private PowerUpsController _powerUpController;
    private ClothesManager _cloth;

    public bool isAccelerationMove, isHalfScreenMove, isCompMove, isAlive;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        _uiControl = FindObjectOfType<UIController>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
        _powerUpController = GetComponent<PowerUpsController>();
        _cloth = GetComponent<ClothesManager>();
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
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "DeadlyPlayer")
            if (other.tag == "Enemy")
                Destroy(other.gameObject);
        if (gameObject.tag == "Player")
            if (other.tag == "Enemy")
                Die();
        if (gameObject.tag == "DeadlyPlayer" || gameObject.tag == "Player")
            if (other.tag == "Blackhole")
                StartCoroutine(DieInBlackHole());
    }

    private IEnumerator DieInBlackHole()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        LeanTween.rotateZ(gameObject, 700f, 0.5f);
        LeanTween.scale(gameObject, new Vector2(2f, 2f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Die();
    }

    #region Move Control
    Vector3 prevLoc = Vector3.zero;
    void AccelerationMove(bool agreed)
    {
        if (agreed)
        {
            transform.Translate(Input.acceleration.normalized.x * 15f * Time.deltaTime, 0f, 0f);
            Vector3 curVel = (transform.position - prevLoc) / Time.deltaTime;
            if (curVel.x > 0)
            {
                FlipX(true);
            }
            else
            {
                FlipX(false);
            }
            prevLoc = transform.position;
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
                    FlipX(true);
                    transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
                }
                else if (touchPosition.x < halfScreen)
                {
                    FlipX(false);
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
                FlipX(true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
                FlipX(false);
            }
        }
    }

    private void FlipX(bool isFlip)
    {
        _playerSpriteRenderer.flipX = isFlip;
        _cloth._playerSprites[0].flipX = isFlip;
        _cloth._playerSprites[1].flipX = isFlip;
        _cloth._playerSprites[2].flipX = isFlip;
    }
    #endregion

    public void Die()
    {
        _uiControl.onGameOver();
    }

    public void StayAlive()
    {
        RigidbodySettings(false, 5f);
        _uiControl.OnStayAlive();
        _powerUpController.isFlying = true;
        StartCoroutine(IsAliveDelay());
    }

    private void RigidbodySettings(bool kinematic, float lScale)
    {
        gameObject.transform.localScale = new Vector2(lScale, lScale);
        gameObject.GetComponent<Rigidbody2D>().isKinematic = kinematic;
        gameObject.transform.rotation = Quaternion.identity;
    }

    IEnumerator IsAliveDelay()
    {
        yield return new WaitForSeconds(.5f);
        isAlive = true;
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
}
