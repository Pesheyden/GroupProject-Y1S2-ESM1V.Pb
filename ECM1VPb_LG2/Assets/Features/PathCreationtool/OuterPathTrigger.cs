using System;
using UnityEngine;
using UnityEngine.Events;

public class OuterPathTrigger : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier;

    public UnityEvent OnRoughSnowEnter;
    public UnityEvent OnRoughSnowExit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            OnRoughSnowEnter?.Invoke();
            playerMovement.StartSlowdown(_speedMultiplier);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            OnRoughSnowExit?.Invoke();
            playerMovement.StopSlowdown(_speedMultiplier);
        }
    }
}
