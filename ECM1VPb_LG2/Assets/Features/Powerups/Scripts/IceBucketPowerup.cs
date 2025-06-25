using UnityEngine;

public class IceBucketPowerup : MonoBehaviour
{
    public Transform SecondPlayerTransform;
    public GameObject PlanePrefab;
    public float DistanceFromPlayer = 3f;

    public void SpawnIceBucketPlaneInFrontOfPlayer()
    {
        if (SecondPlayerTransform != null && PlanePrefab != null)
        {
            Vector3 spawnPosition = SecondPlayerTransform.position + SecondPlayerTransform.forward * DistanceFromPlayer;
            Instantiate(PlanePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
