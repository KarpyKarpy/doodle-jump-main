using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private Animator animator;
    Animator m_Animator;
    public GameObject AstronautBoost;
    public GameObject AstronautIdle;
    public float jumpForce = 3f;
    private bool grounded;


    private float moveX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
  
    }

    // makes the player able to move left, right and jump
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            


            rb.velocity += Vector2.up * jumpForce;
            grounded = false;
            StartCoroutine("AnimationBoost");
        }
        else if (Input.GetButton("Jump") && grounded == false)
        {

        }
       


    }

    
    private void FixedUpdate()
    {

            Vector2 velocity = rb.velocity;
            velocity.x = moveX;
            rb.velocity = velocity;
        
        
       
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }



    //resets jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            grounded = true;
        }

        else
        {
            grounded = false;
            
        }

       



    }


    IEnumerator AnimationBoost()
    {
        AstronautIdle.gameObject.SetActive(false);
        AstronautBoost.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        AstronautIdle.gameObject.SetActive(true);
        AstronautBoost.gameObject.SetActive(false);
    }

}
