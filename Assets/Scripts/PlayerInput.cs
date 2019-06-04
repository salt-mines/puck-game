using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    public int playerNumber;

    public TextMeshProUGUI text;

    internal float throttle;
    internal float horizontal;
    
    void Update()
    {
        throttle = Input.GetAxis("Throttle " + playerNumber);
        horizontal = Input.GetAxis("Horizontal " + playerNumber);

        Debug.Log("asd");
        text.text = string.Format("{0}: {1:F2}; {2:F2}", playerNumber, throttle, horizontal);
    }
}
