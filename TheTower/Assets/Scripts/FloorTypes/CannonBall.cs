using System;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    
    public float explosionRadius = 1.5f;
    public float damage = 30f;
    public float mass = 1f;
    public Vector2 initialForce = new Vector2(10f,3f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody.AddForce(initialForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DealDamage();
            Destroy(gameObject);
        }
    }

    private void DealDamage()
    {        
        Collider2D[] objecctsHit;
        objecctsHit = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D anObject in objecctsHit)
        {
            if (anObject.gameObject.CompareTag("Enemy"))
            {
                anObject.GetComponent<EnemyScript>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawSphere(transform.position,explosionRadius);
    }
}
