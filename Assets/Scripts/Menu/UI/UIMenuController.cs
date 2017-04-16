using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class UIMenuController : MonoBehaviour {

    [SerializeField] private GameObject _settingsPanel, _settingsPanelChild, _shopPanel, 
        _leadachevPanel, _leadachevPanelChild;
    private SoundManager _soundManager;

    void Start() {
        Init();
        LoginIn();
    }

    private void Init()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
	.EnableSavedGames()
	.Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = false;
        PlayGamesPlatform.Activate();
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
            Social.localUser.Authenticate((bool success) => {
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
            Social.ShowLeaderboardUI();
        }
        else
        {
            Social.localUser.Authenticate((bool success) => {
                if (success)
                {
                    Social.ShowLeaderboardUI();
                }
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

    public void LoginOut()
    {
        if (Social.localUser.authenticated)
            PlayGamesPlatform.Instance.SignOut();
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
        AnimationObjectOn(_settingsPanel, _settingsPanelChild);
    }

    public void OpenLeadAcheve()
    {
        _leadachevPanel.SetActive(true);
        AnimationObjectOn(_leadachevPanel, _leadachevPanelChild);
    }
    #endregion

    #region Close Panels
    public void CloseShop()
    {
        _shopPanel.SetActive(false);
    }

    public void CloseLeadAcive()
    {
        AnimationObjectOut(_leadachevPanel, _leadachevPanelChild);
    }

    public void CloseSettings()
    {
        AnimationObjectOut(_settingsPanel, _settingsPanelChild);
    }
    #endregion

    #region Animation
    void AnimationObjectOn(GameObject mainGO, GameObject panelGO)
    {
        mainGO.GetComponent<CanvasRenderer>().SetAlpha(0.01f);
        mainGO.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
        panelGO.transform.position = new Vector2(0, mainGO.transform.position.y - 10f);
        LeanTween.move(panelGO, new Vector2(0, mainGO.transform.position.y), .5f).setEase(LeanTweenType.easeInOutSine).setIgnoreTimeScale(true);
    }
    void AnimationObjectOut(GameObject mainGO, GameObject panelGO)
    {
        mainGO.GetComponent<Image>().CrossFadeAlpha(0f, 0.5f, true);
        LeanTween.move(panelGO, new Vector2(0, mainGO.transform.position.y + 10f), .5f).setEase(LeanTweenType.easeInOutSine).setIgnoreTimeScale(true);
        StartCoroutine(WaitASec(mainGO));
    }

    IEnumerator WaitASec(GameObject go)
    {
        yield return new WaitForSeconds(.5f);
        go.SetActive(false);
    }
    #endregion Animations
}
