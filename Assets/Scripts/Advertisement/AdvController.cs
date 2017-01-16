using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvController : MonoBehaviour
{
    public static AdvController instance;

    public string gameId = "1266328"; // Set this value from the inspector.
    public bool enableTestMode = true;
    [SerializeField] private PlayerController _playerControl;

    IEnumerator Start()
    {
        _playerControl = FindObjectOfType<PlayerController>();
        #if !UNITY_ADS // If the Ads service is not enabled...
        if (Advertisement.isSupported) { // If runtime platform is supported...
            Advertisement.Initialize(gameId, enableTestMode); // ...initialize.
        }
        #endif
        while (!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ShowAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show(options);

    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Video completed. Game continue");
                _playerControl.StayAlive();
                break;
            case ShowResult.Skipped:
                Debug.LogWarning("Video was skipped.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Video failed to show.");
                break;
        }
    }
}
