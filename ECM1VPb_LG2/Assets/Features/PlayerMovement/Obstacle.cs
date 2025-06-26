using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _stopTime;
    public string Parameter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
            playerMovement.Stop(_stopTime);
        }
    }
}
