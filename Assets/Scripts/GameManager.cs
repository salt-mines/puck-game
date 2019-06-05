﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Plugins.PlayerInput;
using UnityEngine.InputSystem.Plugins.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public EventSystem eventSystem;
    public GameObject pauseMenu;

    public int goalToWin = 10;

    private List<GameObject> spawns = new List<GameObject>();
    private int nextSpawn = 0;

    private Dictionary<PlayerColors, int> points = new Dictionary<PlayerColors, int>();

    private bool isGameOver = false;
    private bool paused = false;

    public TextMeshProUGUI bluePointsText;
    public TextMeshProUGUI redPointsText;

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
    }
    
    void Update()
    {
        GameOverCheck();
    }
    
    void GameOverCheck()
    {
        if(goalToWin<=points[PlayerColors.Red] || goalToWin <= points[PlayerColors.Blue])
        {
            isGameOver = true;
            Pause();
        }
        else
        {
            isGameOver = false;
        }
    }

    internal void Pause()
    {
        if (paused) return;

        paused = true;

        GameObject menu = Instantiate(pauseMenu, canvas.gameObject.transform);
        menu.GetComponent<PauseMenu>().gameManager = this;
        eventSystem.SetSelectedGameObject(menu.transform.GetChild(0).gameObject);

        Time.timeScale = 0;
    }

    internal void Resume()
    {
        if (!paused) return;

        paused = false;

        Time.timeScale = 1;
    }

    public void OnCollected(GameObject player)
    {
        points[player.GetComponent<Player>().playerTeamColor]+=1;
        bluePointsText.text = points[PlayerColors.Blue].ToString();
        redPointsText.text = points[PlayerColors.Red].ToString();
        Debug.Log("collected");
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

        if (paused)
        {
            pl.SwitchCurrentActionMap("UI");
        }

        PlayerColors col = spawn.GetComponent<PlayerSpawn>().playerColor;
        pl.GetComponent<Player>().playerTeamColor = col;
        pl.gameObject.name = "Player " + pl.playerIndex + " (" + col + ")";
    }

    public enum PlayerColors
    {
        Blue,
        Red,
    }
}
