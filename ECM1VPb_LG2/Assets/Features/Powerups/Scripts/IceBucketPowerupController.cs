using UnityEngine;

public class IceBucketPowerupController : MonoBehaviour
{
    public float TorqueSpeed = 5f;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRigidbody = other.attachedRigidbody;

        if (otherRigidbody != null)
        {
            // Apply torque or call any method on the Rigidbody
            otherRigidbody.AddTorque(transform.up * TorqueSpeed);
        }
    }
}