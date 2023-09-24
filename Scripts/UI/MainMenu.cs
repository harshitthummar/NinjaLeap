using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text PlayerDisplay;
    [SerializeField] private Text score;
    [SerializeField] private Text lastscore;
    [SerializeField] private Text highestscore;
    private string localscore;
    private string localhighestscore;
    private string locallastscore;
    private void Start()
    {
        if (DBmanager.Loggedin)
        {
            PlayerDisplay.text = DBmanager.username;
            StartCoroutine(getscore());
            
        }
    }
    private void putdisplayscore()
    {
        score.text = "Score : "+ localscore;
        highestscore.text = "Highest Score : "+localhighestscore;
        lastscore.text = "Last Score : "+locallastscore;
    }
    IEnumerator getscore()
    {
        WWWForm getform = new WWWForm();
        getform.AddField("username", DBmanager.username);


        WWW www = new WWW("http://localhost/NinjaLeap/getscore.php", getform);
        yield return www;

       
        
        if (www.text[0] == '0')
        {

            //Debug.Log(" 1 score updated");
           localscore= www.text.Split('\t')[1];
           localhighestscore = www.text.Split('\t')[2];
            locallastscore = www.text.Split('\t')[3];

            Debug.Log(localscore);
            Debug.Log(localhighestscore);
            Debug.Log(locallastscore);
        }
        putdisplayscore();

    }
    public void GoToTheRegister()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToFeedback()
    {
        SceneManager.LoadScene(9);
    }
}
