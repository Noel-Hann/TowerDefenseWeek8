using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public TextMeshProUGUI waveCountDownText;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 1;
    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        Mathf.Clamp(countdown, 0, Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}",countdown); //$"Time: {Mathf.Round(countdown)}";
    }

    IEnumerator spawnWave()
    {
        
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
        //Debug.Log("Wave incoming");
        waveNumber++;
        PlayerStats.rounds++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position,spawnPoint.rotation);
        
    }
}
