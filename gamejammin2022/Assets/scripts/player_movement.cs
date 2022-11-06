using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    
    public float mov_speed = 7f;
    private float direcX = 0;
    public float jumpForce = 20f;

    private enum MovementState { idle, running, jumping, falling }
    private MovementState state = MovementState.jumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        direcX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(mov_speed * direcX, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        } 

        UpdateAnim();

    }

    private void UpdateAnim()
    {

        MovmentState state; 
        if (direcX > 0f)
        {
            state = MovementState.running; 
            sprite.flipX = false;
        }
        else if (direcX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f){
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
}
