using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBmanager
{
    public static string username;
    public static int score=0;
   
    public static bool Loggedin { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }
}
