using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    private AudioSource FinishSound;
    private void Start()
    {
        FinishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FinishSound.Play();
        CompleteLevel();
    }
    private void CompleteLevel()
    {

    }
}
