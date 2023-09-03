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
        
    }
}
