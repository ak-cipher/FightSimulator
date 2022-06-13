using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_PlayerCollisionController : MonoBehaviour
{
    
    public AI_PlayerHealth playerHealth;


   


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))//&& other.collider is CapsuleCollider)
    //    {
    //        Debug.Log("Hit");
    //        InvokeRepeating("Damage",0.5f, 0.5f);
    //    }
        
    //}


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("here");
        if (collision.gameObject.CompareTag("MyFireball"))
        {
            Debug.Log("Fireball");
            Destroy(collision.gameObject);
            TakeDamage(10);
        }
    
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))//&& other.collider is CapsuleCollider)
        {
            Debug.Log(collision.gameObject.name);
            Debug.Log("Hit");
            InvokeRepeating("Damage", 0.5f, 0.5f);
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth.currentHealth -= damage;
    }

    public void Damage()
    {
        TakeDamage(2);
    }
}
