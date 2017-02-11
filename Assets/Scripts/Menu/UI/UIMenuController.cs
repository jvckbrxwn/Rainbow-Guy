using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SimpleAndroidNotifications;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuController : MonoBehaviour {

    [SerializeField] private GameObject _settingsPanel, _settingsPanelChild, _shopPanel;
    private SoundManager _soundManager;

    // Use this for initialization
    void Start() {
        Init();
    }

    private void Init()
    {
        _soundManager = FindObjectOfType<SoundManager>();
        _soundManager.Init();
    }

    // Update is called once per frame
    void Update() {

    }

    #region Open
    public void OpenShop()
    {
        _shopPanel.SetActive(true);
    }

    public void OpenAchivements()
    {

    }

    public void OpenLeaderboard()
    {

    }

    public void OpenSettings()
    {
        _settingsPanel.SetActive(true);
        AnimationObjectOn(_settingsPanel, _settingsPanelChild);
    }
    #endregion

    #region Close
    public void CloseShop()
    {
        _shopPanel.SetActive(false);
    }

    public void CloseAchivements()
    {

    }

    public void CloseLeaderboard()
    {

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
