using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text PlayerDisplay;
    private void Start()
    {
        if (DBmanager.Loggedin)
        {
            PlayerDisplay.text = DBmanager.username;
        }
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
