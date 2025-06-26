using System;
using UnityEditor;
using UnityEngine;

public class IceBucketPowerupController : MonoBehaviour
{
    public float TorqueSpeed = 5f;
    public float LifeTime = 5f;

    private void OnEnable()
    {
        Invoke(nameof(Destroy), LifeTime);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        Rigidbody otherRigidbody = other.attachedRigidbody;


        if (otherRigidbody != null)
        {
            Debug.Log(2);
            // Apply torque or call any method on the Rigidbody
            otherRigidbody.AddTorque(transform.up * TorqueSpeed);
        }
    }
}