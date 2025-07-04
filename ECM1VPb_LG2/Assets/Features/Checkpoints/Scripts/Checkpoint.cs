using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.TryGetComponent<PlayerStopwatch>(out var playerStopWatch))
            playerStopWatch.UpdateStopwatch();
    }
}
