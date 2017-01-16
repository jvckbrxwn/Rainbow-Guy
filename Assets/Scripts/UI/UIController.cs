using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	[SerializeField] private Button _pauseButton;
	[SerializeField] private GameObject _pausePanel, _gameOverPanel;
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

	public void onPause()
	{
		hideUIonPause();
		_playerController.isAccelerationMove = false;
		Time.timeScale = 0.0000000000000000001f;
		_pausePanel.SetActive(true);
	}

	public void onGameOver()
	{
		hideUIonGameOver();
		_playerController.isAccelerationMove = false;
		Time.timeScale = 0.0000000000000000001f;
		_gameOverPanel.SetActive(true);
		_playerController.isAlive = false;
	}

	public void onContinue()
	{
		_playerController.isAccelerationMove = true;
		_pausePanel.SetActive(false);
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

	public void hideUIonPause()
	{
		_pauseButton.enabled = false;
	}

	public void hideUIonGameOver()
	{
		_pauseButton.enabled = false;
	}
}
