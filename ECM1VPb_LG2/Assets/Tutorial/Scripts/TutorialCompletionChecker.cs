using UnityEditor;
using UnityEngine;

public class TutorialCompletionChecker : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;

    [SerializeField] private GameObject[] objectsToEnable;

    [SerializeField] private bool timeStop;

    private void OnTriggerExit(Collider other)
    {
        tutorialManager.TimeStop();

        foreach (var obj in objectsToEnable)
        {
            obj.SetActive(true);
        }

        if (timeStop == true)
        {
            tutorialManager.TimeStop();
        }
    }
}
