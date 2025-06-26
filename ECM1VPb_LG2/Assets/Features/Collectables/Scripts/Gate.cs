using UnityEngine;

public class Gate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController _playerInstance = other.GetComponent<PlayerController>();

        if (_playerInstance != null)
        {
            Debug.Log("AYO ADD MY FREAKIN SPEEDBOOST MAN");
        }
        else
        {
            Debug.LogWarning("No PlayerTest component found on colliding object.");
        }
    }
}
