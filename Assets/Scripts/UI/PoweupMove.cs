using UnityEngine;
using System.Collections;

public class PoweupMove : MonoBehaviour
{
	void OnEnable()
	{
		StartCoroutine(MovePowerUpsUp());
	}

	IEnumerator MovePowerUpsUp()
	{
		LeanTween.moveLocalY(gameObject, transform.localPosition.y + 0.04f, .5f);
		yield return new WaitForSeconds(.5f);
		StartCoroutine(MovePowerUpsDown());
	}

	IEnumerator MovePowerUpsDown()
	{
		LeanTween.moveLocalY(gameObject, transform.localPosition.y - 0.04f, .5f);
		yield return new WaitForSeconds(.5f);
		StartCoroutine(MovePowerUpsUp());
	}
}