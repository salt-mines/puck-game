using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private GameManager GM;
    private FlowerSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        spawner = GetComponentInParent<FlowerSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collector") {
            PuckScript puck = other.gameObject.GetComponentInParent<PuckScript>();
            if (puck.previousPlayerTouched != null)
            {
                GM.OnCollected(other.gameObject.GetComponentInParent<PuckScript>().previousPlayerTouched);
                spawner.currAmount--;
                Destroy(gameObject);
            }
        }
    }
}
