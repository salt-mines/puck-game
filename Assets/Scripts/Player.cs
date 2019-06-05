using UnityEngine;
using UnityEngine.InputSystem.Plugins.PlayerInput;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    internal float throttle;
    internal float turn;

    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void OnThrottle(InputValue value)
    {
        throttle = value.Get<float>();
    }

    void OnTurn(InputValue value)
    {
        turn = value.Get<float>();
    }

    void OnPause(InputValue value)
    {
        Debug.Log("pause");

        gameManager.Pause();
    }
}
