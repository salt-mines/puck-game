using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Plugins.PlayerInput;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public EventSystem eventSystem;
    public GameObject pauseMenuPrefab;
    public GameObject startMenuPrefab;

    public Material bluePlayerMaterial;
    public Material redPlayerMaterial;
    public Material blueMowerMaterial;
    public Material redMowerMaterial;

    public int goalToWin = 10;

    private List<GameObject> spawns = new List<GameObject>();
    private int nextSpawn = 0;

    private Dictionary<PlayerColors, int> points = new Dictionary<PlayerColors, int>();

    private bool gameStarted = false;
    private bool isGameOver = false;
    private bool paused = false;

    public TextMeshProUGUI bluePointsText;
    public TextMeshProUGUI redPointsText;
    private GameObject startMenu;

    void Start()
    {
        foreach (var go in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            spawns.Add(go);
        }

        if (spawns.Count == 0)
        {
            Debug.LogError("No spawn points created");
        }

        points[PlayerColors.Red] = 0;
        points[PlayerColors.Blue] = 0;

        ShowStartMenu();
    }

    void Update()
    {
        GameOverCheck();
    }

    void GameOverCheck()
    {
        if (goalToWin <= points[PlayerColors.Red] || goalToWin <= points[PlayerColors.Blue])
        {
            isGameOver = true;
            ShowPauseMenu();
        }
        else
        {
            isGameOver = false;
        }
    }

    internal void BeginGame()
    {
        if (gameStarted) return;

        gameStarted = true;
        GetComponent<PlayerInputManager>().DisableJoining();
        Resume();

        if (startMenu)
        {
            Destroy(startMenu);
        }
    }

    internal void ShowStartMenu()
    {
        Pause();

        startMenu = Instantiate(startMenuPrefab, canvas.gameObject.transform);
    }

    internal void ShowPauseMenu()
    {
        if (paused) return;

        Pause();

        GameObject menu = Instantiate(pauseMenuPrefab, canvas.gameObject.transform);
        menu.GetComponent<PauseMenu>().gameManager = this;
        eventSystem.SetSelectedGameObject(menu.transform.GetChild(0).gameObject);
    }

    internal void Pause()
    {
        if (paused) return;

        paused = true;

        Time.timeScale = 0;
    }

    internal void Resume()
    {
        if (!paused) return;

        paused = false;

        Time.timeScale = 1;
    }

    internal void ChangeMowerColor(GameObject mower, PlayerColors color)
    {
        switch(color)
        {
            case PlayerColors.Blue:
                mower.GetComponentInChildren<MeshRenderer>().material = blueMowerMaterial;
                break;
            case PlayerColors.Red:
                mower.GetComponentInChildren<MeshRenderer>().material = redMowerMaterial;
                break;
        }
    }

    public void OnCollected(GameObject player)
    {
        points[player.GetComponent<Player>().playerTeamColor]+=1;
        bluePointsText.text = points[PlayerColors.Blue].ToString();
        redPointsText.text = points[PlayerColors.Red].ToString();
    }

    void OnPlayerJoined(PlayerInput pl)
    {
        GameObject spawn = spawns[nextSpawn++];
        if (nextSpawn >= spawns.Count)
        {
            nextSpawn = 0;
        }

        pl.gameObject.transform.SetPositionAndRotation(spawn.transform.position, spawn.transform.rotation);
        pl.GetComponent<Player>().gameManager = this;

        PlayerColors col = spawn.GetComponent<PlayerSpawn>().playerColor;
        pl.GetComponent<Player>().playerTeamColor = col;
        pl.gameObject.name = "Player " + pl.playerIndex + " (" + col + ")";

        switch(col)
        {
            case PlayerColors.Blue:
                pl.GetComponentInChildren<SkinnedMeshRenderer>().material = bluePlayerMaterial;
                break;
            case PlayerColors.Red:
                pl.GetComponentInChildren<SkinnedMeshRenderer>().material = redPlayerMaterial;
                break;
        }
    }

    public enum PlayerColors
    {
        Blue,
        Red,
    }
}
