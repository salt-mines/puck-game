using UnityEngine;
using UnityEngine.InputSystem.Plugins.PlayerInput;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;

    public void OnResume()
    {
        Debug.Log("Resume");

        Destroy(gameObject);
        gameManager.Resume();
    }

    public void OnQuit()
    {
        Debug.Log("Quit");
    }
}
