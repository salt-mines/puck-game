using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int goalToWin = 10;

    internal int playerBlueWins;
    internal int playerRedWins;

    internal int playerBluePoints;
    internal int playerRedPoints;

    public GameObject playerOne;
    public GameObject playerTwo;

    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerBluePoints >= goalToWin || playerRedPoints >= goalToWin) {
            isGameOver = true;
        }  
    }
}
