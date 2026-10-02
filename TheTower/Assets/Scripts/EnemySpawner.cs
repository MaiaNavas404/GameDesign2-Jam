using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private float _timer;
    private float _spawnYLevelVariation;
    [SerializeField] private float yLevelspawnVarition;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timeBetweenSpawns = 0.25f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeBetweenSpawns)
        {
            _spawnYLevelVariation = Random.Range(-yLevelspawnVarition/2, yLevelspawnVarition/2);
            Instantiate(enemy,new Vector3(transform.position.x, transform.position.y + _spawnYLevelVariation, transform.position.z), Quaternion.identity);
            _timer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(0.25f, yLevelspawnVarition, 1));
    }
}
