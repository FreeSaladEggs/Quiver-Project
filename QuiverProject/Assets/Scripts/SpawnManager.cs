using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    private float spawnRangex = 100;
    private float spawnRangexm = 35;
    private float spawnPosZm = 90;
    private float spawnPosZ = 50;
    private float spawnPosY = 21.92f;
    public float startDelay = 2;
    public float spawnInterval = 11;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, spawnInterval);
    }

    // Update is called once per frame

    void SpawnEnemies()
    {

        Vector3 SpawnPos = new Vector3(Random.Range(spawnRangexm, spawnRangex), spawnPosY, Random.Range(spawnPosZ,spawnPosZm) );

        Instantiate(Enemy, SpawnPos, Enemy.transform.rotation);

    }
}
