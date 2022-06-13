using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
  
    public PlayerHealth playerHealth;




    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("AI_Player"))// && other.GetComponent<Collider>() is CapsuleCollider)
    //    {
    //        Debug.Log("Hit");
    //        InvokeRepeating("Hit", 0.5f, 0.5f);
    //    }

    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("here");
        if (collision.gameObject.CompareTag("EnemyFireball"))
        {
            Debug.Log("Fireball");
            Destroy(collision.gameObject);
            TakeDamage(10);
        }

    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("AI_Player"))// && other.GetComponent<Collider>() is CapsuleCollider)
    //    {
    //        Debug.Log(collision.gameObject.name);
    //        Debug.Log("Hit");
    //        InvokeRepeating("Hit", 0.5f, 0.5f);
    //    }

    //}


    public void TakeDamage(int damage)
    {
        playerHealth.currentHealth -= damage;
    }

    public void Damage()
    {
        TakeDamage(2);
    }
}
