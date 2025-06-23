using System.Collections;
using UnityEngine;

public class SnowmanPowerup : MonoBehaviour
{
    public Transform SecondPlayerTransform;
    public GameObject SnowmanPrefab;
    public float DistanceFromPlayer = 2f;

    public PowerupController _powerupControllerInstance;



    private void Start()
    {
        if (SecondPlayerTransform == null || SnowmanPrefab == null)
        {
            Debug.LogWarning("Something isn't assigned in the inspector");
        }

        StartCoroutine(PowerupCoroutine());
    }

    private IEnumerator PowerupCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SpawnSnowmanInFrontOfPlayer();
    }

    private void SpawnSnowmanInFrontOfPlayer()
    {
        if (SecondPlayerTransform != null && SnowmanPrefab != null)
        {
            Vector3 spawnPosition = SecondPlayerTransform.position + SecondPlayerTransform.forward * DistanceFromPlayer;
            Instantiate(SnowmanPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
