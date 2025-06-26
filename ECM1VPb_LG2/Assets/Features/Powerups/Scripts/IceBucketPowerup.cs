using System;
using UnityEngine;

public class IceBucketPowerup : MonoBehaviour
{
    public Transform SecondPlayerTransform;
    public GameObject PlanePrefab;
    public float DistanceFromPlayer = 3f;
    public string Parameter;
    
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

    public void SpawnIceBucketPlaneInFrontOfPlayer()
    {
        if (SecondPlayerTransform != null && PlanePrefab != null)
        {
            Vector3 spawnPosition = SecondPlayerTransform.position + DirectionVector * DistanceFromPlayer;
            Instantiate(PlanePrefab, spawnPosition, Quaternion.identity);
            if (Parameter != "")
                FMODUnity.RuntimeManager.CreateInstance(Parameter).start();
        }
    }
}
