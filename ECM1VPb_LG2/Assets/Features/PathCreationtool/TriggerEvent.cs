using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent<Collider> On_TriggerEnter;
    public UnityEvent<Collider> On_TriggerStay;
    public UnityEvent<Collider> On_TriggerExit;
    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerStay(Collider other)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerExit(Collider other)
    {
        throw new NotImplementedException();
    }
}
