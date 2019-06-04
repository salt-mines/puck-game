using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Plugins.PlayerInput;

public class GameManager : MonoBehaviour
{
    public int goalToWin = 10;

    internal int playerBlueWins;
    internal int playerRedWins;

    internal int playerBluePoints;
    internal int playerRedPoints;

    public GameObject playerBlue;
    public GameObject playerRed;

    private bool isGameOver = false;

    private List<GameObject> spawns = new List<GameObject>();
    private int nextSpawn = 0;
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
    }
    
    void Update()
    {
        if(playerBluePoints >= goalToWin || playerRedPoints >= goalToWin) {
            isGameOver = true;
        }  
    }

    public void OnCollected(GameObject player)
    {
        Debug.Log("collected");
        if (playerBlue == player)
        {
            playerBluePoints++;
        }
        if(playerRed == player)
        {
            playerRedPoints++;
        }
    }

    void OnPlayerJoined(PlayerInput pl)
    {
        GameObject spawn = spawns[nextSpawn++];
        if (nextSpawn >= spawns.Count)
        {
            nextSpawn = 0;
        }

        pl.gameObject.transform.SetPositionAndRotation(spawn.transform.position, spawn.transform.rotation);
    }
}
