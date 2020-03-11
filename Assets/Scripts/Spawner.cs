using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int wavesNumber = 3;
    public int enemiesInWave = 3;
    public float firstSpawnDelay = 0f;
    public float delayBetweenWaves = 8f;
    public float spawnRadius = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        int curWave = 0;
        yield return new WaitForSeconds(firstSpawnDelay);
        while (curWave < wavesNumber)
        {
            for (int i = 0; i < enemiesInWave; i++)
            {
                //Рандомный оффсет от центра спавнера
                Vector2 spawnOffset = Random.insideUnitCircle * spawnRadius;

                Instantiate(enemyPrefab, (Vector2)transform.position + spawnOffset, Quaternion.identity);
            }
            curWave++;
            yield return new WaitForSeconds(delayBetweenWaves);
        } 

    }

}
