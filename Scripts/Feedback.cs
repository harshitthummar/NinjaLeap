using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour
{

    [SerializeField] private InputField feedbacktext;
    [SerializeField] private Button Submit;
    [SerializeField] private Text promptoffeedback;
    private bool submitted=false;

    public void callthefeedbackform()
    {
        if (DBmanager.Loggedin)
        {
            StartCoroutine(feedbackofplayer());
        }
        else
        {
            //give user masseage to log in first
            promptoffeedback.text = ("Please Login First");
        }
        
    }

    IEnumerator feedbackofplayer()
    {
        WWWForm feedbackform = new WWWForm();
        feedbackform.AddField("feedbacktext", feedbacktext.text);
        feedbackform.AddField("username", DBmanager.username);

        WWW www = new WWW("http://localhost/NinjaLeap/feedback.php", feedbackform);
        yield return www;
        if (www.text[0] == '0')
        {
            promptoffeedback.text = ("Submited Successfully");
            Debug.Log("submitted successfully");
            
        }
        else
        {
            Debug.Log("submission Failed error. #" + www.text);
            promptoffeedback.text= "submission Failed";
        }

    }
    
    public void Backtomainmenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void VarifyfeedbackInput()
    {
        
      Submit.interactable = (feedbacktext.text.Length <= 160);     
     
    }
}
