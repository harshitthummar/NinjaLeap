using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    [SerializeField] private InputField user;
    [SerializeField] private InputField password;
    [SerializeField] private Button Submit;

    public void calltheregister()
    {
        StartCoroutine(register());
    }
    IEnumerator register()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user.text);
        form.AddField("password", password.text);


        WWW www = new WWW("http://localhost/NinjaLeap/register.php",form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("User Created Successfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("User Not Created .Error #" + www.text);
        }
    }
    public void VarifyInput()
    {
        Submit.interactable=(user.text.Length >= 8 && password.text.Length >= 8);
    }
}
