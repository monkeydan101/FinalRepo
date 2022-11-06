using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    public float mov_speed = 7f;
    private float direcX = 0;
    public float jumpForce = 20f;

    [SerializeField] private LayerMask jumpableGround;

    public float air_amount;

    public airScript airbar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        air_amount = 10f;
        coll = GetComponent<BoxCollider2D>();
        

    }

    // Update is called once per frame
    private void Update()
    {
        direcX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(mov_speed * direcX * air_amount/3, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, jumpForce - (air_amount / 5), 0);
        }

        else if (Input.GetKeyDown("r"))
        {
            SceneChange();
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

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void UpdateAir()
    {

        airbar.SetAirlevel(air_amount);



        air_amount -= (Time.deltaTime - Time.deltaTime/6);

        if(air_amount <= 0)
        {
            death();
        }
    }

    private void death()
    {
        rb.bodyType = RigidbodyType2D.Static;
        transform.localRotation = Quaternion.Euler(0, 90, 0);
        Invoke("SceneChange", 3);

    }

    private void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}