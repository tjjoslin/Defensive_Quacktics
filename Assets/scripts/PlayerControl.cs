using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D SelfRB;
    public bool block;
    public bool parry;
    public bool hit;
    public float parryDamage;

    public GameObject  parryPoint;
    public float radius;
    public LayerMask Enemy;

    public Animator blocking;

    private void Start()
    {
        block = false;
        parry = false;
        hit = false;
    }

    private void Update()
    {
        if (hit == true)
        {
            GameManager.health -= 1; 
            hit = false;
           
        }

                if (Input.GetKey(KeyCode.Space))
                {                
                    blocking.SetInteger("state", 1);
                   
                    Debug.Log("Parrying");
                }
                else
                {        
                    blocking.SetInteger("state", 0);
                    parry = false;
                }

/*
                if (Input.GetKey(KeyCode.Space))
                {
                    block = true;
                    Debug.Log("Blocking");

                }
                else
                {
                    block = false;

                }*/
    }

    public void isParrying()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(parryPoint.transform.position, radius, Enemy);

        foreach (Collider2D enemyGameObject in enemy)
        {
            
            enemyGameObject.GetComponent<EnemyController>().health -= parryDamage;
        }
    }

    private void isBlocking()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(parryPoint.transform.position, radius, Enemy);

        foreach (Collider2D enemyGameObject in enemy)
        {
            

            GameManager.shield -= 1;
            block = true;

            if (GameManager.shield <= 0)
            {
                hit = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position += new Vector3(Time.deltaTime * 1, 0, 0);
        }

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && parry)
        {
            Debug.Log("Parried");
            
        }


        if (collision.gameObject.tag == "Enemy" && block == false && parry == false)
        {
            hit = true;
            SelfRB.velocity = new Vector2(-2, 3);
            transform.position += new Vector3(Time.deltaTime * -4, 0, 0);
        }

        if (collision.gameObject.tag == "Enemy" && block == true && parry == false)
        {
            SelfRB.velocity = new Vector2(-2, 1);
            Debug.Log("Blocked");
        }     
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parryPoint.transform.position, radius);
    }

    

}

