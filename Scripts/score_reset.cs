using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_reset : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        DBmanager.score = 0;   
    }
}
