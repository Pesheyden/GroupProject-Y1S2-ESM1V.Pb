using System.Collections;
using UnityEngine;

public class SnowmanPowerup : MonoBehaviour
{
    public Transform SecondPlayerTransform;
    public GameObject SnowmanPrefab;
    public float DistanceFromPlayer = 2f;

    public PowerupController PowerupControllerInstance;

    public Vector3 DirectionVector = new Vector3(0, 0, 1);

    public string Parameter;

    private void Start()
    {
        if (SecondPlayerTransform == null || SnowmanPrefab == null)
        {
            Debug.LogWarning("Something isn't assigned in the inspector");
        }


    }

    public void SpawnSnowmanInFrontOfPlayer()
    {
        if (SecondPlayerTransform != null && SnowmanPrefab != null)
        {
            Vector3 spawnPosition = SecondPlayerTransform.position + SecondPlayerTransform.forward * DistanceFromPlayer;
            Instantiate(SnowmanPrefab, spawnPosition, Quaternion.identity);
            FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
        }
    }
}
