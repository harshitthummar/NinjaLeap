using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D player;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            die();
        }
    }

    private void die()
    {
        player.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        //this.GetComponent<PlayerMovement>().enabled = false;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
