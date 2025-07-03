using Unity.VisualScripting;
using UnityEngine;

public class SabotageTutorialCompleted : MonoBehaviour
{
    [SerializeField] private GameObject pointer;

    [SerializeField] private Transform teleportLocation;

    [SerializeField] private Transform teleportLocationp2;

    [SerializeField] private GameObject nextSabotageTutorial;

    [SerializeField] private GameObject player1;

    [SerializeField] private GameObject player2;

    [SerializeField] private TutorialManager tutorialManager;

    [SerializeField] private PlayerController playerController;

    [SerializeField] private GameObject sabotageChecker;

    private bool sabotage1Completed = false;

    private void Start()
    {
        sabotage1Completed = false;
    }

    private void OnTriggerEnter()
    {
        if (pointer.activeSelf)
        {
            player1.transform.position = teleportLocation.position;
            player2.transform.position = teleportLocationp2.position;
        }
        if (!pointer.activeSelf)
        {
            nextSabotageTutorial.SetActive(true);

            tutorialManager.TimeStop();

            playerController.Coins.Value = 0;

            sabotageChecker.SetActive(false);
        }
    }
}
