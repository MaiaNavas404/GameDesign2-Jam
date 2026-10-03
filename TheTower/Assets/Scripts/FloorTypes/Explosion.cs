using System;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damage = 200f;
    [SerializeField] private float explosionRadius = 2000f;
    [SerializeField] private Animator animator;
    private float _liveTime = 3f;
    private float _timer = 0f;
    private List<GameObject> alreadyAttackedEnemies;
    private void Start()
    {
        animator.Play("Explosion");

    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _liveTime)
        {
            Destroy(gameObject);
        }
        Collider2D[] objecctsHit;
        objecctsHit = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D anObject in objecctsHit)
        {
            if (anObject.gameObject.CompareTag("Enemy") && !anObject.GetComponent<EnemyScript>().hasBeenBombed)
            {
                EnemyScript enemyScript = anObject.GetComponent<EnemyScript>();
                enemyScript.TakeDamage(damage);
                enemyScript.hasBeenBombed = true;
            }
        }
    }
}
