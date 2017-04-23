using UnityEngine;
using UnityEngine.UI;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class CameraFollowScript : MonoBehaviour {

    [SerializeField] private Transform _player;
    [SerializeField] private Text _text;
    private int _highscore, _score;

    // Use this for initialization
    void Start() {
        Highscore = PlayerPrefs.GetInt("Highscore", GetScoreFromGooglePlay());
    }

    // Update is called once per frame
    void Update() {
        if (_player.position.y > 0) {
            if (_player.position.y > transform.position.y) {
                this.transform.position = new Vector3(0, _player.position.y, -1);
                _score = Convert.ToInt32(Mathf.Round(_player.position.y * 5f));
                _text.text = "Score: " + _score.ToString();
                if (Highscore <= _score)
                {
                    Highscore = _score;
                }
            }
        }
    }

    public int Highscore
    {
        get { return _highscore; }
        set { _highscore = value; }
    }

    public void SetScoreToGooglePlay()
    {
        PlayerPrefs.SetInt("Highscore", Highscore);
        PlayerPrefs.Save();
        if (Social.localUser.authenticated)
            Social.ReportScore(Highscore, rainbowGuyResources.leaderboard_scores, (bool success) =>
                {
                    
                });
    }

    private int GetScoreFromGooglePlay()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.LoadScores(
             rainbowGuyResources.leaderboard_scores,
             LeaderboardStart.PlayerCentered,
             1,
             LeaderboardCollection.Public,
             LeaderboardTimeSpan.AllTime,
         (LeaderboardScoreData data) =>
         {
            Highscore = Convert.ToInt32(data.PlayerScore.formattedValue);
         });
        }
        Debug.Log(Highscore);
        return Highscore;
    }
}
