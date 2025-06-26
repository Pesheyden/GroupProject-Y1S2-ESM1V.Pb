using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string Parameter;

    private void OnTriggerEnter(Collider other)
    {
        if(Parameter != "")
            FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
        other.transform.parent.GetComponent<PlayerController>().Coins.Value++;
    }
}