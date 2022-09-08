using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public GameObject Mario;
    public float speed = 3;
    private bool rotation = false;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tubes"))
        {
            if (rotation)
            {
                rotation = false;
            }
            else
            {
                rotation = true;
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollider") && Mario.transform.position.y > gameObject.transform.position.y)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject, 0.5f);
        }
    }
    void FixedUpdate()
    {
        if (rotation)
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
        else if (!rotation)
        {
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
        }
        
    }
}
