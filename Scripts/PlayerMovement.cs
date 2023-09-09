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


    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        player.velocity=new Vector2(HorizontalInput * MovementSpeed,player.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        player.velocity = new Vector2(player.velocity.x,JumpPower);
    }
}
