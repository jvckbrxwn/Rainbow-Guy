using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_ANDROID
using GooglePlayGames;
#endif

public class UIMenuController : MonoBehaviour
{
	[SerializeField] private GameObject _settingsPanel, _settingsPanelChild, _shopPanel,
		_leadachevPanel, _leadachevPanelChild;

	private SoundManager _soundManager;

	void Start()
	{
		Init();
		LoginIn();
	}

	private void Init()
	{
#if UNITY_ANDROID
		PlayGamesPlatform.Activate();
#endif
		_soundManager = FindObjectOfType<SoundManager>();
		_soundManager.Init();
	}

#region GooglePlay

	public void OpenAchivements()
	{
		if (Social.localUser.authenticated)
		{
			Social.ShowAchievementsUI();
		}
		else
		{
			Social.localUser.Authenticate((bool success) =>
			{
				if (success)
				{
					Social.ShowAchievementsUI();
				}
			});
		}
	}

	public void OpenLeaderboard()
	{
		if (Social.localUser.authenticated)
		{
#if UNITY_ANDROID
			PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
#endif
		}
		else
		{
			Social.localUser.Authenticate((bool success) =>
			{
#if UNITY_ANDROID
				if (success)
				{
					PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
				}
#endif
			});
		}
	}

	public void LoginIn()
	{
		Social.localUser.Authenticate((bool success) =>
		{
			//Считать данные с облака, вмысле скор (хотя я подумал, и не знаю зачем сохранять данные на облако)
		});
	}

	public void LogOut()
	{
		Debug.Log("Log out");
	}

#endregion

#region Open Panels

	public void OpenShop()
	{
		_shopPanel.SetActive(true);
	}

	public void OpenSettings()
	{
		_settingsPanel.SetActive(true);
	}

	public void OpenLeadAcheve()
	{
		_leadachevPanel.SetActive(true);
	}

#endregion

#region Close Panels

	public void CloseShop()
	{
		_shopPanel.SetActive(false);
	}

	public void CloseLeadActive()
	{
		_leadachevPanel.SetActive(false);
	}

	public void CloseSettings()
	{
		_settingsPanel.SetActive(false);
	}

#endregion
}