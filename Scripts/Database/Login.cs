using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    [SerializeField] private InputField user;
    [SerializeField] private InputField password;
    [SerializeField] private Button Submit;

    public void callthelogin()
    {
        StartCoroutine(loginplayer());
    }

    IEnumerator loginplayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user.text);
        form.AddField("password", password.text);


        WWW www = new WWW("http://localhost/NinjaLeap/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBmanager.username=user.text;
            www.text.Split('\t');
            DBmanager.score = www.text[1];
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("User Login Failed error. #"+www.text);
        }
    }

    public void VarifyInput()
    {
        Submit.interactable = (user.text.Length >= 8 && password.text.Length >= 8);
    }
}
