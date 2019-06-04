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
        throttle = Input.GetAxisRaw("Throttle " + playerNumber);
        horizontal = Input.GetAxisRaw("Horizontal " + playerNumber);

        text.text = string.Format("{0}: {1:F2}; {2:F2}", playerNumber, throttle, horizontal);
    }
}
