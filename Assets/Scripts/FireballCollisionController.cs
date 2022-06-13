using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollisionController : MonoBehaviour
{



    private void Start()
    {
        StartCoroutine(DestroyFireball());
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyFireball"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if( collision.gameObject.CompareTag("MyFireball") || collision.gameObject.CompareTag("Walls"))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyFireball()
    {
        float time = 8f;
        while(time>0f)
        {
            yield return new WaitForSeconds(1);
                time--;
        }

        Destroy(this.gameObject);
    }

}
