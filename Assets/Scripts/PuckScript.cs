using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public GameManager gameManager;

    internal GameObject previousPlayerTouched;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //vaihda kiekon väri pelaajan väriksi
            previousPlayerTouched = collision.gameObject;

            gameManager.ChangeMowerColor(gameObject, previousPlayerTouched.GetComponent<Player>().playerTeamColor);
        }
    }
}
