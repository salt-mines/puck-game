using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NewGameMenu : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    internal void SetWinner(GameManager.PlayerColors winnerColor)
    {
        Color clr = Color.white;
        switch(winnerColor)
        {
            case GameManager.PlayerColors.Blue:
                clr = Color.blue;
                break;
            case GameManager.PlayerColors.Red:
                clr = Color.red;
                break;
        }

        winnerText.color = clr;
        winnerText.text = winnerColor + " won!";
    }

    public void OnNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
