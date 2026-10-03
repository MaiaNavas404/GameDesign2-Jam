using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CannonBall : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    
    public float explosionRadius = 1.5f;
    public float damage = 30f;
    public float mass = 1f;
    public float initialForce = 10f;
    [SerializeField] private float forceDeviance = 1f;

    void Start()
    {
        //Vector2 finalForce = initialForce + new Vector2(Random.Range(-forceDeviance.x/2,forceDeviance.x/2),Random.Range(-forceDeviance.y/2,forceDeviance.y/2)); 
        float finalForce = initialForce +  Random.Range(-forceDeviance/2,forceDeviance/2);
        rigidBody.AddForce(finalForce * transform.right, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DealDamage();
            Destroy(gameObject);
        }
    }

    public virtual void DealDamage()
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
