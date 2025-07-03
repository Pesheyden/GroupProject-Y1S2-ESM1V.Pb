using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    [SerializeField] TutorialManager tutorialManager;

    private void OnTriggerEnter()
    {
        tutorialManager.DisableMovementPlayer2();
    }
}
