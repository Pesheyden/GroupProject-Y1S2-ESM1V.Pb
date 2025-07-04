using System.Collections;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public float BaseSpeed;
    public float SpeedMultiplier;


    public void ActivateSpeedPowerup()
    {
        //StartCoroutine(SpeedPowerupCoroutine());
    }

    //private IEnumerator SpeedPowerupCoroutine()
    //{
    //    _playerMovement.SpeedUp(SpeedMultiplier);
    //    // wait for seconds
    //    // _rigidbody.linearVelocity /= multiplier;
    //}


}
