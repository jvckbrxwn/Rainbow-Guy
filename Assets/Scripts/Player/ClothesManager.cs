using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
	public SpriteRenderer[] _playerSprites;
	[SerializeField] private Sprite[] _hats;
	[SerializeField] private Sprite[] _jackets;
	[SerializeField] private Sprite[] _shoes;

	// Use this for initialization
	void Start ()
	{
		var h = PlayerPrefs.HasKey("SelectedHat")
			? _playerSprites[0].sprite = _hats[PlayerPrefs.GetInt("SelectedHat")]
			: _playerSprites[0].sprite = _hats[0];

		var j = PlayerPrefs.HasKey("SelectedJacket")
			? _playerSprites[1].sprite = _jackets[PlayerPrefs.GetInt("SelectedJacket")]
			: _playerSprites[1].sprite = _jackets[0];

		var s = PlayerPrefs.HasKey("SelectedShoe")
			? _playerSprites[2].sprite = _shoes[PlayerPrefs.GetInt("SelectedShoe")]
			: _playerSprites[2].sprite = _shoes[0];
	}
}