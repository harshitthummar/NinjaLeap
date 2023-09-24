using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BacttoMainmenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    //ALTER TABLE player DROP COLUMN score;
}
