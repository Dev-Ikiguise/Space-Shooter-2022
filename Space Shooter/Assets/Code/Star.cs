using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject starPrefab;
    public int numberOfStarsToSpawn;
    public int max_X;
    public int max_Y;
    public int max_Z;
    public int min_Z;

    
    void Start()
    {
        for(int i = 0; i < numberOfStarsToSpawn; i++)
        {
            float rand_X = Random.Range(-max_X, max_X);
            float rand_Y = Random.Range(-max_Y, max_Y);
            float rand_Z = Random.Range(min_Z, max_Z);

            Vector3 spawnPosition = new Vector3(rand_X, rand_Y, rand_Z);

            Instantiate(starPrefab, spawnPosition, transform.rotation, transform);
        }
    }

    
}
