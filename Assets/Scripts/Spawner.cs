using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int waveCount = 3;
    public int enemiesInWave = 3;
    public float delayBetweenWaves = 8f;
    

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
                Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
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
