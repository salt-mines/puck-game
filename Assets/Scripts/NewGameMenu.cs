using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameMenu : MonoBehaviour
{ 
    public void OnNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
