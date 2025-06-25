using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaytestMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private GameObject horizontalModeMenu;

    [SerializeField] private GameObject verticalModeMenu;

    private void Start()
    {
        mainMenu.SetActive(true);
        horizontalModeMenu.SetActive(false);
        verticalModeMenu.SetActive(false);
    }

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

    public void StartPlaytestH1()
    {
        SceneManager.LoadScene(4);
    }

    public void StartPlaytestH2()
    {
        SceneManager.LoadScene(5);
    }

    public void StartPlaytestH3()
    {
        SceneManager.LoadScene(6);
    }

    public void HorizontalModePlaytest()
    {
        mainMenu.SetActive(false);
        horizontalModeMenu.SetActive(true);
        verticalModeMenu.SetActive(false);
    }

    public void VerticalModePlaytest()
    {
        mainMenu.SetActive(false);
        horizontalModeMenu.SetActive(false);
        verticalModeMenu.SetActive(true);
    }

    public void BackButtonPlaytest()
    {
        mainMenu.SetActive(true);
        horizontalModeMenu.SetActive(false);
        verticalModeMenu.SetActive(false);
    }

    public void ExitGamePlaytest()
    {
        Application.Quit();
    }
}
