using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _stopTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.Stop(_stopTime);
        }
    }
}
