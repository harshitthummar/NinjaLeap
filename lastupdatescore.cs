using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lastupdatescore : MonoBehaviour
{
    private void Start()
    {
        if (DBmanager.username != null)
        {
            StartCoroutine(calltheupdatescore());
            
        }
    }
    IEnumerator calltheupdatescore()
    {
        WWWForm updatescoreform = new WWWForm();
        updatescoreform.AddField("score", DBmanager.score);
        updatescoreform.AddField("username", DBmanager.username);


        WWW www = new WWW("http://localhost/NinjaLeap/updatescore.php", updatescoreform);
        yield return www;
        string[] output = www.text.Split(" ");
        Debug.Log(www.text);
        if (output[0] == "0")
        {

            Debug.Log(" 1 score updated");


        }

    }
}
