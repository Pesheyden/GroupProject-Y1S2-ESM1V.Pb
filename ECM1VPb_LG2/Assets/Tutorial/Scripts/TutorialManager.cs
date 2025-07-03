using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private Rigidbody player1;

    [SerializeField] private Rigidbody player2;

    private void Start()
    {
        DisableMovementPlayer1();
        DisableMovementPlayer2();
    }

    public void DisableMovementPlayer1()
    {
        player1.isKinematic = true;
    }

    public void DisableMovementPlayer2()
    {
        player2.isKinematic = true;
    }

    public void EnableMovementPlayer1()
    {
        player1.isKinematic = false;
    }

    public void EnableMovementPlayer2()
    {
        player2.isKinematic = false;
    }

    public void TimeStop()
    {
        Time.timeScale = 0;
    }

    public void TimeResume()
    {
        Time.timeScale = 1;
    }
}
