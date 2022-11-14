using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 0.5f;

    public float spawnMinRangeZ = -1.0f;
    public float spawnMaxRangeZ = 17.0f;
    public float sideSpawn = 16.0f;

    // Start is called before the first frame update
    void Start()
    {
        // After startDelay, will call method SpawnRandomAnimal every spawnInterval
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeft", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex],
            spawnPosition,
            animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeft()
    {
        int animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPositionSide = new Vector3(-sideSpawn, 0, UnityEngine.Random.Range(spawnMinRangeZ, spawnMaxRangeZ));
        Vector3 rotateRight = new Vector3(0, 90, 0);

        Instantiate(animalPrefabs[animalIndex],
            spawnPositionSide,
            Quaternion.Euler(rotateRight));

        UnityEngine.Debug.Log("Left");
    }
}
