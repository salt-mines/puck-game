using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collector") {
            GM.OnCollected(other.gameObject.GetComponentInParent<PuckScript>().previousPlayerTouched);
            gameObject.GetComponentInParent<FlowerSpawner>().currAmount--;
            Destroy(gameObject);
        }
    }
}
