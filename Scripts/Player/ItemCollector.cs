using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int Score=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("strawberry"))
        {
            Destroy(collision.gameObject);
            Score++;
            Debug.Log("Score - " + Score);
        }
    }
}
