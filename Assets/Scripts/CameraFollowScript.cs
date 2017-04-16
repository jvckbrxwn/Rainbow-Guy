using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CameraFollowScript : MonoBehaviour {

    [SerializeField] private Transform _player;
    [SerializeField] private Text _text;
    private int _highscore, _score;

    // Use this for initialization
    void Start() {
        _highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    // Update is called once per frame
    void Update() {
        if (_player.position.y > 0) {
            if (_player.position.y > transform.position.y) {
                this.transform.position = new Vector3(0, _player.position.y, -1);
                _score = Convert.ToInt32(Mathf.Round(_player.position.y * 5f));
                _text.text = "Score: " + _score.ToString();
                if (_highscore <= _score)
                {
                    _highscore = _score;
                    PlayerPrefs.SetInt("Highscore", _highscore);
                }
            }
        }
    }

    public int Highscore
    {
        get { return _highscore; }
    }

    public void SetScoreToGooglePlay()
    {
        if (Social.localUser.authenticated)
            Social.ReportScore(Highscore, rainbowGuyResources.leaderboard_scores, (bool success) =>
                {

                });
    }
}
