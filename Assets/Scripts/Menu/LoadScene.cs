using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

    public void LoadNumberScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
