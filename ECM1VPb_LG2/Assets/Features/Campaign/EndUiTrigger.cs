using System;
using UnityEngine;

public class EndUiTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _bottomUI;
    [SerializeField] private GameObject _upUI;
    public void TriggerEnd(Collider collider)
    {
        if (!collider.transform.parent.TryGetComponent<PlayerController>(out var playerController)) return;
        
        switch (playerController.Side)
        {
            case PlayerSide.Bottom:
                _bottomUI.SetActive(true);
                break;
            case PlayerSide.Up:
                _upUI.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
            
        foreach (var player in GameObject.FindGameObjectsWithTag("Player"))
        {
            player.SetActive(false);
        }
    }
}
