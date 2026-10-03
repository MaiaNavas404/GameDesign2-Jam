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
    [SerializeField] private float speed = 1;
    public float health = 100;
    [SerializeField] private float damage = 2;
    [HideInInspector] public EnemySpawner mother;
    [SerializeField] private Tower tower;
    [HideInInspector] public int direction = -1; //default is moving towards the left

    private float _timer;

    private float _attackTime = 0.6f;
    // Update is called once per frame
    void Start()
    {
        if (direction == 1)
        {
            spriteRenderer.flipX = true;
        }
    }
    void Update()
    {
        switch (_state)
        {
            case States.Move:
                Move();
                break;
            case States.Attack:
                _timer += Time.deltaTime;
                if (_timer >= _attackTime)
                {
                    attack();
                    _timer = 0;
                }
                break;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    private void attack()
    {
        tower.TakeDamage(damage);
    }

    void Move()
    {
        transform.Translate( direction * speed * Time.deltaTime ,0,0);
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
            tower =  other.gameObject.GetComponent<Tower>();
        }
    }
    private void Die()
    {
        mother.RemoveEnemyFromList(gameObject);
        Destroy(gameObject);
    }
}
