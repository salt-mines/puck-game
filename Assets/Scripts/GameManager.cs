using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Plugins.PlayerInput;

public class GameManager : MonoBehaviour
{
    public int goalToWin = 10;

    private List<GameObject> spawns = new List<GameObject>();
    private int nextSpawn = 0;

    private Dictionary<GameObject, PlayerColors> allPlayers = new Dictionary<GameObject, PlayerColors>();
    private Dictionary<PlayerColors, int> points = new Dictionary<PlayerColors, int>();

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
        
    }

    public void OnCollected(GameObject player)
    {
        //points[player.team]
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

        allPlayers.Add(pl.gameObject, spawn.GetComponent<PlayerSpawn>().playerColor);
    }

    public enum PlayerColors
    {
        Blue,
        Red,
    }
}
