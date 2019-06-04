using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collector") {
            GM.OnCollected(other.gameObject.GetComponent<PuckScript>().previousPlayerTouched);
            Destroy(gameObject);
        }
    }
}
