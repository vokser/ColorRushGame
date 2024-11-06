using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnStripInterval;
    [SerializeField] private float _spawnObstacleInterval;
    [SerializeField] private GameObject stripPrefab;
    [SerializeField] private GameObject obstaclePrefab;

    private float stripTimer;
    private float obstacleTimer;
    private float currentSpeed;


    private void Start()
    {
        stripTimer = _spawnStripInterval;
        obstacleTimer = _spawnObstacleInterval;
    }

    private void Update()
    {
        stripTimer -= Time.deltaTime;

        if(stripTimer <= 0)
        {
            SpawnStrip();
            stripTimer = _spawnStripInterval;
        }

        obstacleTimer -= Time.deltaTime;

        if (obstacleTimer <= 0)
        {
            SpawnObstacle();
            obstacleTimer = _spawnStripInterval;
        }
    }
    

    private void SpawnStrip()
    {
        float spawnX = Random.Range(-1.75f, 1.75f);
        Vector2 spawnPoint = new Vector2(spawnX, transform.position.y);
        Instantiate(stripPrefab, spawnPoint, Quaternion.identity);
    }
    
    private void SpawnObstacle()
    {
        float spawnX = Random.Range(-2.5f, 2.5f);
        Vector2 spawnPoint = new Vector2(spawnX, transform.position.y);
        Instantiate(obstaclePrefab, spawnPoint, Quaternion.identity);
    }
}
