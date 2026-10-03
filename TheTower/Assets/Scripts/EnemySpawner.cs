using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private float _timer;
    private float _spawnYLevelVariation;
    [SerializeField] private float yLevelspawnVarition;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float baseTimeBetweenSpawns = 1f;
    [SerializeField] private float lowerTimePerLevel = 0.02f;
    [SerializeField] private float minimumTime = 0.25f;
    [SerializeField] private bool isGoingRight = false;
    private float timeBetweenSpawns = 0;
    public List<GameObject> enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        timeBetweenSpawns =  baseTimeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeBetweenSpawns)
        {
            SpawnEnemy();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(0.25f, yLevelspawnVarition, 1));
    }

    public void RemoveEnemyFromList(GameObject enemyToRemove)
    {
        enemies.Remove(enemyToRemove);
    }

    private void SpawnEnemy()
    {
        _spawnYLevelVariation = Random.Range(-yLevelspawnVarition/2, yLevelspawnVarition/2);
        GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position.x, transform.position.y + _spawnYLevelVariation, transform.position.z), Quaternion.identity,transform);
        EnemyScript newEnemyScript = newEnemy.GetComponent<EnemyScript>();
        newEnemyScript.mother = this;
        if (isGoingRight)
            newEnemyScript.direction = 1;
        enemies.Add(newEnemy);
        _timer = 0;
    }

    public void UpdateTimeBetweenSpawn()
    {
        timeBetweenSpawns -= lowerTimePerLevel;
        if (timeBetweenSpawns < minimumTime)
        {
            timeBetweenSpawns = minimumTime;
        }
    }
}
