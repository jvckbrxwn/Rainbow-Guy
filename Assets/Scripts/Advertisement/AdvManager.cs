using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvManager : MonoBehaviour
{

    [SerializeField] private PlayerController _playerControl;

    void Start()
    {
        _playerControl = FindObjectOfType<PlayerController>();
    }

    public void ShowAd()
    {
        //ShowOptions options = new ShowOptions();
        //options.resultCallback = HandleShowResult;
        //Advertisement.Show(options);
    }

    // private void HandleShowResult(ShowResult result)
    // {
    //     // switch (result)
    //     // {
    //     //     case ShowResult.Finished:
    //     //         Debug.Log("Video completed. Game continue");
    //     //         _playerControl.StayAlive();
    //     //         break;
    //     //     case ShowResult.Skipped:
    //     //         Debug.LogWarning("Video was skipped.");
    //     //         break;
    //     //     case ShowResult.Failed:
    //     //         Debug.LogError("Video failed to show.");
    //     //         break;
    //     // }
    // }
}
