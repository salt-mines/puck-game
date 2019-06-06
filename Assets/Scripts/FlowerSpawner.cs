using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class FlowerSpawner : MonoBehaviour
{ 
    private Vector3 min;
    private Vector3 max;

    [Range(1, 100)]
    public int startAmount = 3;

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

        while (currAmount < startAmount)
        {
            SpawnFlower();
            currAmount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (currAmount < maxAmount && spawnTime < timeElapsed)
        {
            timeElapsed = 0f;
            SpawnFlower();
            currAmount++;
        }
    }

    void SpawnFlower()
    {
        GameObject flower = Instantiate(flowerPrefab, 
                            new Vector3((Random.Range(min.x, max.x) * transform.localScale.x), 
                            0, 
                            (Random.Range(min.z, max.z) * transform.localScale.z)), 
                            Quaternion.identity);

        //flower.transform.parent = gameObject.transform;
        flower.transform.localRotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);
        
        flower.GetComponentInChildren<Animator>().speed = Random.Range(0.8f, 1.2f);
    }
}
