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
        On_TriggerEnter?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        On_TriggerEnter?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        On_TriggerEnter?.Invoke(other);
    }
}
