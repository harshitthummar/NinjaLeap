using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBmanager
{
    public static string username;
    public static int score;
    public static int currentscore;
    public static int HighestScore;
    public static bool scorenotupdate;
    public static bool Loggedin { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }
}
