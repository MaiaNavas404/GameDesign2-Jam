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
    
    private float _spawnYLevelVariation;
    private States _state;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D attackTrigger;
    [SerializeField] private Vector2 yLevelspawnVarition;
    [SerializeField] private float speed = 10;
    [SerializeField] private float health = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawnYLevelVariation =  Random.Range(yLevelspawnVarition.x,yLevelspawnVarition.y);
        transform.Translate(0,_spawnYLevelVariation,0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{health},{_state}");
        switch (_state)
        {
            case States.Move:
                Move();
                break;
            case States.Attack:
                break;
        }
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

    public void TakeDamage(float damage)
    {
        health -= damage;
        spriteRenderer.color = Color.Lerp(Color.darkRed, Color.white, health / 100);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.("Tower"))
        {
            _state = States.Attack;
            animator.Play("attack");
        }

    }
}
