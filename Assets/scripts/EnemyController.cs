using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D SelfRB;
    public float health;
    private void Update()
    {
       if (health <= 0)
        {
            Debug.Log("Enemy is dead");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SelfRB.velocity = new Vector2(3 , 3);
            transform.position += new Vector3(Time.deltaTime * 4, 0, 0);
        }

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position += new Vector3(Time.deltaTime * -1, 0, 0);
        }
    }

   
}
