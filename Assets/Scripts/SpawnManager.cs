using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 70;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(2);
    }
    
    Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.5f, spawnPosZ);
        return randomPos;
    }
    
    void SpawnEnemies(int count) {
        for (int i = 0; i < count; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 1) {
            int random = Random.Range(5, 25);
            SpawnEnemies(random);
        }
    }
}
