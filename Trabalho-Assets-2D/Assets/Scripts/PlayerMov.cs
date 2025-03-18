using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMov : MonoBehaviour
{
    public float speed = 5;
    public int jumpForce = 10;
    private Rigidbody2D rb;
    [SerializeField]public Animator Animator;
    public bool isGrounded;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
        VirarJogador();
    
    }

    
    
    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");


        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);




        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);



    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Animator.SetBool("Pulando", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.CompareTag("enemy") || collision.gameObject.transform.CompareTag("enemy2"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.transform.CompareTag("Grounded"))
        {
            Animator.SetBool("Pulando", false);
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.transform.CompareTag("Grounded"))
        {
            
            Animator.SetBool("Pulando", true);
            isGrounded = false;
        }
    }

    public void VirarJogador()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Animator.SetBool("Andando", true);
           transform.localScale = new Vector3(-1.903597f, 1.903597f, 1.903597f);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            Animator.SetBool("Andando", true);
            transform.localScale = new Vector3(1.903597f, 1.903597f, 1.903597f);
        }
        else
        {
            Animator.SetBool("Andando", false);
        }
    }


   
}
