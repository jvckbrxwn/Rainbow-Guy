using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#endif

public class CameraFollowScript : MonoBehaviour
{
	[SerializeField] private Transform _player;
	[SerializeField] private Text _text;
	private int _highscore, _score;

	// Use this for initialization
	void Start()
	{
		//TODO: get value from Social
		Highscore = PlayerPrefs.GetInt("Highscore", 0);
	}

	// Update is called once per frame
	void Update()
	{
		// if (_player.position.y > 0)
		// {
		// 	if (_player.position.y > transform.position.y)
		// 	{
		// 		this.transform.position = new Vector3(0, _player.position.y, -1);
		// 		_score = Convert.ToInt32(Mathf.Round(_player.position.y * 5f));
		// 		_text.text = "Score: " + _score.ToString();
		// 		if (Highscore <= _score)
		// 		{
		// 			Highscore = _score;
		// 		}
		// 	}
		// }
	}

	public int Highscore { get { return _highscore; } set { _highscore = value; } }

#if UNITY_ANDROID
	public void SetScoreToGooglePlay()
	{
		PlayerPrefs.SetInt("Highscore", Highscore);
		PlayerPrefs.Save();
		if (Social.localUser.authenticated)
			Social.ReportScore(Highscore, GPGSIds.leaderboard_high_score, (bool success) => { });
	}

	private int GetScoreFromGooglePlay()
	{
		if (Social.localUser.authenticated)
		{
			PlayGamesPlatform.Instance.LoadScores(GPGSIds.leaderboard_high_score,
				LeaderboardStart.PlayerCentered,
				1,
				LeaderboardCollection.Public,
				LeaderboardTimeSpan.AllTime,
				(LeaderboardScoreData data) => { Highscore = Convert.ToInt32(data.PlayerScore.formattedValue); });
		}

		Debug.Log(Highscore);
		return Highscore;
	}
#endif
}