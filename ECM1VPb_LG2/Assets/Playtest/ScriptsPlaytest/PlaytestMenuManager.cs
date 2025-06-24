using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaytestMenuManager : MonoBehaviour
{
    public void StartPlaytest()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGamePlaytest()
    {
        Application.Quit();
    }


}
