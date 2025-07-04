using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string Parameter;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private Animation _animation;
    [SerializeField] private float _respawnTime;

    private void OnTriggerEnter(Collider other)
    {
        if(Parameter != "")
            FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
        
        if(_particles)
            _particles.Play();
        
        if (_animation)
            _animation.Play();
        
        other.transform.parent.GetComponent<PlayerController>().Coins.Value++;
        GetComponent<Collider>().enabled = false;
        GetComponent<Animation>().enabled = false;
        Invoke(nameof(Respawn), _respawnTime);
    }

    private void Respawn()
    {
        GetComponent<Collider>().enabled = true;
        GetComponent<Animation>().enabled = true;
    }
}