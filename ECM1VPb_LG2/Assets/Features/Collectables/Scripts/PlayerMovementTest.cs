using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    PlayerTest _playerInstance;
    public CharacterController controller;

    [Header("Player")][Space(10)]

    public float gravity = -18.81f;
    Vector3 velocity;

    [Header("Ground")][Space(10)]

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        MovePlayer();
    }

    public void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * _playerInstance.Speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
