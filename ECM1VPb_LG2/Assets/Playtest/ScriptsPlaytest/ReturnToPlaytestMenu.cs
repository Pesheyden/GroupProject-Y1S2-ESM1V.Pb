using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToPlaytestMenu : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        SceneManager.LoadScene(0);
    }
}
