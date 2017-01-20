using UnityEngine;
using System.Collections;

public class DestroyBoxScript : MonoBehaviour
{

    [HideInInspector]
    public PlayerController pc;
    [SerializeField]
    private Transform _player;

    // Use this for initialization
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (_player.position.y > 0) {
            if (_player.position.y > transform.position.y) {
                this.transform.position = new Vector2(gameObject.transform.position.x, _player.position.y - 2.3f);
            }
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Plane")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Player")
        {
            pc.Die(false);
        }
    }
}
