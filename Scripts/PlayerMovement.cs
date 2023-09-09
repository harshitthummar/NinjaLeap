using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement Config")]
    [SerializeField] private float JumpPower;
    
    
    //intialization
    private Rigidbody2D player;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        player.velocity = new Vector3(0, transform.localScale.y * JumpPower, transform.localScale.z);
    }
}
