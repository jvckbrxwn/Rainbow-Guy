using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] private Sprite[] _enemySprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerController _playerControl;

	// Use this for initialization
	void Awake () {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerControl = GameObject.FindObjectOfType<PlayerController>();
	}

    void Start()
    {
        _spriteRenderer.sprite = _enemySprites[Random.Range(0, _enemySprites.Length)];
        StartCoroutine(MoveEnemy());
    }

    IEnumerator MoveEnemy()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        LeanTween.moveLocalX(gameObject, transform.localPosition.x + 0.15f, .5f);
        yield return new WaitForSeconds(.5f);
        StartCoroutine(MoveEnemyBack());
    }

    IEnumerator MoveEnemyBack()
    {
        GetComponent<SpriteRenderer>().flipX = false;
        LeanTween.moveLocalX(gameObject, transform.localPosition.x - 0.15f, .5f);
        yield return new WaitForSeconds(.5f);
        StartCoroutine(MoveEnemy());
    }
}
