using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{   
    public bool check { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            check = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.CompareTag("Player"));
        if (collision.transform.CompareTag("Player"))
        {   
            Destroy(transform.parent.gameObject);
            Debug.Log("OK");
        }
    }
}
