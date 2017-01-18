using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlayRotation : MonoBehaviour {

    [SerializeField] private float _time;
    [SerializeField] private Vector3 _vectorTo;
    [SerializeField] private Vector3 _vectorOut;

    private void OnEnable()
    {
        StartCoroutine(RotateRight());
    }

    IEnumerator RotateRight()
    {
        LeanTween.rotateLocal(gameObject, _vectorTo, _time);
        yield return new WaitForSeconds(_time);
        StartCoroutine(RotateLeft());
    }

    IEnumerator RotateLeft()
    {
        LeanTween.rotateLocal(gameObject, _vectorOut, _time);
        yield return new WaitForSeconds(_time);
        StartCoroutine(RotateRight());
    }
}
