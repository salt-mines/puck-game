using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{ 
    Vector3 min;
    Vector3 max;

    public int currAmount;
    public int maxAmount = 3;

    public float spawnTime = 5f;
    private float timeElapsed;
    

    public GameObject flowerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        min = GetComponent<MeshFilter>().mesh.bounds.min;
        max = GetComponent<MeshFilter>().mesh.bounds.max;

        timeElapsed = spawnTime;
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
        GameObject Flower = Instantiate(flowerPrefab, 
                            new Vector3((Random.Range(min.x, max.x) * transform.localScale.x), 
                            flowerPrefab.transform.position.y, 
                            (Random.Range(min.z, max.z) * transform.localScale.z)), 
                            Quaternion.identity);

        Flower.transform.parent = gameObject.transform;
    }
}
