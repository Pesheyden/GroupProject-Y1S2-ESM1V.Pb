using BSOAP.Variables;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FloatVariable _moveInput;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _moveInput.Value = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _moveInput.Value = 1f;
        }
        else
        {
            _moveInput.Value = 0;
        }
    }
}
