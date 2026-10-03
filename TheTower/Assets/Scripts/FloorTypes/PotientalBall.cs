using UnityEngine;

public class PotientalBall : CannonBall
{
    public float damagemultiplier = 0.1f;
    public int level = 0;
    public override void DealDamage()
    {        
        Collider2D[] objecctsHit;
        objecctsHit = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D anObject in objecctsHit)
        {
            if (anObject.gameObject.CompareTag("Enemy"))
            {
                Debug.Log(damage + (level * damagemultiplier));
                anObject.GetComponent<EnemyScript>().TakeDamage(damage + (level * damagemultiplier));
            }
        }
    }
}
