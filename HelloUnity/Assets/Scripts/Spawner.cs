using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{
    public GameObject template;
    public float range;
    public int maxSpawns;

    GameObject[] collectibles;
    // Start is called before the first frame update
    void Start()
    {
        collectibles = new GameObject[maxSpawns];
        for (int i = 0; i < maxSpawns; i++)
        {
            GameObject spawnedObject = Instantiate(template);
            setPosition(spawnedObject);
            collectibles[i] = spawnedObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
       //if an instantiated object has been picked up, spawn the collectible elsewhere  
       for (int i = 0; i < maxSpawns; i++)
        {
            if (collectibles[i].activeSelf == false)
            {
                setPosition(collectibles[i]);
                collectibles[i].SetActive(true);
            }
       }

    }

    void setPosition(GameObject obj)
    {
        Vector3 randomPosition = new Vector3(transform.position.x + Random.Range(-range, range), transform.position.y, transform.position.z + Random.Range(-range, range));
        obj.transform.position = randomPosition;
    }


}
