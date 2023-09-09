using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement Config")]
    [SerializeField] private float JumpPower;
    [SerializeField] private float MovementSpeed;

    private float HorizontalInput;
    //intialization
    private Rigidbody2D player;
    private Animator anim;


    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        //turn player left or right
        turnplayer();

        //to move player
        player.velocity=new Vector2(HorizontalInput * MovementSpeed,player.velocity.y);


        //jump player
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        player.velocity = new Vector2(player.velocity.x,JumpPower);
        //for jump animation
        anim.SetTrigger("Jump");
    }

    private void turnplayer()
    {
        //to turn player left or right
        if (HorizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
            anim.SetBool("Running", true);
        }
        else if (HorizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
}
