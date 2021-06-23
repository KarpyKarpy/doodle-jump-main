using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float jumpForce = 30f;
    public Rigidbody2D rb;
    private bool grounded;
    public bool gravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    //makes jumping infintily impossible
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded == true)
        {



            rb.velocity += Vector2.up * jumpForce;
            grounded = false;
        }
        else if (Input.GetButton("Jump") && grounded == false)
        {

        }


        // SetAnimations(); <- didn't work

    }

    //resets jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            grounded = true;
        }







    }

   






}