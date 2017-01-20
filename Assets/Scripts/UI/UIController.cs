using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	[SerializeField] private Button _pauseButton;
	[SerializeField] private GameObject _pausePanel, _gameOverPanel, _pauseChildrenPanel, _gameOverChildrenPanel;
	[SerializeField] private PlayerController _playerController;    

	void Start()
	{
		_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update()
	{
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

	public void onGameOver(bool deadBy)
	{
        hideUIonGameOver();
        Time.timeScale = 0.00000001f;
        _playerController.isAccelerationMove = false;
        _playerController.isAlive = false;
        _gameOverPanel.SetActive(true);
        AnimationGameOverOn(deadBy);
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
		SceneManager.LoadScene(scene);
		Time.timeScale = 1f;
	}

	public void onExit(int scene)
	{
		SceneManager.LoadScene(scene);
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
    void AnimationGameOverOn(bool deadByEnemy)
    {
        _gameOverPanel.GetComponent<CanvasRenderer>().SetAlpha(0.01f);
        _gameOverPanel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
        if (deadByEnemy)
            DieByEnemy();
        else
            DieByFall();
    }

    void DieByEnemy()
    {
        LeanTween.move(_gameOverChildrenPanel, new Vector2(0, _playerController.gameObject.transform.position.y), .5f).setEase(LeanTweenType.easeInOutSine).setIgnoreTimeScale(true);
    }

    void DieByFall()
    {
        LeanTween.move(_gameOverChildrenPanel, new Vector2(0, _playerController.gameObject.transform.position.y + 6.5f), .5f).setEase(LeanTweenType.easeInOutSine).setIgnoreTimeScale(true);
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
        _gameOverPanel.GetComponent<CanvasRenderer>().SetAlpha(0.01f);
        _gameOverPanel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);

        LeanTween.move(_gameOverChildrenPanel, Vector2.down * 3f, .5f).setEase(LeanTweenType.easeInOutSine).setIgnoreTimeScale(true);
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
    #endregion
}
