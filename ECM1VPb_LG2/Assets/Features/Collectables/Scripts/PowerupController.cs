using UnityEngine;
using BSOAP.Variables;

public enum Side
{
    left,
    right
}
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

    public void ActivatePowerup()
    {
        if (LeftCoins == null || RightCoins == null)
        {
            Debug.LogError("PowerupController: One of the coin references is null during activation!");
            return;
        }

        Debug.Log("Powerup active");
     
        Debug.Log("Updated right side coins : " + RightCoins.Value);
    }

    public void TryActivate(Side side)
    {
        if (LeftCoins == null || RightCoins == null)
        {
            Debug.LogError("PowerupController: One of the coin references is null during activation!");
            return;
        }

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

    public void ActivateLeftPowerup()
    {
        TryActivate(Side.left);
        Debug.Log("Powerup active, updated left side coins : " + RightCoins.Value);
    }

    public void ActivateRightPowerup()
    {
        TryActivate(Side.right);
        Debug.Log("Powerup active, updated right side coins : " + RightCoins.Value);
    }

}