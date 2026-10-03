using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.Serialization;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    enum States
    {
        Move,
        Attack
    };
    

    private States _state;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 10;
    [SerializeField] private float health = 100;
    [HideInInspector] public EnemySpawner mother;

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case States.Move:
                Move();
                break;
            case States.Attack:
                break;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Move()
    {
        transform.Translate(-speed * Time.deltaTime ,0,0);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        spriteRenderer.color = Color.Lerp(Color.darkRed, Color.white, health / 100);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            _state = States.Attack;
            animator.Play("attack");
        }

    }

    private void Die()
    {
        mother.RemoveEnemyFromList(gameObject);
        Destroy(gameObject);
        
    }
}
