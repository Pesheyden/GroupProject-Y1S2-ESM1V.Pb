using System;
using UnityEngine;

public class OuterPathTrigger : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(1);
        if (other.transform.parent.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.StartSlowdown(_speedMultiplier);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.StopSlowdown(_speedMultiplier);
        }
    }
}
