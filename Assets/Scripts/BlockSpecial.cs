using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpecial : MonoBehaviour
{
    public Animator Animator;

    public GameObject Mario;

    private void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (collision2D.collider.tag.Contains("Player") && Mario.transform.position.y < gameObject.transform.position.y)
        {
            Animator.SetBool("Usado",true);
        }
    }
}
