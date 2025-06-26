using System;
using UnityEngine;

public class Speedboost : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    public string Parameter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
            playerMovement.SpeedUp(_multiplier);
        }
    }
}
