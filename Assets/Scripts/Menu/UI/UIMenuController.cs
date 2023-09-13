using System.Collections;
using Managers.UI.Interfaces;
using UI.Views;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#if UNITY_ANDROID
using GooglePlayGames;
#endif

public class UIMenuController : MonoBehaviour
{
	[Inject]
	private IUIManager uiManager;

	[SerializeField] private GameObject _settingsPanel, _settingsPanelChild, _shopPanel,
		_leadachevPanel, _leadachevPanelChild;

	private SoundManager _soundManager;

	void Start()
	{
		Application.targetFrameRate = 60;
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
#else
			Social.ShowLeaderboardUI();
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
#else
				if (success)
				{
					Social.ShowLeaderboardUI();
				}
#endif
			});
		}
	}

	public void LoginIn()
	{
		Social.localUser.Authenticate( _ => { });
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
		uiManager.Show<SettingsUIView>("Settings");
	}

#endregion

#region Close Panels

	public void CloseShop()
	{
		_shopPanel.SetActive(false);
	}

#endregion
}