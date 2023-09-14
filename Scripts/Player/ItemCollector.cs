using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int Score=0;

    [SerializeField] private Text ScoreText;

    [SerializeField] private AudioSource CollectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("strawberry"))
        {
            CollectSound.Play();
            Destroy(collision.gameObject);
            

            ScoreText.text = ""+Score;
            
        }
    }
}
