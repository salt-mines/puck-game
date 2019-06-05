using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;

    public void OnResume()
    {
        Destroy(gameObject);
        gameManager.Resume();
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
