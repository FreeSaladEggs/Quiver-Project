using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    private float spawnRangex = 12;
    private float spawnPosZ = 0;
    public float startDelay = 2;
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, spawnInterval);
    }

    // Update is called once per frame

    void SpawnEnemies()
    {

        Vector3 SpawnPos = new Vector3(Random.Range(-spawnRangex, spawnRangex), 21.143f, spawnPosZ);

        Instantiate(Enemy, SpawnPos, Enemy.transform.rotation);

    }
}
