using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadSceneWithIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void StartRandomScene(Vector2Int range)
    {
        SceneManager.LoadScene(Random.Range(range.x, range.y));
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
