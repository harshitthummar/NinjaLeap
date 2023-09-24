using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    

    [SerializeField] private Text ScoreText;

    [SerializeField] private AudioSource CollectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("strawberry"))
        {
            CollectSound.Play();
            Destroy(collision.gameObject);
            DBmanager.score++;

            ScoreText.text = ""+ DBmanager.score;
            
        }
    }
}
