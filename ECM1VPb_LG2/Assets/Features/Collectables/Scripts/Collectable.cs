using System.Collections;
using System.Collections.Generic;
using BSOAP.Variables;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent.GetComponent<PlayerController>().Coins.Value++;
    }
}

/* using UnityEngine;
using BSOAP.Variables;
public class PowerupController : MonoBehaviour
{
    public IntVariable LeftCoins;
    public IntVariable RightCoins;

    int PowerupPrice = 10;

    private void Start()
    {
        if (LeftCoins == null || RightCoins == null)
        {
            Debug.LogError("One or both IntVariables are not assigned!");
        }
        else
        {
            Debug.Log("LeftCoins: " + LeftCoins.Value);
            Debug.Log("RightCoins: " + RightCoins.Value);
        }
    }
    public void TryActivate(Side side)
    {
        Debug.Log($"Trying to activate powerup on {side} side");

        switch (side)
        {
            case Side.left:
                if (LeftCoins.Value >= PowerupPrice)
                {
                    LeftCoins.Value -= PowerupPrice;
                    ActivatePowerup();
                }
                break;
            case Side.right:
                if (RightCoins.Value >= PowerupPrice)
                {
                    RightCoins.Value -= PowerupPrice;
                    ActivatePowerup();
                }
                break;
        }
    }

    public void ActivatePowerup()
    {
        if (LeftCoins == null || RightCoins == null)
        {
            Debug.LogError("PowerupController: One of the coin references is null during activation!");
            return;
        }

        Debug.Log("Powerup active");
        Debug.Log("Updated left side coins : " + LeftCoins.Value);
        Debug.Log("Updated right side coins : " + RightCoins.Value);
    }
} */