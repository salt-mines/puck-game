using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private GameManager GM;
    private FlowerSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        spawner = GameObject.FindGameObjectWithTag("CollectibleSpawner").GetComponent<FlowerSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collector") {
            PuckScript puck = other.gameObject.GetComponentInParent<PuckScript>();
            if (puck.previousPlayerTouched != null)
            {
                GM.OnCollected(puck.previousPlayerTouched);
                spawner.currAmount--;
                Destroy(gameObject);

                puck.Score();
            }
        }
    }
}
