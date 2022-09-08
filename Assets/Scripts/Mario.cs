using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour
{
    public float speed=2;

    public float jumpSpeed = 3;

    public float fallMultiplayer = 0.5f;

    public float lowJumpMultiplayer = 1f;

    public Rigidbody2D Rigidbody2D;

    public Animator Animator;

    public SpriteRenderer SpriteRenderer;


    public Camera Camera;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !Animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            Animator.SetBool("Death", true);
            //Destroy(gameObject, 0.5f);
            Invoke("ChangeScene", 0.5f);
        }

    }
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate()
    {
        if (Input.GetKey("left"))
        {
            Rigidbody2D.velocity = new Vector2(-speed,Rigidbody2D.velocity.y);
            SpriteRenderer.flipX = true;
            Animator.SetBool("Walk", true);
        }
        else if (Input.GetKey("right"))
        {
            Rigidbody2D.velocity = new Vector2(speed, Rigidbody2D.velocity.y);
            SpriteRenderer.flipX = false;
            Animator.SetBool("Walk", true);
            if (Rigidbody2D.position.x>=Camera.transform.position.x)
            {
             Camera.transform.position = new Vector3(Camera.transform.localPosition.x+0.04f, Camera.transform.localPosition.y,-1);
            }

        }
        else
        {
            Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y);
            Animator.SetBool("Walk", false);
        }
        if (Input.GetKey("up") && CheckGround.isGrounded)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, jumpSpeed);
        }

        if (!CheckGround.isGrounded)
        {
            Animator.SetBool("Jump", true);
            Animator.SetBool("Walk", false);
        }

        if (CheckGround.isGrounded)
        {
            Animator.SetBool("Jump", false);
        }

        if (Rigidbody2D.velocity.y < 0)
        {
            Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer) * Time.deltaTime;
        }

        if (Rigidbody2D.velocity.y > 0 && !Input.GetKey("up"))
        {
            Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
        }
        
    }
}
