using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class FlowerSpawner : MonoBehaviour
{ 
    private Vector3 min;
    private Vector3 max;
    
    [Range(1, 100)]
    public int maxAmount = 5;

    [Range(0.1f, 30)]
    public float spawnTime = 5f;

    internal int currAmount;
    private float timeElapsed = 0f;

    public GameObject flowerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        min = GetComponent<MeshFilter>().mesh.bounds.min;
        max = GetComponent<MeshFilter>().mesh.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (currAmount < maxAmount && spawnTime < timeElapsed)
        {
            timeElapsed = 0f;
            float newSpawnTime = Time.time + spawnTime;
            SpawnFlower();
            currAmount++;
        }
    }

    void SpawnFlower()
    {
        GameObject flower = Instantiate(flowerPrefab, 
                            new Vector3((Random.Range(min.x, max.x) * transform.localScale.x), 
                            flowerPrefab.transform.position.y, 
                            (Random.Range(min.z, max.z) * transform.localScale.z)), 
                            Quaternion.identity);

        flower.transform.parent = gameObject.transform;
    }
}
