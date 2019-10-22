using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int waveCount = 3;
    public int enemiesInWave = 3;
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
        while (curWave < waveCount)
        {
            for (int i = 0; i < enemiesInWave; i++)
            {
                //Рандомный оффсет от центра спавнера
                Vector2 spawnOffset = Random.insideUnitCircle * spawnRadius;

                Instantiate(enemyPrefab, (Vector2)transform.position + spawnOffset, Quaternion.Euler(0f, 0f, 0f));
            }
            curWave++;
            yield return new WaitForSeconds(delayBetweenWaves);
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
