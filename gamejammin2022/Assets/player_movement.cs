using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello bruh");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
        } 
    }
}
