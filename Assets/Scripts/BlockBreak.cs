using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
    public GameObject Mario;
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        
        if (collision2D.collider.tag.Contains("Player") && Mario.transform.position.y<gameObject.transform.position.y)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
}
