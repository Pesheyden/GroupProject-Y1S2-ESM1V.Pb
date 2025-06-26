using System.Collections;
using System.Collections.Generic;
using BSOAP.Variables;
using FMODUnity;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class Collectable : MonoBehaviour
{
    
    public GameObject CollectableGameObject;
    public string Parameter;

    private void OnTriggerEnter(Collider other)
    {
        FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
        other.transform.parent.GetComponent<PlayerController>().Coins.Value++;
    }
}