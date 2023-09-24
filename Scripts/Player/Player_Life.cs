using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D player;

    [SerializeField] private AudioSource DeathSound;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("trap"))
        {
            die();
        }
    }
   
    

    private void die()
    {
        player.bodyType = RigidbodyType2D.Static;
        DeathSound.Play();
        anim.SetTrigger("death");
        
        //this.GetComponent<PlayerMovement>().enabled = false;
       
        if(DBmanager.username != null)
        {
            StartCoroutine(calltheupdatescore());
            Debug.Log(DBmanager.username);
            resetscore();
        }
        
    }
    private void resetscore()
    {
        DBmanager.score = 0;
    }


     IEnumerator calltheupdatescore()
     {
         WWWForm updatescoreform = new WWWForm();
         updatescoreform.AddField("score", DBmanager.score);
         updatescoreform.AddField("username", DBmanager.username);


         WWW www = new WWW("http://localhost/NinjaLeap/updatescore.php", updatescoreform);
         yield return www;
        string[] output= www.text.Split(" ");
         Debug.Log(www.text);
         if (output[0] == "0")
         {

             Debug.Log(" 1 score updated");
     
            
         }

     }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
}
