using UnityEngine;

public class Gate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerTest _playerInstance = other.GetComponent<PlayerTest>();

        if (_playerInstance != null)
        {
            _playerInstance.GateSpeedBoost();
            Debug.Log("AYO ADD MY FREAKIN SPEEDBOOST MAN");
        }
        else
        {
            Debug.LogWarning("No PlayerTest component found on colliding object.");
        }
    }
}
