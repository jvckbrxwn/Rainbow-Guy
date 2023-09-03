using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNumberScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
