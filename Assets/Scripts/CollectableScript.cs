using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collector") {
            //if (other.gameObject.GetComponent<PuckScript>().previousPlayerTouched == GameManager)
            Destroy(gameObject);
        }
    }
}
