using UnityEngine;
using System.Collections;

public class BouncyScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [HideInInspector] private GameObject _player;
    public GameObject spawner;
    [Range(0, 1)] public float volume;
    [SerializeField] private AudioClip _redPlatformSound;
    [SerializeField] private SoundManager _soundManager;

    // Use this for initialization
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Respawn");
        _player = GameObject.FindGameObjectWithTag("Player");
        _soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (gameObject.GetComponent<Collider2D>())
        {
            if (_player.GetComponent<Rigidbody2D>().velocity.y >= 0)
            {
                foreach (var item in gameObject.GetComponents<Collider2D>())
                {
                    item.enabled = false;
                }
            }
            else
            {
                foreach (var item in gameObject.GetComponents<Collider2D>())
                {
                    item.enabled = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
        if(gameObject.tag == "redPlatform")
        {
            _soundManager.RedPlatformSoundPlay(transform);
            Destroy(gameObject);
        }
        else
            _soundManager.GreenPlatformSoundPlay();
    }
}
