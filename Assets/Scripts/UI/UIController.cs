using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	[SerializeField] private Button _pauseButton;
	[SerializeField] private GameObject _pausePanel, _gameOverPanel, _pauseChildrenPanel, _gameOverChildrenPanel;
	[SerializeField] private PlayerController _playerController;
    [SerializeField] private Text _highscore;
    private CameraFollowScript _cameraFollowScript;

    void Start()
    {
        Time.timeScale = 1f;
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _cameraFollowScript = FindObjectOfType<CameraFollowScript>();
    }

	void Update() {
		if(_pausePanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
			onContinue();
		else if(_gameOverPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene(0);
		else if(Input.GetKeyDown(KeyCode.Escape))
			onPause();
	}

    #region OnUI
    public void onPause()
	{
		hidePause();
		_playerController.isAccelerationMove = false;
		Time.timeScale = 0.0000000000000000001f;
		_pausePanel.SetActive(true);
        AnimationPausePanelOn();
    }

	public void onGameOver()
	{
        hideUIonGameOver();
        Time.timeScale = 0.00000001f;
        _playerController.isAccelerationMove = false;
        _playerController.isAlive = false;
        _gameOverPanel.SetActive(true);
        _highscore.text = "Your highscore: " + _cameraFollowScript.Highscore;
        _cameraFollowScript.SetScoreToGooglePlay();
        AnimationGameOverOn();
    }

	public void onContinue()
	{
        enablePause();
        _playerController.isAccelerationMove = true;
        AnimationPausePanelOut();
        Time.timeScale = 1f;
	}

	public void onReplay(int scene)
	{
        AnimationGameOverOut();
		StartCoroutine(WaitToScene(scene, .5f));
    }

	public void onExit(int scene)
	{
		SceneManager.LoadScene(scene);
		Time.timeScale = 1f;
	}

    public void OnStayAlive()
    {
        enablePause();
        _playerController.isAccelerationMove = true;
        AnimationGameOverOut();
        StartCoroutine(StayAlive());
        Time.timeScale = 1f;
    }

	public void hidePause()
	{
		_pauseButton.enabled = false;
	}

    public void enablePause()
    {
        _pauseButton.enabled = true;
    }

    void hideUIonGameOver()
	{
		_pauseButton.enabled = false;
	}
    #endregion

    #region Animations
    void AnimationGameOverOn()
    {
        _gameOverPanel.GetComponent<CanvasRenderer>().SetAlpha(0.01f);
        _gameOverPanel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);

        LeanTween.move(_gameOverChildrenPanel, new Vector2(0, _gameOverPanel.transform.position.y), .5f).setEase(LeanTweenType.easeInOutSine).setIgnoreTimeScale(true);
    }

    void AnimationPausePanelOn()
    {
        _pausePanel.GetComponent<CanvasRenderer>().SetAlpha(0.01f);
        _pausePanel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
        _pauseChildrenPanel.transform.position = new Vector2(0, _pausePanel.transform.position.y + 10f);
        LeanTween.move(_pauseChildrenPanel, new Vector2(0, _pausePanel.transform.position.y), .5f).setEase(LeanTweenType.easeInOutSine).setIgnoreTimeScale(true);
    }

    void AnimationGameOverOut()
    {
        _gameOverPanel.GetComponent<Image>().CrossFadeAlpha(0f, 0.5f, true);
        LeanTween.move(_gameOverChildrenPanel, new Vector2(0, _gameOverPanel.transform.position.y + 20f), .5f).setEase(LeanTweenType.easeInOutSine).setIgnoreTimeScale(true);
    }

    void AnimationPausePanelOut()
    {
        _pausePanel.GetComponent<Image>().CrossFadeAlpha(0f, 0.5f, true);
        LeanTween.move(_pauseChildrenPanel, new Vector2(0, _pausePanel.transform.position.y - 10f), 0.5f).setEase(LeanTweenType.easeInOutSine).setIgnoreTimeScale(true);
        StartCoroutine(WaitASec());
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(.5f);
        _pausePanel.SetActive(false);
    }

    IEnumerator WaitToScene(int scene, float time)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    IEnumerator StayAlive()
    {
        yield return new WaitForSeconds(.5f);
        _gameOverPanel.SetActive(false);
    }
    #endregion
}
