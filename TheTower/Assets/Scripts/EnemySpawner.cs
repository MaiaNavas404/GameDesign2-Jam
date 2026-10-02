using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _timer;
    
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timeBetweenSpawns = 0.25f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeBetweenSpawns)
        {
            Instantiate(enemy);
            _timer = 0;
        }
    }
}
