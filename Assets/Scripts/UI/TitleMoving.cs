using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMoving : MonoBehaviour {

    [SerializeField] private float _time;
    [SerializeField] private Vector3 _vectorTo;
    [SerializeField] private Vector3 _vectorOut;

    private void OnEnable()
    {
        StartCoroutine(TitleScaleUp());
    }

    IEnumerator TitleScaleUp()
    {
        LeanTween.scale(gameObject, _vectorTo, _time);
        yield return new WaitForSeconds(_time);
        StartCoroutine(TitleScaleDown());
    }

    IEnumerator TitleScaleDown()
    {
        LeanTween.scale(gameObject, _vectorOut, _time);
        yield return new WaitForSeconds(_time);
        StartCoroutine(TitleScaleUp());
    }
}
