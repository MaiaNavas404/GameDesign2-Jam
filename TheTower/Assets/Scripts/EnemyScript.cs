using System.Drawing;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D collider2D;
    [SerializeField] private float speed = 10;
    [SerializeField] private Vector2 spawnVarition;
    public float health = 100;
    private float spawnYLevelVariation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnYLevelVariation =  Random.Range(spawnVarition.x,spawnVarition.y);
        transform.Translate(0,spawnYLevelVariation,0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        transform.Translate(-speed * Time.deltaTime ,0,0);
    }

    void TakeDamage(float damage)
    {
        health -= damage;
    }
}
