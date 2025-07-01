using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string Parameter;
    [SerializeField] private ParticleSystem _particles;

    private void OnTriggerEnter(Collider other)
    {
        if(Parameter != "")
            FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
        
        if(_particles)
            _particles.Play();
        
        other.transform.parent.GetComponent<PlayerController>().Coins.Value++;
    }
}