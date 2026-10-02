using System;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("OnTriggerStay2D");
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyScript>().TakeDamage(0.5f);
        }
    }
}
