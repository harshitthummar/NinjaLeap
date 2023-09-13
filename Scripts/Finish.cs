using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private AudioSource FinishSound;

    private bool islevelcompleted=false;
    private void Start()
    {
        FinishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !islevelcompleted)
        {
            FinishSound.Play();
            islevelcompleted = true;
            Invoke("CompleteLevel", 3f);
           
        }
        
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
