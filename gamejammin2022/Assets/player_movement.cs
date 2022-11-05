using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int mov_speed; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Hello bruh");
    }

    // Update is called once per frame
    void Update()
    {
        float direcX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(7f * direcX, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, 20, 0);
        } 


    }
}
