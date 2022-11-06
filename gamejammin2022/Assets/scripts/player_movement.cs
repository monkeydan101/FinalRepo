using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public float mov_speed = 7f;
    private float direcX = 0;
    public float jumpForce = 20f;

    public float air_amount;

    public airScript airbar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        air_amount = 10f;


    }

    // Update is called once per frame
    private void Update()
    {
        direcX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(mov_speed * direcX * air_amount/3, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, jumpForce - (air_amount / 5), 0);
        }

        UpdateAnim();

        UpdateAir();
    }

    private void UpdateAnim()
    {
        if (direcX > 0f)
        {
            sprite.flipX = false;
        }
        else if (direcX < 0f)
        {

            sprite.flipX = true;
        }

        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "tree")
        {
            air_amount = 10;
        }
    }

    private void UpdateAir()
    {

        airbar.SetAirlevel(air_amount);



        air_amount -= (Time.deltaTime)/2;
    }

}