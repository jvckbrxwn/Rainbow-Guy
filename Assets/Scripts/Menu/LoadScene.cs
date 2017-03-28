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
            SendOneMoreNotitfication();
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                    .GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call<bool>("moveTaskToBack", true);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    private void SendOneMoreNotitfication()
    {
        NotificationManager.CancelAll();
        NotificationManager.SendWithAppIcon(TimeSpan.FromHours(8), "DUD3", "Come back, ya piece of sh1t!",
            new Color(0, 0.6f, 1), NotificationIcon.Message);
        //SendOneMoreNotitfication();
    }

    public void LoadNumberScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
