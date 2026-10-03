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
    [SerializeField] private float timeBetweenSpawns = 0.25f;
    public List<GameObject> enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeBetweenSpawns)
        {
            _spawnYLevelVariation = Random.Range(-yLevelspawnVarition/2, yLevelspawnVarition/2);
            GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position.x, transform.position.y + _spawnYLevelVariation, transform.position.z), Quaternion.identity,transform);
            enemies.Add(newEnemy);
            _timer = 0;
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
}
