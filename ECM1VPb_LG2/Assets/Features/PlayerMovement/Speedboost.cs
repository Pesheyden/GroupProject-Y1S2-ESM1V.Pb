using System;
using UnityEngine;

public class Speedboost : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.SpeedUp(_multiplier);
        }
    }
}
