using System;
using System.Collections;
using UnityEngine;

public class SnowmanPowerup : MonoBehaviour
{
    public Transform SecondPlayerTransform;
    public GameObject SnowmanPrefab;
    public float DistanceFromPlayer = 2f;
    [SerializeField] private Axis _forwardAxis;

    public Vector3 DirectionVector;

    private void Awake()
    {
        DirectionVector = _forwardAxis switch
        {
            Axis.x => new Vector3(1, 0, 0),
            Axis.y => new Vector3(0, 1, 0),
            Axis.z => new Vector3(0, 0, 1),
            Axis.rx => new Vector3(-1, 0, 0),
            Axis.ry => new Vector3(0, -1, 0),
            Axis.rz => new Vector3(0, 0, -1),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

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
            Vector3 spawnPosition = SecondPlayerTransform.position + DirectionVector * DistanceFromPlayer;
            Instantiate(SnowmanPrefab, spawnPosition, Quaternion.identity);
            if (Parameter != "")
                FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
        }
    }
}
