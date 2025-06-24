using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaytestMenuManager : MonoBehaviour
{
    public void StartPlaytestV1()
    {
        SceneManager.LoadScene(1);
    }

    public void StartPlaytestV2()
    {
        SceneManager.LoadScene(2);
    }

    public void StartPlaytestV3()
    {
        SceneManager.LoadScene(3);
    }

    public void StartPlaytestV4()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGamePlaytest()
    {
        Application.Quit();
    }
}
