using System;
using UnityEngine;

public class ZapTower : FloorBase
{
    public float damage = 20f;
    public override void Trigger()
    {
        base.Trigger();
        AttackEnemiesNearTheTower();
    }

    private void AttackEnemiesNearTheTower()
    {
        Collider2D[] objecctsHit;
        objecctsHit = Physics2D.OverlapBoxAll(transform.position, new Vector2(6, 100),0);
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
        Gizmos.color = new Color(1,1,1,0.25f);
        Gizmos.DrawCube(transform.position, new Vector3(6f, 20f, 0.1f));
    }
}
