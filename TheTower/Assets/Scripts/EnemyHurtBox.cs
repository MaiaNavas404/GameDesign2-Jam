using System;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerStay2D");
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyScript>().TakeDamage(1);
        }
    }
}
