using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _stopTime;
    [SerializeField] private ParticleSystem _particles;
    public string Parameter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            if (Parameter != "")
                FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
            
            if(_particles)
                _particles.Play();
            playerMovement.Stop(_stopTime);
        }
    }
}
