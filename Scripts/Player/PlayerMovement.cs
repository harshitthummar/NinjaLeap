using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement Config")]
    [SerializeField] private float JumpPower;
    [SerializeField] private float MovementSpeed;

    private float HorizontalInput;
    private enum MovementState {idle,running,jumping,falling }
    

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
        turnandanimateplayer();

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

    private void turnandanimateplayer()
    {
        MovementState state;
        //to turn player left or right
        if (HorizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
            state = MovementState.running;
           // anim.SetBool("Running", true);
        }
        else if (HorizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            state = MovementState.running;
            //anim.SetBool("Running", true);
        }
        else
        {
            state = MovementState.idle;
           // anim.SetBool("Running", false);
        }

        //to check player is jumping or falling
        if(player.velocity.y > 0.1f) 
        {
            state = MovementState.jumping;
        }
        else if(player.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }


        anim.SetInteger("state",(int)state);
    }
}
