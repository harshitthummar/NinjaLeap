using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int Score=0;

    [SerializeField] private Text ScoreText; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("strawberry"))
        {
            Destroy(collision.gameObject);
            Score++;
            ScoreText.text = "Score: " + Score;
        }
    }
}
