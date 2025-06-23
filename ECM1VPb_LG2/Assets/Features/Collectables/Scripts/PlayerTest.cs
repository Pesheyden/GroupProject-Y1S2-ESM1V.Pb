using System.Collections;
using System.Collections.Generic;
using BSOAP.Variables;
using UnityEngine;

public enum Side {left, right}

public class PlayerTest : MonoBehaviour
{

    [Header("Properties")][Space(10)]
    public float BaseSpeed = 10f;
    public float Speed = 10f;
    public float SpeedMultiplier = 1.5f;
    public float _speedBoostDelay = 2f;

    [Header("Coins")][Space(10)]
    public IntVariable Coins;

    private void Start()
    {
        Speed = BaseSpeed; 
    }

    void Purchase()
    {
        int PowerUpPrice = 10;
        Coins.Value -= PowerUpPrice;
    }

    public void GateSpeedBoost()
    {
        StartCoroutine(GateSpeedBoostCoroutine());
    }

    private IEnumerator GateSpeedBoostCoroutine()
    {
        Speed *= SpeedMultiplier;
        Debug.Log("Speed after gate " + Speed);
        yield return new WaitForSeconds(_speedBoostDelay);
        Speed = BaseSpeed;
        Debug.Log("Speed after delay " + Speed);
    }
}
