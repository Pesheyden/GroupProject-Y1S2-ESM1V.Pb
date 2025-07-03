using Unity.VisualScripting;
using UnityEngine;

public class CoinCheckerTutorial : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    [SerializeField] private GameObject coinCheckerCollider;

    [SerializeField] private Transform respawnLocation;

    [SerializeField] private GameObject player1;

    [SerializeField] private GameObject sabotage1Menu;

    [SerializeField] private TutorialManager tutorialManager;

    [SerializeField] private GameObject finger;

    public bool firstCoinCollected = false;

    private void Start()
    {
        firstCoinCollected = false;
    }

    private void OnTriggerEnter()
    {
        if (firstCoinCollected == true)
        {
            coinCheckerCollider.SetActive(false);
        }
        else
        {
            player1.transform.position = respawnLocation.position;
        }
    }

    private void Update()
    {
        if(firstCoinCollected == false)
        {
            if (playerController.Coins.Value == 1)
            {
                sabotage1Menu.SetActive(true);

                finger.SetActive(true);

                tutorialManager.TimeStop();

                firstCoinCollected = true;
            }
        }
    }
}
