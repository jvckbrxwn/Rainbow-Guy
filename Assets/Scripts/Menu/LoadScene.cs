using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.SimpleAndroidNotifications;
using System;

public class LoadScene : MonoBehaviour
{

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            NotificationManager.SendWithAppIcon(TimeSpan.FromHours(8), "DUD3", "Come back!", new Color(0, 0.6f, 1), NotificationIcon.Message);
            Application.Quit();
        }
    }

    public void LoadNumberScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
